using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Battlefield
    {
        List<Card> melee = new List<Card>();
        List<Card> range = new List<Card>();
        List<Card> siege = new List<Card>();
        List<Card> graveyard = new List<Card>();
        Bonus[] bonus = new Bonus[3]; //0: melee, 1: range, 2: siege

        public Battlefield(List<Card> melee, List<Card> range, List<Card> siege, List<Card> graveyard, Bonus[] bonus)
        {
            this.melee = melee;
            this.range = range;
            this.siege = siege;
            this.graveyard = graveyard;
            this.bonus = bonus;
        }

        public List<Card> Melee { get => melee; set => melee = value; }
        public List<Card> Range { get => range; set => range = value; }
        public List<Card> Siege { get => siege; set => siege = value; }
        public Bonus[] Bonus { get => bonus; set => bonus = value; }
        public List<Card> Graveyard { get => graveyard; set => graveyard = value; }

        public void ToGraveyard(Card card, List<Card> list)
        {
            Graveyard.Add(card);
            list.Remove(card);
        }
        public void Clear()
        {
            this.graveyard.AddRange(melee);
            this.graveyard.AddRange(range);
            this.graveyard.AddRange(siege);
            this.graveyard.AddRange(bonus);
            this.melee.Clear();
            this.range.Clear();
            this.siege.Clear();
            this.bonus = new Bonus[3];
        }
        public double TotalDamage()
        {
            double totalDamage = 0;
            foreach(Card item in Melee)
            {
                if (item is Weather weather) weather.Effect(Melee);
                if (item is Unit unit) totalDamage += bonus[0].Increase*unit.Damage;
            }
            foreach (Card item in Range)
            {
                if (item is Weather weather) weather.Effect(Range);
                if (item is Unit unit) totalDamage += bonus[1].Increase*unit.Damage;
            }
            foreach (Card item in Range)
            {
                if (item is Weather weather) weather.Effect(Siege);
                if (item is Unit unit) totalDamage += bonus[2].Increase * unit.Damage;
            }
            return totalDamage;
        }
    }
}
