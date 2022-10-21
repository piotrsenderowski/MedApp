using MedApp.Application.Abstractions;
using MedApp.Application.Commands;
using MedApp.Application.DTO;
using MedApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Runtime.CompilerServices;

namespace MedApp.Api.Apis
{
    internal static class PatientsApi
    {
        private const string MeRoute = "me";
        public static WebApplication UsePatientsApi(this WebApplication app)
        {
            string[] allRoles = { "is-admin" };
            app.MapGet("patients", async (IQueryHandler<GetPatients, IEnumerable<PatientDto>> handler) =>
            {
                var query = new GetPatients();
                var patients = await handler.HandleAsync(query);
                return Results.Ok(patients);

            }).RequireAuthorization(allRoles);

            app.MapPost("patients", async (AddPatient command, ICommandHandler<AddPatient> handler) =>
            {
                command = command with { PatientId = Guid.NewGuid() };
                await handler.HandleAsync(command);
                return Results.CreatedAtRoute(MeRoute);
            });

            return app;
        }
    }
}
