var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {});
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.UseCors("some unique string");
app.Run();
