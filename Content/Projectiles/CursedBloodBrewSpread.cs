using Terraria;
using Terraria.ModLoader;
using witchclass.Content.Buffs;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
    public class CursedBloodBrewSpread : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 5; // Duration of the trail
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255; // Makes the projectile invisible
            Projectile.scale = 4f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<GolemsCurse>(), 300);
        }
    }
}
