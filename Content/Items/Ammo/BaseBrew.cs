using witchclass.Content.DamageClasses;
using Terraria;
using Terraria.ModLoader;

namespace witchclass.Content.Items.Ammo
{
	public class BaseBrew : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.width = 10; 
			Item.height = 10; 

			Item.DamageType = ModContent.GetInstance<WitchClass>();

			Item.maxStack = Item.CommonMaxStack; 
			Item.consumable = true; 
			Item.knockBack = 4f; 

			Item.ammo = ModContent.ItemType<BaseBrew>();
		}
    }
}
