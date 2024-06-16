using System.Net.Mime;
using ChaquitacllaError404.API.Profiles.Domain.Services;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController(ISubscriptionCommandService subscriptionCommandService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription (CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        if (subscription is null) return BadRequest();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return CreatedAtRoute(new {subscriptionId = subscriptionResource.Id}, subscriptionResource);
    }
}