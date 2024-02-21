using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Battlefield
    {
        #region Fields
        List<Card> melee = new List<Card>();
        List<Card> range = new List<Card>();
        List<Card> siege = new List<Card>();
        List<Card> graveyard = new List<Card>();
        Bonus[] bonus = new Bonus[3]; //0: melee, 1: range, 2: siege
        #endregion

        #region Properties and Builder
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
        #endregion

        #region Methods
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
        
        public List<object> MostPowerfulCard() //analiza cual es la carta mas poderosa del campo y la devuelve en una lista junto con la fila en la que se encuentra
        {
            Unit unit=null;
            List<Card> list = null;

            foreach (Unit item in this.Melee)
            {
                if (unit==null)
                {
                    unit = item;
                    list = this.Melee;
                }
                else if (unit.Damage < item.Damage)
                {
                    unit = item;
                    list = this.Melee;
                }
            }
            foreach (Unit item in this.Range)
            {
                if (unit == null)
                {
                    unit = item;
                    list = this.Range;
                }
                else if (unit.Damage < item.Damage)
                {
                    unit = item;
                    list = this.Range;
                }
            }
            foreach (Unit item in this.Siege)
            {
                if (unit == null)
                {
                    unit = item;
                    list = this.Siege;
                }
                else if (unit.Damage < item.Damage)
                {
                    unit = item;
                    list = this.Siege;
                }
            }

            return new List<object> { unit, list};
        }
        public List<object> LeastPowerfulCard() //analiza cual es la carta mmenos poderosa del campo y la devuelve en una lista junto con la fila en la que se encuentra
        {
            Unit unit = null;
            List<Card> list = null;

            foreach (Unit item in this.Melee)
            {
                if (unit == null)
                {
                    unit = item;
                    list = this.Melee;
                }
                else if (unit.Damage > item.Damage)
                {
                    unit = item;
                    list = this.Melee;
                }
            }
            foreach (Unit item in this.Range)
            {
                if (unit == null)
                {
                    unit = item;
                    list = this.Range;
                }
                else if (unit.Damage > item.Damage)
                {
                    unit = item;
                    list = this.Range;
                }
            }
            foreach (Unit item in this.Siege)
            {
                if (unit == null)
                {
                    unit = item;
                    list = this.Siege;
                }
                else if (unit.Damage > item.Damage)
                {
                    unit = item;
                    list = this.Siege;
                }
            }

            return new List<object> { unit, list };
        }
        #endregion
    }
}
