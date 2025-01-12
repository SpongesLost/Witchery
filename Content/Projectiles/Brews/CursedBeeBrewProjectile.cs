using Microsoft.Build.Evaluation;
using witchclass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using witchclass.Content.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles.Brews
{
	public class CursedBeeBrewProjectile : BaseBrewProjectile
	{
		public override void SetDefaults() {
			base.SetDefaults();
			dustID = DustID.Bee;
		}

		public override void OnHit()
		{
			base.OnHit();
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
			Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, -Projectile.velocity*((random.NextSingle()+1f)/7), GoreID.ToxicFlask, 1f);
			Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, -Projectile.velocity*((random.NextSingle()+1f)/7), GoreID.ToxicFlask2, 1f);
			float range = 1.5f;
			int numberOfProjectiles = (int)(5f*range);
			for (int i = 0; i < numberOfProjectiles; i++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(random.NextSingle()*range,random.NextSingle()*range).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<CursedBee>(), 8, Projectile.owner);
			}
			Projectile.Kill();
		}
    }
}