using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Weather : Card
    {
        List<CardType> availableTypes;
        public Weather(Faction faction, string name, string description, List<CardType> availableTypes) : base(faction, name, description)
        {
            this.availableTypes = availableTypes;
        }

        public void Effect(List<Card> list, int value = 2)
        {
            foreach (Unit item in list)
            {
                item.Damage -= value;
            }
        }
    }
}
