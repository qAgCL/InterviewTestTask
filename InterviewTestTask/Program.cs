using InterviewTestTask;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

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
