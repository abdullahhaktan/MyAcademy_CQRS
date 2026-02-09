using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Observers.OrderCreated;
using MyAcademyCQRS.CQRSPattern.OrderRules;
using MyAcademyCQRS.CQRSPattern.UnitOfWorks;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly OrderCreatedSubject _subject;

        public CreateOrderCommandHandler(
            AppDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            OrderCreatedSubject subject)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _subject = subject;

            // Observer kayıtları
            _subject.Register(new OnOrderCreatedLogObserver());
            _subject.Register(new OnOrderCreatedMailObserver());
        }

        public async Task Handle(CreateOrderCommand createOrderCommand)
        {
            // 1️⃣ Order oluştur
            var order = _mapper.Map<Order>(createOrderCommand);
            await _context.Orders.AddAsync(order);

            // 2️⃣ Cart + Rules (Chain of Responsibility)
            var cart = await _context.Carts
                .Include(c => c.OrderItems)
                .FirstOrDefaultAsync(c => c.AppUserId == createOrderCommand.UserId);

            var cartNotEmptyRule = new CartNotEmptyRule();
            var stockRule = new StockRule();

            cartNotEmptyRule.SetNext(stockRule);
            await cartNotEmptyRule.HandleAsync(cart);

            // 3️⃣ OrderItem bağla
            foreach (var item in cart.OrderItems)
            {
                item.Order = order;
                item.CartId = null;
            }

            cart.IsDeleted = true;

            // 4️⃣ Transaction commit
            await _unitOfWork.SaveChangesAsync();

            // 5️⃣ Observer tetikle (AFTER commit)
            await _subject.NotifyAsync(order);
        }
    }
}