using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Projectiles;

namespace witchclass.Content.Items.Weapons.Scrolls
{
    public class ScrollOfFortune : ModItem
    {
		int damage;

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
			damage = 40;
		}

		public override bool? UseItem(Player player) {
			float radius = 2 * 16f;
			SoundEngine.PlaySound(SoundID.Item29, player.position);
            for (int i = 0; i < 5; i++) {
				Vector2 projectilePosition = Main.MouseWorld+new Vector2(Main.rand.Next(-400,400),-500+Main.rand.Next(-1000,0));
                Projectile.NewProjectile(player.GetSource_FromThis(), projectilePosition, projectilePosition.DirectionTo(Main.MouseWorld)*40, ModContent.ProjectileType<FallingStarModified>(), damage, 1, player.whoAmI);
            }

            CreateDustCircle(Main.MouseWorld, radius, 40);

            return true;
        }

        private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.YellowTorch, new Vector2(Main.rand.NextFloat(-0.3f,0.3f),Main.rand.NextFloat(-0.3f,0.3f))); // You can change DustID.MagicMirror to any dust type you like
            }
        }
    }
}
