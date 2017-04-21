using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;

namespace Cold_Rakan
{
    internal class ComboAdmin
    {
        public static void Combo()
        {
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);

            if (target == null)
            return;

            if (MenuAdmin.ComboMenu["Use Q"].Cast<CheckBox>().CurrentValue)
            {
                var qPred = Spells.Q.GetPrediction(target);

                if (target.IsValidTarget(Spells.Q.Range) && Spells.Q.IsReady() && qPred.HitChance >= HitChance.High)

                    Spells.Q.Cast(target);

                else if (qPred.HitChance == HitChance.Collision)
                {
                    var minionsHit = qPred.CollisionObjects;
                    var closest =
                        minionsHit.Where(m => m.NetworkId != ObjectManager.Player.NetworkId)
                            .OrderBy(m => m.Distance(ObjectManager.Player))
                            .FirstOrDefault();

                    if (closest != null && closest.Distance(qPred.UnitPosition) < 200)
                    {
                        Spells.Q.Cast(qPred.CastPosition);

                    }
                }
            }

            if (MenuAdmin.ComboMenu["Use W"].Cast<CheckBox>().CurrentValue)
            {
                var wPred = Spells.W.GetPrediction(target);

                if (target.IsValidTarget(Spells.W.Range) && Spells.W.IsReady() && wPred.HitChance >= HitChance.High)

                Spells.W.Cast(target);
            }

            if (MenuAdmin.ComboMenu["Use R"].Cast<CheckBox>().CurrentValue)
            {
                Spells.R.Cast(target);
            }

            if (MenuAdmin.ComboMenu["Use Ignite"].Cast<CheckBox>().CurrentValue)
            {
                Spells.Ignite.Cast(target);
            }
        }

    }
}
