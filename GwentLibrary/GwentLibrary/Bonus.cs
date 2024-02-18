using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Bonus : Card
    {
        double increase;
        public Bonus(Faction faction, string name, string description, double bonus) : base(faction, name, description)
        {
            this.increase = bonus;
        }

        public double Increase { get => increase; }
    }
}
