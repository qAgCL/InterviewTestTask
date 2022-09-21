using Microsoft.AspNetCore.SignalR;

namespace InterviewTestTask;

public class CounterHub : Hub
{
    public static int Counter { get; set; }

    public async Task Send(string message)
    {
        Counter++;

        await this.Clients.All.SendAsync("Send", Counter++);
    }
}