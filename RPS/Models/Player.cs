using System;

namespace PlayerNS
{
    class Player
    {
        public string Name {get; set;}
        public int[] Stats {get; set;} = {0, 0, 0};
        public string RPSChoice {get; set;}

        public Player(string name)
        {
            Name = name;
        }
    }
}