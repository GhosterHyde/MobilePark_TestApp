using MobilePark_TestApp.Application;
using Polly.Extensions.Http;
using Polly;
using MobilePark_TestApp.Interfaces;
using MobilePark_TestApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<NewsApiDbContext>();

builder.Services.AddSingleton<VowelCountService>();

builder.Services.AddHttpClient<INewsApiClient, NewsApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["NewsApi:Url"]!);
    client.DefaultRequestHeaders.Add("User-Agent", builder.Configuration["NewsApi:User-Agent"]);
    client.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["NewsApi:Token"]);
})
    .AddPolicyHandler(GetRetryPolicy());

var app = builder.Build();

app.MapControllers();

app.Run();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => !msg.IsSuccessStatusCode)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}