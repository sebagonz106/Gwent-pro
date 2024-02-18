using System;
using System.Collections.Generic;

namespace GwentLibrary
{
    public class Card
    {
        Faction faction;
        string name = "";
        public string description = "";

        public Card(Faction faction, string name, string description)
        {
            this.faction = faction;
            this.name = name;
            this.description = description;
        }

        public string Name { get => name; }
        public Faction Faction { get => faction; }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   faction == card.faction &&
                   name == card.name;
        }

        public override int GetHashCode()
        {
            var hashCode = -985801978;
            hashCode = hashCode * -1521134295 + faction.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }
    }
}
