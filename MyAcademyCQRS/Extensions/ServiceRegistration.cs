using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Handlers.AdminLogHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.CustomerLogHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers;
using MyAcademyCQRS.CQRSPattern.LogServices.AdminLogServices;
using MyAcademyCQRS.CQRSPattern.LogServices.CustomerLogServices;
using MyAcademyCQRS.CQRSPattern.MailServices;
using MyAcademyCQRS.CQRSPattern.Observers.OrderCreated;
using MyAcademyCQRS.CQRSPattern.StorageServices;
using MyAcademyCQRS.CQRSPattern.UnitOfWorks;
using MyAcademyCQRS.Entities;
using System.Reflection;

namespace MyAcademyCQRS.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            #region Category Registrations
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            #endregion

            #region Product Registrations
            services.AddScoped<GetProductsQueryHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddSingleton<IFileStorageService, GoogleCloudStorageService>();
            services.AddScoped<GetProductsByCategoryQueryHandler>();
            services.AddScoped<GetTotalProductCountByCategoryHandler>();
            services.AddScoped<GetProductsByPriceQueryHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
            #endregion

            #region Banner Registrations
            services.AddScoped<GetBannersQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            #endregion

            #region Feature Registrations
            services.AddScoped<GetFeaturesQueryHandler>();
            services.AddScoped<GetFeatureByIdQueryHandler>();
            services.AddScoped<UpdateFeatureCommandHandler>();
            services.AddScoped<CreateFeatureCommandHandler>();
            services.AddScoped<RemoveFeatureCommandHandler>();
            #endregion

            #region Story Registrations
            services.AddScoped<GetStoriesQueryHandler>();
            services.AddScoped<GetStoryByIdQueryHandler>();
            services.AddScoped<UpdateStoryCommandHandler>();
            services.AddScoped<CreateStoryCommandHandler>();
            services.AddScoped<RemoveStoryCommandHandler>();
            #endregion

            #region Story Registrations
            services.AddScoped<GetServicesQueryHandler>();
            services.AddScoped<GetServiceByIdQueryHandler>();
            services.AddScoped<UpdateServiceCommandHandler>();
            services.AddScoped<CreateServiceCommandHandler>();
            services.AddScoped<RemoveServiceCommandHandler>();
            #endregion

            #region Promotion Registrations
            services.AddScoped<GetPromotionsQueryHandler>();
            services.AddScoped<GetPromotionByIdQueryHandler>();
            services.AddScoped<UpdatePromotionCommandHandler>();
            services.AddScoped<CreatePromotionCommandHandler>();
            services.AddScoped<RemovePromotionCommandHandler>();
            #endregion

            #region Testimonial Registrations
            services.AddScoped<GetTestimonialsQueryHandler>();
            services.AddScoped<GetTestimonialByIdQueryHandler>();
            services.AddScoped<UpdateTestimonialCommandHandler>();
            services.AddScoped<CreateTestimonialCommandHandler>();
            services.AddScoped<RemoveTestimonialCommandHandler>();
            #endregion

            #region Blog Registrations
            services.AddScoped<GetBlogsQueryHandler>();
            services.AddScoped<GetBlogByIdQueryHandler>();
            services.AddScoped<UpdateBlogCommandHandler>();
            services.AddScoped<CreateBlogCommandHandler>();
            services.AddScoped<RemoveBlogCommandHandler>();
            #endregion

            #region Order Registrations
            services.AddScoped<GetOrdersQueryHandler>();
            services.AddScoped<GetLastOrdersByUserQueryHandler>();
            services.AddScoped<GetOrdersByUserIdQueryHandler>();
            services.AddScoped<GetLastFourOrdersQueryHandler>();
            services.AddScoped<GetOrderByIdQueryHandler>();
            services.AddScoped<GetOrderByUserIdQueryHandler>();
            services.AddScoped<GetTotalOrderPriceQueryHandler>();
            services.AddScoped<GetTotalOrderCountHandler>();
            services.AddScoped<GetTotalOrderCountChangeHandler>();
            services.AddScoped<GetTotalActiveOrderCountHandler>();
            services.AddScoped<GetTotalActiveOrderItemCountHandler>();
            services.AddScoped<GetTotalLastMonthOrderPriceQueryHandler>();
            services.AddScoped<GetTotalPriceLastMonthChangeHandler>();
            services.AddScoped<GetTotalOrderPriceAmountQueryHandler>();
            services.AddScoped<GetTotalPriceChangeHandler>();
            services.AddScoped<UpdateOrderCommandHandler>();
            services.AddScoped<CreateOrderCommandHandler>();
            services.AddScoped<OrderCreatedSubject>();
            services.AddScoped<RemoveOrderCommandHandler>();
            #endregion

            #region OrderItem Registrations
            services.AddScoped<GetOrderItemsQueryHandler>();
            services.AddScoped<GetOrderItemsCountQueryHandler>();
            services.AddScoped<GetOrderItemByIdQueryHandler>();
            services.AddScoped<UpdateOrderItemCommandHandler>();
            services.AddScoped<UpdateOrderItemOrderIdPropertyCommandHandler>();
            services.AddScoped<CreateOrderItemCommandHandler>();
            services.AddScoped<RemoveOrderItemCommandHandler>();
            #endregion

            #region Cart Registrations
            services.AddScoped<GetCartsQueryHandler>();
            services.AddScoped<GetCartByIdQueryHandler>();
            services.AddScoped<GetCartByUserQueryHandler>();
            services.AddScoped<UpdateCartCommandHandler>();
            services.AddScoped<CreateCartCommandHandler>();
            services.AddScoped<RemoveCartCommandHandler>();
            #endregion

            #region User Registrations
            services.AddScoped<GetUsersQueryHandler>();
            services.AddScoped<GetTotalUserCountQueryHandler>();
            services.AddScoped<GetTotalUserChangeHandler>();
            services.AddScoped<GetUserByIdQueryHandler>();
            services.AddScoped<UpdateUserCommandHandler>();
            services.AddScoped<CreateUserCommandHandler>();
            services.AddScoped<RemoveUserCommandHandler>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Mail Registrations
            services.AddScoped<IMailSender, MailSender>();
            #endregion

            #region Log Registrations
            services.AddScoped<IAdminLogService, AdminLogService>();
            services.AddScoped<ICustomerLogService, CustomerLogService>();
            #endregion

            #region AdminLog Registrations
            services.AddScoped<GetAdminLogsQueryHandler>();
            #endregion

            #region CustomerLog Registrations
            services.AddScoped<GetCustomerLogsQueryHandler>();
            #endregion

            #region Contact Registrations
            services.AddScoped<GetContactsQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
            #endregion
        }

        public static void AddPackageExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityCookie";
                config.LoginPath = "/Login/Index";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                config.SlidingExpiration = true;
            });

            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(30);
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
        }
    }
}
