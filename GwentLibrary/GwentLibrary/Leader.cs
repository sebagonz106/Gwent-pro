using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Leader : Card
    {
        Effect effect;
        public Leader(Faction faction, string name, string description, Effect effect) : base(faction, name, description)
        {
            this.effect = effect;
        }
        public void Effect(params object[] parameters)
        {
            effect?.Invoke(parameters);
        }
    }
}
