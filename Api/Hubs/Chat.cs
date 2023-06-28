namespace Api.Hubs;

public class Chat : Microsoft.AspNetCore.SignalR.Hub
{

    public async Task JoinGroup(string nombreGrupo)
    {
        //id del usuario
        var id = Context.ConnectionId;
        await Groups.AddToGroupAsync(id, nombreGrupo);
    }

    public async Task LeaveGroup(string groupName)
    {
        
    }

    public async Task SendMessage(string message, string groupName)
    {
        var id = Context.ConnectionId;
        string[] except = { id };
        await Clients.GroupExcept(groupName, except).SendAsync("canalMensajes", message);
    }

    public async Task SendLocation(string location, string groupName)
    {
        var id = Context.ConnectionId;
        string[] except = { id };
        await Clients.GroupExcept(groupName, except).SendAsync("canalLocation", location);
    }

}