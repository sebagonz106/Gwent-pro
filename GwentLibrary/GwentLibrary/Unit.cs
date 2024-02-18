using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Unit : Card
    {
        double damage = 0;
        Level level;
        Effect effect;
        public Unit(Faction faction, string name, string description, double damage, Level level, Effect effect) : base(faction, name, description)
        {
            this.damage = damage;
            this.level = level;
            this.effect = effect;
        }

        public double Damage { get => damage; set => damage = value; }
        public void Effect (params object[] parameters) { effect?.Invoke(parameters); }
    }
}
