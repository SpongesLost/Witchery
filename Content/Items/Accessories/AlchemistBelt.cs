using witchclass.Content.DamageClasses;
using witchclass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using witchclass.Content.Items.Weapons.Flasks;

namespace witchclass.Content.Items.Accessories
{
	public class AlchemistBelt : ModItem
	{
		public static readonly float brewNegateConsumeChanceBonus = 5f;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(brewNegateConsumeChanceBonus+"%");
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			//player.GetDamage<WitchClass>() += AdditiveDamageBonus / 100f;
			//player.GetModPlayer<AccessoryChanges>().velocityIncrease = 1+VelocityIncreaseBonus/100;
			player.GetModPlayer<AccessoryChanges>().brewNegateConsumeChance += brewNegateConsumeChanceBonus/100f;
		}
		public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.Hay, 5)
				.AddIngredient(ModContent.ItemType<GlassFlask>(), 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}