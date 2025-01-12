using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
    public class LavaTrailProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60; // Duration of the trail
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255; // Makes the projectile invisible
            Projectile.scale = 2.4f;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(3)) // 33% chance to spawn a lava trail each frame
            {
                Dust dust = Dust.NewDustDirect(Projectile.position+new Vector2(Main.rand.Next(-30,30),Main.rand.Next(-15,15)), Projectile.height, Projectile.width, DustID.Torch, 0, 0, 0);
                dust.velocity += Projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}
