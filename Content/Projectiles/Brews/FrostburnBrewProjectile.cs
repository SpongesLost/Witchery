using Microsoft.Build.Evaluation;
using witchclass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using witchclass.Content.Projectiles.Clouds.FrostburnCloud;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles.Brews
{
	public class FrostburnBrewProjectile : BaseBrewProjectile
	{
		public override void SetDefaults() {
			base.SetDefaults();
			dustID = DustID.Frost;
		}
		public override void OnHit()
		{
			base.OnHit();
			SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
			Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, -Projectile.velocity*((random.NextSingle()+1f)/7), GoreID.ToxicFlask, 1f);
			Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, -Projectile.velocity*((random.NextSingle()+1f)/7), GoreID.ToxicFlask2, 1f);
			float range = 1.5f;
			int numberOfProjectiles = (int)(20f*range);
			for (int i = 0; i < numberOfProjectiles/3; i++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(random.NextSingle()*range,random.NextSingle()*range).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<FrostburnCloudProjectileBackgroundVariant>(), Projectile.damage/4, 1, Projectile.owner);
			}
			for (int i = 0; i < numberOfProjectiles; i++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(random.NextSingle()*range,random.NextSingle()*range).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<FrostburnCloudProjectile>(), Projectile.damage/4, 1, Projectile.owner);
			}
			Projectile.Kill();
		}
    }
}