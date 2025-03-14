using MediatR;
using NS.APICore.Extensions;
using NS.APICore.Identity;
using NS.Clientes.API.Data;
using NS.Clients.API.Configuration;
using NS.MessageBus;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAppsettingsEnvironment(builder.Environment);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(typeof(Program));

builder.Services.RegisterServices();

builder.Services.AddMessageBusConfiguration(builder.Configuration);

var app = builder.Build();

app.Services.EnsureCreatedDatabase<ClientsContext>();
      
app.UseSwaggerConfiguration();

app.UseApiConfiguration(builder.Environment);

app.Run();
