var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build()
    ;
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getAll", () =>Results.Ok( new List<string>() 
{ "1", "2"
}));

app.MapGet("/create", (string work) => 
{
    Results.Ok(work);
});

app.Run();
