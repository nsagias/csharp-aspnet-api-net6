using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
  });
builder.Services.AddCors(options => {});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
  {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nick API V1");
  });

app.UseCors("some unique string");
app.MapGet("/", () => "Hello World!");

app.Run();
