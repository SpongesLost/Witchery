using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
    public class ClusterGrenade : ModProjectile
    {
        static Random random = new Random();
        public override void SetDefaults()
        {
            Projectile.width = 21;
            Projectile.height = 22;
            Projectile.aiStyle = 0;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 70+Main.rand.Next(-10,30);
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.scale = 1f;
        }

        public override void AI()
        {
            Projectile.velocity.Y += 0.2f;
            Projectile.velocity.X *= 0.98f;
            Projectile.rotation += Projectile.velocity.X/30;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = 6;
            height = 6;
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
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0,-1).RotatedByRandom(MathHelper.ToRadians(120))*6, ModContent.ProjectileType<ClusterGrenadeShard>(), Projectile.damage/2, 0, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<BigExplosion>(), Projectile.damage, 0, Projectile.owner);
        }
    }
}
