using MedApp.Api.Apis;
using MedApp.Application.Abstractions;
using MedApp.Application.Commands;
using MedApp.Application.DTO;
using MedApp.Application.Extensions;
using MedApp.Application.Queries;
using MedApp.Core.Extensions;
using MedApp.Infrastructure;
using MedApp.Infrastructure.Extensions;
using MedApp.Infrastructure.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

builder.UseSerilog();

var app = builder.Build();

app.UseInfrastructure();

app.UseUsersApi();
app.UsePatientsApi();
app.Run();
