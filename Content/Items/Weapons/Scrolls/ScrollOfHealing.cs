using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Projectiles;

namespace witchclass.Content.Items.Weapons.Scrolls
{
    public class ScrollOfHealing : ModItem
    {
        Random random = new Random();
		int healingAmount = 150;
		bool soundPlayed = false;

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
            float radius = 20 * 16f; // 100 blocks in pixels

            // Heal players within the radius
            for (int i = 0; i < Main.maxPlayers; i++) {
                Player targetPlayer = Main.player[i];
                if (targetPlayer.active && !targetPlayer.dead) {
                    float distanceToPlayer = Vector2.Distance(mouseWorldPosition, targetPlayer.Center);
                    if (distanceToPlayer <= radius) {
                        targetPlayer.statLife += healingAmount;
                        targetPlayer.HealEffect(healingAmount, true);
                    }
                }
            }

            // Create a circle of dust around the healing area
            CreateDustCircle(mouseWorldPosition, radius, 200);

			SoundEngine.PlaySound(SoundID.Item29, player.position);
			

            return true;
        }

        private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.RedTorch, new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1))); // You can change DustID.MagicMirror to any dust type you like
            }
        }

        public override void AddRecipes() {
            CreateRecipe(1)
                .AddIngredient(ItemID.LifeFruit, 3)
                .AddIngredient(ItemID.SoulofFright, 1)
                .AddIngredient(ItemID.SoulofMight, 1)
                .AddIngredient(ItemID.SoulofSight, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
