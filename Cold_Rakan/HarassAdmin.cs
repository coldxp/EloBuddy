﻿using System;
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
    internal class HarassAdmin
    {
        public static void Harass()
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
        }
    }
}