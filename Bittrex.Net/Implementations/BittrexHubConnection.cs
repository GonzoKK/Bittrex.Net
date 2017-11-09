﻿using Bittrex.Net.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Bittrex.Net.Implementations
{
    public class BittrexHubConnection: IHubConnection
    {
        HubConnection connection;

        public BittrexHubConnection(HubConnection connection)
        {
            this.connection = connection;
        }

        public ConnectionState State => connection.State;
        
        public event Action<StateChange> StateChanged
        {
            add { connection.StateChanged += value; }
            remove { connection.StateChanged -= value; }
        }

        public event Action Closed
        {
            add { connection.Closed += value; }
            remove { connection.Closed -= value; }
        }

        public event Action<Exception> Error
        {
            add { connection.Error += value; }
            remove { connection.Error -= value;  }
        }

        public event Action ConnectionSlow
        {
            add { connection.ConnectionSlow += value; }
            remove { connection.ConnectionSlow -= value; }
        }

        public IHubProxy CreateHubProxy(string hubName)
        {
            return connection.CreateHubProxy(hubName);
        }

        public Task Start()
        {
            return connection.Start();
        }

        public void Stop(TimeSpan timeout)
        {
            connection.Stop(timeout);
        }
    }
}