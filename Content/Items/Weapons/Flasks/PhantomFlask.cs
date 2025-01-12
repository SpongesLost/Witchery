using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class PhantomFlask : BaseFlask
	{
		public override void SetDefaults() {
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
        public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.SpectreBar, 10)
				.AddIngredient(ItemID.Ectoplasm, 5)
				.AddIngredient(ItemID.BeetleHusk, 2)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
    }
}
