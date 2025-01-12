using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Players;
using witchclass.Content.Buffs;
using Microsoft.Xna.Framework;
using System;

namespace witchclass.Content.Projectiles
{
	public class CursedBee : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bee);
			AIType = ProjectileID.Bee;
			Projectile.penetrate += 1;
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			Player player = Main.player[Projectile.owner];
            target.AddBuff(ModContent.BuffType<CurseOfTheBeesDebuff>(), 300+player.GetModPlayer<AccessoryChanges>().buffDurationIncrease);
            base.OnHitNPC(target, hit, damageDone);
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			// If collide with tile, reduce the penetrate.
			// So the projectile can reflect at most 5 times
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				// If the projectile hits the left or right side of the tile, reverse the X velocity
				if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon) {
					Projectile.velocity.X = -oldVelocity.X;
				}

				// If the projectile hits the top or bottom side of the tile, reverse the Y velocity
				if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}

			return false;
		}
        public override void AI()
        {
            base.AI();
			Projectile.spriteDirection = Projectile.direction*-1;
        }
    }
}
