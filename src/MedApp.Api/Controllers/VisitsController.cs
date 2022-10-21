using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using MedApp.Application.DTO;
using MedApp.Application.Commands;
using MedApp.Application.Abstractions;
using MedApp.Application.Queries;
using MedApp.Infrastructure.DAL.Handlers;
using Swashbuckle.AspNetCore.Annotations;

namespace MedApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly ICommandHandler<CreateVisit> _createVisitHandler;
        private readonly ICommandHandler<DeleteVisit> _deleteVisitHandler;
        private readonly IQueryHandler<GetVisits, IEnumerable<VisitDto>> _getVisitsHandler;
        private readonly IQueryHandler<GetVisit, VisitDto> _getVisitHandler;

        public VisitsController(
            ICommandHandler<CreateVisit> createVisitHandler, 
            ICommandHandler<DeleteVisit> deleteVisitHandler, 
            IQueryHandler<GetVisits, IEnumerable<VisitDto>> getVisitsHandler,
            IQueryHandler<GetVisit, VisitDto> getVisitHandler)
        {
            _createVisitHandler = createVisitHandler;
            _deleteVisitHandler = deleteVisitHandler;
            _getVisitsHandler = getVisitsHandler;
            _getVisitHandler = getVisitHandler;
        }

        [HttpGet("{visitId:guid}")]
        [SwaggerOperation("Get single visit by visit ID if exists.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VisitDto>> Get(Guid visitId)
        {
            var query = new GetVisit { VisitId = visitId };
            var userDto = await _getVisitHandler.HandleAsync(query);

            return userDto is null ? NotFound() : Ok(userDto);
        }

        [HttpGet()]
        [SwaggerOperation("Get all visits.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VisitDto>>> Get([FromQuery] GetVisits query)
            => Ok(await _getVisitsHandler.HandleAsync(query));


        [HttpPost()]
        public async Task<ActionResult> Post(CreateVisit command)
        {
            command = command with { VisitId = Guid.NewGuid() };
            await _createVisitHandler.HandleAsync(command);

            return NoContent();
        }


        [HttpDelete("{visitId:guid}")]
        public async Task<ActionResult> Delete(Guid visitId)
        {
            var command = new DeleteVisit(visitId);
            await _deleteVisitHandler.HandleAsync(command);

            return NoContent();
        }
    }
}
