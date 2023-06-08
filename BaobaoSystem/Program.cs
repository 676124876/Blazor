using BaobaoSystem.Logics.ILogic;
using BaobaoSystem.Logics.Logic;
using BaobaoSystem.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IBaobaodanLogic, BaobaodanLogic>();
builder.Services.AddTransient<AuthenticationStateProvider, BlazorAuthenticationState>();
// 添加本行代码
builder.Services.AddBootstrapBlazor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
