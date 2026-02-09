using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiServiceComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await mediator.Send(new GetServicesQuery());
            return View(services);
        }
    }
}
