using System.Reflection;
using Home.Api;
using Home.Api.Extensions;
using Home.Api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

#region AutoMapper
builder.Services.AddAutoMapper(mc =>
    {
        mc.ShouldMapProperty = p => p.GetMethod != null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
    }, Assembly.GetExecutingAssembly());
#endregion

#region FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<PurchasePostDTOValidator>();
builder.Services.AddFluentValidationAutoValidation();
#endregion

#region DependencyInjection
builder.Services.AddApplicationServices(Assembly.GetExecutingAssembly());
#endregion

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("x-pagination"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//IDictionary<Type, Type> GetTypes(string nameSpace, string endWith)
//{
//    var res = new Dictionary<Type, Type>();
//    var thisAssembly = Assembly.GetExecutingAssembly();
//    var assemblyTypes = thisAssembly.GetTypes();
//    foreach (var typeImplementation in assemblyTypes
//             .Where(p => p.Name.EndsWith(endWith))
//             .Where(p => !p.Name.Contains("Generic"))
//             .Where(t => string.Equals(t.Namespace, thisAssembly.GetName().Name + "." + nameSpace, StringComparison.Ordinal)))
//        res.Add(assemblyTypes.FirstOrDefault(p => p.Name == "I" + typeImplementation.Name), typeImplementation);

//    return res;
//}

