using System;
using System.Collections.Generic;

namespace GwentLibrary
{
    public class Card
    {
        #region Fields

        Faction faction;
        CardType cardType;
        string name = "";
        string description = "";

        #endregion

        #region Properties and Builder
        public Card(Faction faction, CardType cardType, string name, string description)
        {
            this.faction = faction;
            this.cardType = cardType;
            this.name = name;
            this.description = description;
        }

        public string Name { get => name; }
        public Faction Faction { get => faction; }
        public CardType CardType { get => cardType; }
        public string Description { get => description; set => description = value; }
        #endregion

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   this.cardType == card.cardType &&
                   this.faction == card.faction &&
                   this.name == card.name;
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
