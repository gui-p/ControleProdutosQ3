using ControleProdutosQ3.Data;
using ControleProdutosQ3.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy(
        name: "Politica",
        policy =>
        {
            policy.WithOrigins("https://192.168.0.14", "http://localhost")
            .WithMethods("PUT", "DELETE", "GET", "POST")
            .AllowAnyHeader().AllowAnyOrigin();
        }
    ));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
    {
        options.Cookie.Name = ".ControleProdutosQ3.Session";
        options.IdleTimeout = TimeSpan.FromSeconds(999999);
        options.Cookie.IsEssential = true;
    }
);


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

builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();

builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
