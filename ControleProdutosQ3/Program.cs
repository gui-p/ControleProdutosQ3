using ControleProdutosQ3.Data;
using ControleProdutosQ3.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddRazorPages()
 .AddMvcOptions(options =>
 {
     options.MaxModelValidationErrors = 50;
     options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
     _ => "Este campo é obrigatório.");
 });


builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
