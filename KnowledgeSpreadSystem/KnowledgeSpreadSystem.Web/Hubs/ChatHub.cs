namespace KnowledgeSpreadSystem.Web.Hubs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KnowledgeSpreadSystem.Web.ChatLogic;

    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        private static readonly ConnectionMapping<string> Connections = new ConnectionMapping<string>();

        public void SendChatMessage(string receiver, string message)
        {
            string name = Context.User.Identity.Name;

            foreach (var connectionId in Connections.GetConnections(receiver))
            {
                Clients.Client(connectionId).addChatMessage(name + ": " + message);
            }
        }

        public IEnumerable<string> GetConnectedUsers()
        {
            return Connections.UniqueConnections.Where(x => !x.Equals(Context.User.Identity.Name));
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Clients.Caller.populateUsers(this.GetConnectedUsers());
            Clients.AllExcept(Context.ConnectionId).userJoined(name);

            Connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            Connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!Connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                Connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}