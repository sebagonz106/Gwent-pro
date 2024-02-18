﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Bait : Card
    {
        public Bait(Faction faction, string name, string description) : base(faction, name, description)
        {
        }

        public void Effect(Player player, List<Card> list, int index)
        {
            Card card = list[index];
            list[index] = this;
            player.Hand[player.Hand.IndexOf(this)] = card;
        }
    }
}
