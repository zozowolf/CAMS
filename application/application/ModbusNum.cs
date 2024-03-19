﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NModbus;
using NModbus.Extensions.Enron;
using NModbus.Utility;

namespace application
{
    class ModbusNum
    {
        SQL_command sqlCommand = new SQL_command();
        public void getNumValue()
        {
            using (TcpClient client = new TcpClient("192.168.107.171", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                // read five input values
                ushort startAddress = 16;
                ushort numInputs = 1;

                ushort[] inputs = master.ReadInputRegisters(1, startAddress, numInputs);

                if (inputs.Length > 0)
                {
                    // Assuming you want to add the first input value to a specific channel (e.g., channel ID 1)
                    int channelId = 1;
                    double value = inputs[0];

                    // Call the method to add the value to the database
                    if (value - sqlCommand.GetTotalValeur(channelId) > 0)
                        sqlCommand.AddValueToChannel(channelId, value - sqlCommand.GetTotalValeur(channelId));
                    else
                        sqlCommand.AddValueToChannel(channelId, 0);

                }
            }
        }

        public void RAZ()
        {
            using (TcpClient client = new TcpClient("192.168.107.171", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);
                // Adresse de la bobine à réinitialiser
                ushort coilAddress = 34;
                const int SlaveId = 1;

                // Lecture de l'état actuel de la bobine
                bool currentCoilState = master.ReadCoils(SlaveId, coilAddress, 1)[0];

                // Réinitialisation de la bobine (inversion de l'état)
                master.WriteSingleCoil(SlaveId, coilAddress, !currentCoilState);
            }
        }
    }
}
