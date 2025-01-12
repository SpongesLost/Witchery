using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
    public class ClusterGrenadeShard : ModProjectile
    {
        static Random random = new Random();
        public override void SetDefaults()
        {
            Projectile.width = 21;
            Projectile.height = 22;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 40+Main.rand.Next(-10,90);
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.scale = 1f;
        }

        public override void AI()
        {
            Projectile.velocity.Y += 0.2f;
            Projectile.velocity.X *= 0.97f;
            Projectile.rotation += Projectile.velocity.X/30;
        }
        
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = 4;
            height = 4;
            hitboxCenterFrac = new Vector2(0f, 0f);
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X / 2;
            }
            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y / 2;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.Kill();
        }
        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SmallExplosion>(), Projectile.damage, 0, Projectile.owner);
        }
    }
}
