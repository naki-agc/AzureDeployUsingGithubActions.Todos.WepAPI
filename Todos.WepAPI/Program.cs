using Microsoft.EntityFrameworkCore;
using Todos.WepAPI.Context;
using Todos.WepAPI.Todo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build()
    ;
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getAll", (ApplicationDbContext context) => Results.Ok
(context.Todos.ToList()));

app.MapGet("/create", (ApplicationDbContext context, string work) => 
{
    ToDo toDo = new ToDo()
    {
        Work = work
    };

    context.Add(toDo);
    context.SaveChanges();
    Results.Ok(work);

});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}//her build edilince migrate eder



app.Run();
