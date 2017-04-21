using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Cold_Rakan
{
    class DrawAdmin
    {
        public static void Drawing_OnDraw(EventArgs args)
        {
            if (MenuAdmin.DrawMenu["Use Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.Q.IsReady())
                    Circle.Draw(Color.Aquamarine, Spells.Q.Range, Player.Instance.Position);
            }

            if (MenuAdmin.DrawMenu["Use W"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.W.IsReady())
                Circle.Draw(Color.OrangeRed, Spells.W.Range, Player.Instance.Position);
            }

            if (MenuAdmin.DrawMenu["Use E"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.E.IsReady())
                Circle.Draw(Color.Brown, Spells.E.Range, Player.Instance.Position);
            }

            if (MenuAdmin.DrawMenu["Use R"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.R.IsReady())
                    Circle.Draw(Color.ForestGreen, Spells.E.Range, Player.Instance.Position);
            }
        }

    }
}
