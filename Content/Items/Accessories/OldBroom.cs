using witchclass.Content.DamageClasses;
using witchclass.Content.Players;
using witchclass.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using witchclass.Content.Items.Weapons;

namespace witchclass.Content.Items.Accessories
{
	public class OldBroom : ModItem
	{
		// By declaring these here, changing the values will alter the effect, and the tooltip
		static readonly float additiveDamageBonus = 5f;
		static readonly float armorPenetrationBonus = 5f;
		static readonly float attackSpeedBonus = 5f;
		static readonly float knockbackBonus = 5f;
		static readonly float critChanceBonus = 5f;
		static readonly float brewNegateConsumeChanceBonus = 5f;
		static readonly int buffDurationIncreaseBonus = 100;
		static readonly float velocityIncreaseBonus = 10f;

		//public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(additiveDamageBonus+"%",armorPenetrationBonus,attackSpeedBonus+"%",knockbackBonus+"%",critChanceBonus+"%",brewNegateConsumeChanceBonus+"%",buffDurationIncreaseBonus+"%",velocityIncreaseBonus+"%");

		// Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//player.GetDamage<WitchClass>() += additiveDamageBonus / 100f;
			//player.GetArmorPenetration<WitchClass>() += armorPenetrationBonus;
			//player.GetAttackSpeed<WitchClass>() += attackSpeedBonus / 100f;
			//player.GetKnockback<WitchClass>() += knockbackBonus / 100f;
			//player.GetCritChance<WitchClass>()+= critChanceBonus / 100f;
			//player.GetModPlayer<AccessoryChanges>().velocityIncrease += velocityIncreaseBonus / 100;
			//player.GetModPlayer<AccessoryChanges>().brewNegateConsumeChance += brewNegateConsumeChanceBonus/100;
			//player.GetModPlayer<AccessoryChanges>().buffDurationIncrease += buffDurationIncreaseBonus;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.Hay, 5)
				.AddRecipeGroup(RecipeGroupID.Wood, 2)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}