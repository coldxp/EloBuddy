using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;

namespace Cold_Rakan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Rakan")
            {
                return;
            }
            MenuAdmin.CreateMenu();
            Game.OnUpdate += Game_OnGameUpdate;
            Drawing.OnDraw += DrawAdmin.Drawing_OnDraw;
            Chat.Print("Rakan The Simple Charmer made by ColdxP");

        }

        private static void Game_OnGameUpdate(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            ComboAdmin.Combo();

            HarassAdmin.Harass();

        }
    }
}
