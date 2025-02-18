

using GustovRestaurant.Api.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterDataBase(builder.Configuration)
    .RegisterLibraries()
    .RegisterServices()
    .RegisterRepositories();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        b => b
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed((hosts) => true));
});

var app = builder.Build();

app.UseCors("CORSPolicy");
app.UseSwagger();
app.UseSwagger(g =>
{
    g.SwaggerEndPoint("/swagger/v1/swagger.json", "GustovRestaurantApi v1");
    g.RoutePrefix = "swagger";
    g.EnableFilter();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add endpoints
app.Run();
