using Microsoft.Xna.Framework;
using witchclass.Content.Items.Ammo;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace witchclass.Content.Players
{
    public class AccessoryChanges : ModPlayer
    {
        public float velocityIncrease;
        public int buffDurationIncrease;
        public float brewNegateConsumeChance;
        public bool fungiArmorOn;
        public override void ResetEffects()
        {
            velocityIncrease = 1f;
            buffDurationIncrease = 0;
            brewNegateConsumeChance = 0f;
            fungiArmorOn = false;
        }

        public override void ModifyShootStats(Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity *= velocityIncrease;
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(item, ref damage);
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            if (ammo.type == ModContent.ItemType<BaseBrew>() && Main.rand.NextFloat() < brewNegateConsumeChance)
            {
                return false;
            }
            return true;
        }
    }
}
