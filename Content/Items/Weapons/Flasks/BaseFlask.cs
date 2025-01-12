using witchclass.Content.Items.Ammo;
using witchclass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using witchclass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace witchclass.Content.Items.Weapons.Flasks
{
	public class BaseFlask : ModItem
	{
		public int ID = 0;
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;

			Item.autoReuse = true;
			Item.DamageType = ModContent.GetInstance<WitchClass>();
			Item.noMelee = true;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.UseSound = SoundID.Item106;
			Item.useStyle = ItemUseStyleID.Shoot;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.useAmmo = ModContent.ItemType<BaseBrew>();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.GetModPlayer<FlaskProperties>().usedFlask = this.GetType().Name;
			player.GetModPlayer<FlaskProperties>().usedFlaskID = ID;
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}
		
	}
}
