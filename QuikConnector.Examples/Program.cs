﻿using System;
using QuikConnector.API;
using QuikConnector.Core;
using QuikConnector.Data;
using QuikConnector.Orders;

namespace QuikConnector.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new ConnectorParameters
            {
                Account = "MyAccount",
                ClientCode = "ClientCode",
                Path = Terminal.GetPathToActiveQuik(),
                SecuritiesTableName = "SecuritiesTable",
                ServerName = "QServer"
            };

            using (QConnector connector = new QConnector(parameters))
            {
                connector.Connected += (sender, e) => { Console.WriteLine("Connected."); };
                connector.ImportStarted += (sender, e) => { Console.WriteLine("Import started."); };

                connector.Connect();
                connector.StartImport();

                connector.SecuritiesTable["LKOH"].Updated += RIM5_Updated;


                Console.ReadLine();

                OrderChannel lkoh = connector.CreateOrderChannel("LKOH", "EQBR");

                OrderResult result = lkoh.SendTransaction(Direction.Buy, 3000, 1);

                lkoh.KillOrder(OrderChannel.TransId, result.OrderNumber);

                Console.ReadLine();
            }

        }

        static void RIM5_Updated(object sender, Data.Channels.Security e)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",  e.ShortName, e.Code, e.Class, e.Bid, e.Ask, e.Price);
        }

    }
}
