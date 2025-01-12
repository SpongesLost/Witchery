using witchclass.Content.Projectiles.Brews;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Build.Framework;

namespace witchclass.Content.Items.Ammo
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class CursedBloodBrew : BaseBrew
	{

		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 8; 

			Item.value = Item.sellPrice(0, 0, 1, 0); 
			Item.rare = ItemRarityID.Yellow; 

			Item.shoot = ModContent.ProjectileType<CursedBloodBrewProjectile>();
		}
		public override void AddRecipes() {
			CreateRecipe(25)
				.AddRecipeGroup("evilBars", 8)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
