using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Players;
using witchclass.Content.Buffs;
using Microsoft.Xna.Framework;
using System;

namespace witchclass.Content.Projectiles.Minion
{
	public class FungiMinion : ModProjectile
	{
		float gravity = 0;
		float projSpeed;
		bool onground;
		public override void SetDefaults() {
			Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 250; // Duration of the trail
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
			Projectile.tileCollide = true;
			Projectile.damage = 5;
		}
		public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override bool PreDraw(ref Color lightColor)
        {

			Projectile.frame += 1;
			Projectile.frame = Projectile.frame%Main.projFrames[Projectile.type];
            return base.PreDraw(ref lightColor);
        }
        public override void AI()
        {
			if (gravity<0.5)
			{
				gravity+=0.05f;
			}
			Projectile.velocity.Y += gravity;
			Projectile.spriteDirection = Projectile.direction*-1;
			float maxDetectRadius = 400f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            projSpeed += (0.2f - projSpeed) / 3f;
            Projectile.velocity.X += (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero).X * projSpeed;
			gravity = closestNPC.Center.Y - Projectile.Center.Y<-20&&onground ? -0.7f : gravity;
			onground=false;
        }
		public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			onground = gravity>0;
			gravity = gravity>0 ? 0 : gravity;
            return false;
        }
    }
}
