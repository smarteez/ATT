using ATTApp.Data.Models;
using ATTApp.Repository.Contracts;
using ATTApp.Repository.Modules;
using ATTApp.Shared;
using ATTApp.UI.Components;
using ATTApp.UseCase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ATTDBContext");
builder.Services.AddDbContext<attContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddScoped<INumberRepository, NumberRepository>();

builder.Services.AddScoped<IsPrime>();
builder.Services.AddScoped<ListToBinary>();
builder.Services.AddScoped<ListToXml>();

builder.Services.AddScoped<EvenNumbersUseCase>();
builder.Services.AddScoped<GetNumberBinaryUseCase>();
builder.Services.AddScoped<GetNumberXMLUseCase>();
builder.Services.AddScoped<LogicUseCase>();
builder.Services.AddScoped<OldNumbersUseCase>();
builder.Services.AddScoped<PrimeNumbersUseCase>();
builder.Services.AddScoped<SaveNumberUseCase>();
builder.Services.AddScoped<SortingUseCase>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
