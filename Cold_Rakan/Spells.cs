using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;

namespace Cold_Rakan
{
    internal class Spells
    {
        public static Spell.Skillshot Q;
        public static Spell.Skillshot W;
        public static Spell.Targeted E;
        public static Spell.Active R;
        public static Spell.Targeted Ignite;

        static Spells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 750, SkillShotType.Linear, 0, 150, 75, DamageType.Magical);
            Q.AllowedCollisionCount = 0;
            W = new Spell.Skillshot(SpellSlot.W, 600, SkillShotType.Circular, 0, int.MaxValue, 250, DamageType.Magical);
            W.AllowedCollisionCount = int.MaxValue;
            E = new Spell.Targeted(SpellSlot.W, 550);
            R = new Spell.Active(SpellSlot.R, 200);
            Ignite = new Spell.Targeted(SummonerSpells.Ignite.Slot, 600);
        }

    }
}
