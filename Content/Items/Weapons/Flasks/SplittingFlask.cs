using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using witchclass.Content.Players;

namespace witchclass.Content.Items.Weapons.Flasks
{
    public class SplittingFlask : BaseFlask
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 28;
            Item.knockBack = 5.5f;
            Item.crit = 22;
            Item.rare = ItemRarityID.Yellow;
            Item.shootSpeed = 10f;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.value = Item.buyPrice(gold: 1);

            ID = 1;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			player.GetModPlayer<FlaskProperties>().usedFlask = GetType().Name;
			player.GetModPlayer<FlaskProperties>().usedFlaskID = ID;

            float spread = 45f * 0.0174f; 
            float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            double startAngle = Math.Atan2(velocity.X, velocity.Y) - spread / 3;
            double deltaAngle = spread / 3;
            double offsetAngle;

            for (int i = 0; i < 3; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                Projectile.NewProjectile(source, position, new Vector2(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle)), type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.FragmentSolar, 5)
                .AddIngredient(ItemID.FragmentNebula, 5)
                .AddIngredient(ItemID.FragmentVortex, 5)
                .AddIngredient(ItemID.FragmentStardust, 5)
                .AddIngredient(ItemID.SoulofLight, 20)
                .AddIngredient(ItemID.SoulofNight, 20)
                .AddIngredient(ItemID.Bottle, 1)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

    }
}
