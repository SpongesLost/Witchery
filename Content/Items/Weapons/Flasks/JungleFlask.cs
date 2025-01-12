using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class JungleFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 11;
			Item.knockBack = 4f;
			Item.crit = 17;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 9f;
			Item.useAnimation = 33;
			Item.useTime = 33;
			Item.value = Item.buyPrice(gold: 1);

			ID = 1;
		}
        public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Vine, 2)
				.AddIngredient(ItemID.Stinger, 3)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}
