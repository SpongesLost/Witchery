using witchclass.Content.Projectiles.Brews;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Items.Ammo
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class SnakeBiteBrew : BaseBrew
	{

		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 8; 

			Item.value = Item.sellPrice(0, 0, 1, 0); 
			Item.rare = ItemRarityID.Yellow; 

			Item.shoot = ModContent.ProjectileType<SnakeBiteBrewProjectile>();
		}
		public override void AddRecipes() {
			CreateRecipe(25)
				.AddIngredient(ItemID.JungleSpores, 3)
				.AddIngredient(ItemID.ChlorophyteBar, 2)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
