using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong_Score.Classes
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void IncreaseScore()
        {
            Score++;
        }

        public string ToString()
        {
            return Name;
        }
    }
}
