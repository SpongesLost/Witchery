using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class CrimtaneFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 13;
			Item.knockBack = 4f;
			Item.crit = 17;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 10f;
			Item.useAnimation = 27;
			Item.useTime = 27;
			Item.value = Item.buyPrice(gold: 1);

			ID = 1;
		}
        public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.CrimtaneBar, 10)
				.AddIngredient(ItemID.ViciousMushroom, 5)
				.AddIngredient(ItemID.TissueSample, 3)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}
