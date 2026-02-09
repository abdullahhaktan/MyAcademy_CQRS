using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiFeatureComponent(GetFeaturesQueryHandler getFeaturesQueryHandler, IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await mediator.Send(new GetFeaturesQuery());
            return View(features);
        }
    }
}
