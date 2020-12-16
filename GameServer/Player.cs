using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace GameServer
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
        }

        /// <summary>Processes player input and moves the player.</summary>
        public void Update()
        {
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }


        /// <summary>Updates the player input with newly received input.</summary>
        /// <param name="_inputs">The new key inputs.</param>
        /// <param name="_rotation">The new rotation.</param>
        public void SetRotation(Quaternion _rotation)
        {
            //Console.Write("Rotation: ");
            //Console.WriteLine(_rotation);
            rotation = _rotation; 
        }

        public void SetPosition(Vector3 _position)
        {
            //Console.Write("Position: ");
            //Console.WriteLine(_position);
            position = _position; 
        }
    }
}
