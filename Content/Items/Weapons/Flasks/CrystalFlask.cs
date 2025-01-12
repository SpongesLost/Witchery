using Terraria;
using Terraria.ID;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class CrystalFlask : BaseFlask
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 16;
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
				.AddIngredient(ItemID.CrystalShard, 30)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
    }
}
