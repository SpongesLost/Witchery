using Microsoft.Xna.Framework;
using witchclass.Content.Items.Ammo;
using Terraria;
using Terraria.ModLoader;

namespace witchclass.Content.Players
{
    public class FlaskProperties : ModPlayer
    {
        public string usedFlask;
        public int usedFlaskID;
        public override void ResetEffects()
        {
            usedFlask = "";
            usedFlaskID = 0;
        }
    }
}
