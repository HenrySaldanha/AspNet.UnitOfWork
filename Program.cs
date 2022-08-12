using AspNet.UnitOfWork.Data;
using AspNet.UnitOfWork.Models;
using AspNet.UnitOfWork.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("TodoDatabase"));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.UseSwagger().UseSwaggerUI();


app.MapPost("/users", (IUserRepository repository, IUnitOfWork unitOfWork, [FromBody] IEnumerable <User> Users) =>
{
    try
    {
        foreach (var user in Users)
            repository.Insert(user);

        unitOfWork.Commit();
    }
    catch (Exception)
    {
        unitOfWork.Rollback();
        throw;
    }
   
   
    return Results.Ok(Users);
}).Produces<IEnumerable<User>>(StatusCodes.Status200OK);


app.Run();