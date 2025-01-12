using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class GemFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 9;
			Item.knockBack = 4f;
			Item.crit = 17;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 8f;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.value = Item.buyPrice(gold: 1);

			ID = 1;
		}
        public override void AddRecipes() {
			CreateRecipe(1)
				.AddRecipeGroup("Gems", 10)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}
