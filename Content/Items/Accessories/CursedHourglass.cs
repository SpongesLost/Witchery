using witchclass.Content.DamageClasses;
using witchclass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace witchclass.Content.Items.Accessories
{
	public class CursedHourglass : ModItem
	{
		public static readonly int buffDurationIncreaseBonus = 50;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(buffDurationIncreaseBonus+"%");

		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<AccessoryChanges>().buffDurationIncrease += buffDurationIncreaseBonus;
		}
		public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.Silk, 5)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}