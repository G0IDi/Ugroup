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
        await Clients.Group(groupName).SendAsync("canalMensajes", message);
    }



}