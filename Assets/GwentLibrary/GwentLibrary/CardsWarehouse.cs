using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    static class CardsWarehouse
    {
        public static object[] ar = { new List<Card>(), new Bonus(Faction.Batista, CardType.Bonus, "Ayuda estadounidense", "", 1.5) };
        static Unit u = new Unit(Faction.Fidel, CardType.Siege, "Celia", "La flor autoctona de la revolucion", 4, Level.Golden, Effects.PlaceBonus);
        static void test()
        {
            u.Effect(ar);
        }
    }
}
