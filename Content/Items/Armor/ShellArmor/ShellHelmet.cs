using Microsoft.Xna.Framework;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;
using witchclass.Content.Players;

namespace witchclass.Content.Items.Armor.ShellArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class ShellHelmet : ModItem
	{
		public static readonly float brewNegateConsumeChanceBonus = 10f;
		public static readonly float VelocityIncreaseBonus = 5f;
		public static readonly float ShootSpeedBonus = 5f;

		public static LocalizedText SetBonusText { get; private set; }
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(brewNegateConsumeChanceBonus+"%");

		public override void SetStaticDefaults() {
			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(ShootSpeedBonus+"%");
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 3; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<ShellBreastplate>() && legs.type == ModContent.ItemType<ShellLeggings>();
		}
		
		public override void UpdateArmorSet(Player player) {
			player.setBonus = SetBonusText.Value;
			player.GetModPlayer<AccessoryChanges>().velocityIncrease += VelocityIncreaseBonus/100;
			player.GetAttackSpeed<WitchClass>() *= 1f+ShootSpeedBonus/100;
		}

		public override void UpdateEquip(Player player) {
			player.GetModPlayer<AccessoryChanges>().brewNegateConsumeChance += brewNegateConsumeChanceBonus/100f;
		}
	}
}
