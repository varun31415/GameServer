using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            Server.clients[_fromClient].SendIntoGame(_username);
        }

        public static void PlayerRotation(int _fromClient, Packet _packet)
        {
            Quaternion _rotation = _packet.ReadQuaternion();

            try
            {
                Server.clients[_fromClient].player.SetRotation(_rotation);
            } catch
            {

            }
        }

        public static void PlayerPosition(int _fromClient, Packet _packet)
        {
            Vector3 _position = _packet.ReadVector3();
            try
            {
                Server.clients[_fromClient].player.SetPosition(_position);
            } catch
            {

            }
        }
    }
}