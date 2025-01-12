using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles
{
	public class ProtectionCircle : ModProjectile
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
            float radius = 20 * 16f;

            foreach (NPC npc in Main.npc)
            {
                if (npc.boss)
                {
                    Projectile.Kill();
                }
            }

            for (int i = 0; i < Main.projectile.Length; i++) {
                Projectile targetProjectile = Main.projectile[i];
                if (targetProjectile.active) {
                    float distanceToPlayer = Vector2.Distance(Projectile.position, targetProjectile.Center);
                    if (distanceToPlayer <= radius) {
                        targetProjectile.velocity.X *= -1f;
                    }
                }
            }

            CreateDustCircle(Projectile.position, radius, 40);
        }

		private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.BlueTorch, new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1)));
            }
        }
    }
}