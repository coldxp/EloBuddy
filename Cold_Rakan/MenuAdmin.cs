using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Cold_Rakan
{
    internal class MenuAdmin
    {
        public static Menu ColdRakan;
        public static Menu DrawMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;

        public static void CreateMenu()
        {
            ColdRakan = MainMenu.AddMenu("Cold_Rakan", "Cold_Rakan");

            ComboMenu = ColdRakan.AddSubMenu("Combo");
            ComboMenu.Add("Q", new CheckBox("Use Q", true));
            ComboMenu.Add("W", new CheckBox("Use W", true));
            ComboMenu.Add("R", new CheckBox("Use R", false));
            ComboMenu.Add("Ignite", new CheckBox("Use Ignite", true));

            HarassMenu = ColdRakan.AddSubMenu("Harass");
            HarassMenu.Add("Q", new CheckBox("Use Q", true));

            DrawMenu = ColdRakan.AddSubMenu("Draw");
            DrawMenu.Add("Q", new CheckBox("Draw Q", true));
            DrawMenu.Add("W", new CheckBox("Draw W", true));
            DrawMenu.Add("E", new CheckBox("Draw E", true));
            DrawMenu.Add("R", new CheckBox("Draw R", true));
        }

    }
}
