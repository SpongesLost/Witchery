using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles
{
	public class DestructionCircle : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 21;
            Projectile.height = 22;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
		}
        public override void AI()
        {
            float radius = 10 * 16f;
            if (Projectile.timeLeft%4==0)
            {
                Vector2 projectilePosition = Projectile.Center+new Vector2(Main.rand.Next(-400,400),-500+Main.rand.Next(-1000,0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), projectilePosition, projectilePosition.DirectionTo(Projectile.Center+new Vector2(Main.rand.Next((int)-radius,(int)radius),Main.rand.Next((int)-radius,(int)radius)))*30, ModContent.ProjectileType<MeteorProjectile>(), 15, 1, Projectile.owner);
                CreateDustCircle(Projectile.Center, radius, 40);
            }
        }


		private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.Torch, new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1)));
            }
        }
    }
}