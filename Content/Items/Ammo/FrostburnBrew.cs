using witchclass.Content.Projectiles.Brews;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Items.Ammo
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class FrostburnBrew : BaseBrew
	{

		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 6; 

			Item.value = Item.sellPrice(0, 0, 1, 0); 
			Item.rare = ItemRarityID.Yellow; 

			Item.shoot = ModContent.ProjectileType<FrostburnBrewProjectile>();
		}
		public override void AddRecipes() {
			CreateRecipe(150)
				.AddIngredient(ItemID.IceBlock, 50)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}