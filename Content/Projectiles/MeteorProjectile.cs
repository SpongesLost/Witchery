using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
	public class MeteorProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        }
		public override void SetDefaults() {
			Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
		}

        public override bool? CanHitNPC(NPC target)
        {
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.velocity = oldVelocity;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
			target.immune[Projectile.owner] = 5;
        }
    }
}