using Microsoft.AspNet.SignalR;

namespace SignalR_Test
{
    public class ChatHub_All : Hub
    {
        public void HelloToAll(string name)
        {
            Clients.All.addNewMember(name);
        }

        public void SendMessageToAll(string name, string msg)
        {
            Clients.All.AddMessage(name, msg);
        }
    }
}