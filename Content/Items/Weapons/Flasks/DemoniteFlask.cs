using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class DemoniteFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 13;
			Item.knockBack = 4f;
			Item.crit = 17;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 10f;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.value = Item.buyPrice(gold: 1);

			ID = 1;
		}
        public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.DemoniteBar, 10)
				.AddIngredient(ItemID.VileMushroom, 5)
				.AddIngredient(ItemID.ShadowScale, 3)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}
