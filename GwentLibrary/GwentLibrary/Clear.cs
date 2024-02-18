using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Clear : Card
    {
        List<CardType> availableTypes;
        public Clear(Faction faction, string name, string description, List<CardType> availableTypes) : base(faction, name, description)
        {
            this.availableTypes = availableTypes;
        }
        public void Effect (Player player, List<Card> line)
        {
            foreach (Weather item in line)
            {
                player.Battlefield.ToGraveyard(item, line);
            }
        }
    }
}
