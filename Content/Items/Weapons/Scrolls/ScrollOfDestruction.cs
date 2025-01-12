using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Projectiles;

namespace witchclass.Content.Items.Weapons.Scrolls
{
    public class ScrollOfDestruction : ModItem
    {

        public override void SetDefaults() {
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 5;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool? UseItem(Player player) {
            Vector2 mouseWorldPosition = Main.MouseWorld;
			SoundEngine.PlaySound(SoundID.Item29, player.position);
			Projectile.NewProjectile(player.GetSource_FromThis(), mouseWorldPosition, Vector2.Zero, ModContent.ProjectileType<DestructionCircle>(), 0, 0, player.whoAmI);
            return true;
        }
    }
}
