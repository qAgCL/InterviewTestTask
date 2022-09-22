using InterviewTestTask.Hubs;
using InterviewTestTask.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.Configure<RandomRangeOptions>(builder.Configuration.GetSection("RandomRangeOptions"));

var app = builder.Build();

app.UseExceptionHandler("/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CounterHub>("/counter");
    endpoints.MapFallbackToPage("/Error");
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();