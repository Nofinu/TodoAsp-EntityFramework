using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);


/*
 dans le fichier secret.json connection string qui peu etre mit dans le fichier appsettings.json ou dans les var d'environement
 ver Enviro --> secret.json --> appsetting.json ordre de verification pour le string de connection 
 {
    "ConnectionStrings": {
        "default": "Server=localhost;Database=bdd-test;User ID=root;Password=Root;"
  } 
}

utilisation des package nuggets 
Microsoft.EntityFrameworkCore   //de la version du .Net Utiliser
Microsoft.EntityFrameworkCore.Tools  //de la version du .Net Utiliser
Pomelo.EntityFrameworkCore.MySql  //de la version du .Net Utiliser pour les serveur Mysql


commande dans la console du gestionaire de package :
en 1er :
 add-migration first-migration

en deuxieme :
 update-database
 
 */

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<ToDo>, ToDoRepository>();
string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationDbContext>(option  => option.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}");

app.Run();
