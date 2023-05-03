using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VorTextConvos.API.Data;
using VorTextShared.Core.Responses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ////////////////////////

//Add db related services
var cs = builder.Configuration.GetConnectionString("azure");
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));


builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromJson(builder.Configuration.GetValue<string>("FIREBASE_CONFIG"))
}));
builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline. //////////////////

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", [Authorize] (ClaimsPrincipal user) =>
{
    return Results.Json(new SecretMessageResponse() { Message = "Firebase is cool"});
});

app.Run();