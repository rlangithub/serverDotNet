using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Models.Model;
using DAL.Classes;
using DAL.Intefaces;
//using Microsoft.EntityFrameworkCore.Tools;
string cors = "_cors";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//הזרקת המחלקות
//builder.Services.AddDbContext<UnionTaskContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DfaultDatabase")));
//builder.Services.AddDbContext<Models.Model.UnionTaskContext>(item => item.UseSqlServer("Data Source=DESKTOP-2MHUFJV;Initial Catalog=MyPoject;Integrated Security=SSPI;Trusted_Connection=True;"));
builder.Services.AddDbContext<Models.Model.UnionTaskContext>(options => options.UseSqlServer("Data Source=DESKTOP-2MHUFJV;Initial Catalog=MyPoject;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IDALUser, DALUser>();
builder.Services.AddScoped<IDALToDo, DALToDo>();
builder.Services.AddScoped<IDALPost, DALPost>();
builder.Services.AddScoped<IDALPhoto,DALPhoto>();

builder.Services.AddCors(option =>
{
    option.AddPolicy(cors,
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cors);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
