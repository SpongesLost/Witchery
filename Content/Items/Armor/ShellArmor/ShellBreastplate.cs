using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Items.Armor.ShellArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class ShellBreastplate : ModItem
	{
		public static readonly float AdditiveDamageBonus = 3f;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus+"%");

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 4; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.GetDamage<WitchClass>() *= 1f+AdditiveDamageBonus / 100f;
		}
	}
}
