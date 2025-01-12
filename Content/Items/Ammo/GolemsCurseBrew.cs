using witchclass.Content.Projectiles.Brews;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Items.Ammo
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class GolemsCurseBrew : BaseBrew
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 8; 

			Item.value = Item.sellPrice(0, 0, 1, 0); 
			Item.rare = ItemRarityID.Yellow; 

			Item.shoot = ModContent.ProjectileType<GolemsCurseProjectile>();
		}
		public override void AddRecipes() {
			CreateRecipe(999)
				.AddIngredient(ItemID.LunarTabletFragment, 2)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddIngredient(ItemID.StoneBlock, 10)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
