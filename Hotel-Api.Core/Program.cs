using Hotel_Api.Core.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();
app.ConfigureApp();