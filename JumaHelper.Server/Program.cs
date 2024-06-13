using Microsoft.AspNetCore.Mvc;
using static JumaHelper.Server.Extensions.ConfigurationExtensions;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.Configure();

app.Run();
