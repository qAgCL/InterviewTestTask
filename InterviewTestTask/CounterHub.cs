using Microsoft.AspNetCore.SignalR;

namespace InterviewTestTask;

public class CounterHub : Hub
{
    public static int Counter { get; set; }

    public async Task SendRandomValue(int value)
    {
        Counter += value;

        await this.Clients.All.SendAsync("SendRandomValue", Counter);
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("SendRandomValue", Counter);
        
        await base.OnConnectedAsync();
    }
}