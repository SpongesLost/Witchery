using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using witchclass.Content.Players;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Items.Armor.FungiArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class FungiLeggings : ModItem
	{
		static readonly float velocityIncreaseBonus = 10f;
		static readonly float AdditiveDamageBonus = 7f;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(velocityIncreaseBonus+"%");

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 3; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.GetModPlayer<AccessoryChanges>().velocityIncrease += velocityIncreaseBonus / 100;
			player.GetDamage<WitchClass>() *= 1f+AdditiveDamageBonus / 100f;
		}
	}
}
