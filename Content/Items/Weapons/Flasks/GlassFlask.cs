using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class GlassFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 8;
			Item.knockBack = 4f;
			Item.crit = 17;
			Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 7f;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.value = Item.buyPrice(gold: 1);

			ID = 0;
		}
		public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.PalmWood, 10)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}
