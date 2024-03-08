using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Bonus : Card
    {
        double increase;
        public Bonus(Faction faction, CardType cardType, string name, string description, double bonus) : base(faction, cardType, name, description)
        {
            this.increase = bonus;
        }

        public double Increase { get => increase; }
    }
}
