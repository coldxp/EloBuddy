using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Spells;
using SharpDX;

namespace Cold_Rakan
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        public static AIHeroClient User = Player.Instance;

        private static Spell.Skillshot Q;
        private static Spell.Skillshot W;
        private static Spell.Targeted E;
        private static Spell.Active R;
        private static Spell.Targeted Ignite;

        private static Menu RakanMenu, ComboMenu, HarassMenu, DrawingsMenu;

        private static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (User.ChampionName != "Rakan")
            {
                return;
            }

            Chat.Print("Cold Rakan BETA [On]");
            Chat.Print("Made by ColdxP");

            Q = new Spell.Skillshot(SpellSlot.Q, 800, SkillShotType.Linear, 25, 1850, 60)
                {AllowedCollisionCount = 0};
            W = new Spell.Skillshot(SpellSlot.W, 600, SkillShotType.Circular, 0, 1500, 300);
            E = new Spell.Targeted(SpellSlot.E, 550);
            R = new Spell.Active(SpellSlot.R, 200);
            Ignite = new Spell.Targeted(SummonerSpells.Ignite.Slot, 600);

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);

            RakanMenu = MainMenu.AddMenu("Cold Rakan", "cRakan");

            ComboMenu = RakanMenu.AddSubMenu("Combo");
            HarassMenu = RakanMenu.AddSubMenu("Harass");
            DrawingsMenu = RakanMenu.AddSubMenu("Drawings");

            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            ComboMenu.Add("Ignite", new CheckBox("Use Ignite")); 

            HarassMenu.Add("Q", new CheckBox("Use Q"));

            foreach (var Spell in SpellList)
            {
                DrawingsMenu.Add(Spell.Slot.ToString(), new CheckBox("Draw" + Spell.Slot));
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Combo))
            {
                Combo();
            }
        }

        private static void Combo()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue && target != null && Q.IsReady())
            {

                var qPred = Q.GetPrediction(target);

                if (qPred.HitChance >= HitChance.High)
                {
                    Q.Cast(qPred.CastPosition);
                }

                else if (qPred.HitChance == HitChance.Collision)
                {
                    var minionsHit = qPred.CollisionObjects;
                    var closest =
                        minionsHit.Where(m => m.NetworkId != ObjectManager.Player.NetworkId)
                            .OrderBy(m => m.Distance(ObjectManager.Player))
                            .FirstOrDefault();

                    if (closest != null && closest.Distance(qPred.UnitPosition) < 200)
                    {
                        Q.Cast(qPred.CastPosition);
                    }
                }
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && target != null && W.IsReady())
            {

                var wPred = W.GetPrediction(target);

                if (wPred.HitChance >= HitChance.High)
                {
                    W.Cast(wPred.CastPosition);
                }
            }

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && target != null && R.IsReady())
            {
                R.Cast(target);
            }

            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
            {
                if (target.IsValidTarget(Ignite.Range) && target.HealthPercent < 15 && Ignite.IsReady())
                {
                    Ignite.Cast(target);
                }
                    
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            foreach (var Spell in SpellList.Where(spell => DrawingsMenu[spell.Slot.ToString()].Cast<CheckBox>().CurrentValue))
            {
                Circle.Draw(Spell.IsReady() ? Color.Chartreuse : Color.OrangeRed, Spell.Range, User);
            }
        }
    }
}
