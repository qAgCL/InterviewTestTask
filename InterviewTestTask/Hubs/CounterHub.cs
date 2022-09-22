using Microsoft.AspNetCore.SignalR;

namespace InterviewTestTask.Hubs;

public class CounterHub : Hub
{
	public override async Task OnConnectedAsync()
	{
        await Clients.All.SendAsync("GetCurrentCounterAmount", GlobalVariables.CounterAmount);
		await base.OnConnectedAsync();
	}
}