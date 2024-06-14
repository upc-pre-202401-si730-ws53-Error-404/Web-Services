using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaquitacllaError404.API.Controls.Interfaces.REST
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ControlsController : ControllerBase
    {
        private readonly IControlCommandService controlCommandService;
        private readonly IControlQueryService controlQueryService;

        public ControlsController(IControlCommandService controlCommandService, IControlQueryService controlQueryService)
        {
            this.controlCommandService = controlCommandService;
            this.controlQueryService = controlQueryService;
        }

        [HttpPost("{sowingId}/controls")]
        public async Task<ActionResult<ControlResource>> CreateControl(int sowingId, [FromBody] CreateControlResource controlResource)
        {
            if (controlResource == null)
            {
                return BadRequest("ControlResource cannot be null.");
            }

            var createControlCommand = CreateControlSourceCommandFromResourceAssembler.ToCommandFromResource(sowingId, controlResource);
            var controlId = await controlCommandService.Handle(createControlCommand);

            if (controlId == 0)
            {
                return BadRequest("Failed to create control.");
            }

            var getControlByIdQuery = new GetControlByIdQuery(controlId);
            var controlOptional = await controlQueryService.Handle(getControlByIdQuery);

            if (controlOptional == null)
            {
                return BadRequest($"Control with id {controlId} not found.");
            }

            var controlResourceResponse = ControlResourceFromEntityAssembler.ToResourceFromEntity(controlOptional);

            return CreatedAtAction(nameof(GetAllControlsByControlId), new { id = controlOptional.Id }, controlResourceResponse);
        }

        [HttpDelete("{sowingId}/controls/{controlId}")]
        public async Task<IActionResult> DeleteControl(int sowingId, int controlId)
        {
            var deleteControlCommand = new DeleteControlCommand(sowingId, controlId);
            await controlCommandService.Handle(deleteControlCommand);
            return Ok("Control with given id successfully deleted");
        }
        
        [HttpGet("{controlId}/controls")]
        public async Task<ActionResult<List<ControlResource>>> GetAllControlsByControlId(int controlId)
        {
            var getAllControlsByControlIdQuery = new GetControlByIdQuery(controlId);
            var controls = await controlQueryService.Handle(getAllControlsByControlIdQuery);
            var controlResources = ControlResourceFromEntityAssembler.ToResourceFromEntity(controls);
            return Ok(controlResources);
        }
    }
}