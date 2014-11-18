namespace KnowledgeSpreadSystem.Web.ChatLogic
{
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> connections = new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get
            {
                return this.connections.Count;
            }
        }



        public IEnumerable<T> UniqueConnections
        {
            get
            {
                return this.connections.Keys;
            }
        }

        public void Add(T key, string connectionId)
        {
            lock (this.connections)
            {
                HashSet<string> connections;
                if (!this.connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    this.connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (this.connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (this.connections)
            {
                HashSet<string> connections;
                if (!this.connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        this.connections.Remove(key);
                    }
                }
            }
        }
    }
}