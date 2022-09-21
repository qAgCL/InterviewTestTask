using InterviewTestTask;
using InterviewTestTask.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.Configure<RandomRangeOptions>(builder.Configuration.GetSection("RandomRangeOptions"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CounterHub>("/counter");
});

app.Run();
