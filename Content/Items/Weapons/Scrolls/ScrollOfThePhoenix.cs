using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Players;
using witchclass.Content.Projectiles;

namespace witchclass.Content.Items.Weapons.Scrolls
{
    public class ScrollOfThePhoenix : ModItem
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

        public override bool? UseItem(Player player)
        {
            Vector2 targetPosition = Main.MouseWorld;
            Player deadPlayer = FindNearestDeadPlayer(targetPosition);
            if (deadPlayer != null)
            {
                RevivePlayerAtLocation(deadPlayer);
                SoundEngine.PlaySound(SoundID.Item29, player.position);
                return true;
            }
            return false;
        }

        private Player FindNearestDeadPlayer(Vector2 position)
        {
            Player nearestDeadPlayer = null;
            float nearestDistance = float.MaxValue;

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.dead)
                {
                    float distance = Vector2.Distance(position, player.Center);
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestDeadPlayer = player;
                    }
                }
            }
            return nearestDeadPlayer;
        }

        private void RevivePlayerAtLocation(Player player)
        {
            player.Spawn(PlayerSpawnContext.ReviveFromDeath);
        }

        public override void AddRecipes() {
            CreateRecipe(1)
                .AddIngredient(ItemID.LunarBar, 10)
                .AddIngredient(ModContent.ItemType<ScrollOfHealing>(), 1)
                .AddIngredient(ItemID.SuperHealingPotion, 10)
                .AddIngredient(ItemID.CrystalShard, 50)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
