using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles.Brews
{
	public class CursedBloodBrewProjectile : BaseBrewProjectile
	{
		public override void SetDefaults() {
			base.SetDefaults();
			dustID = DustID.RedTorch;
		}
		public override void OnHit()
		{
			base.OnHit();
			SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
			for (int i = 0; i < 50; i++)
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.RedTorch, 0, 0, 0, Scale : 2f);
				dust.velocity += new Vector2(Main.rand.NextFloat(-1,1),Main.rand.NextFloat(-1,1))*6;
			}
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<CursedBloodBrewSpread>(), Projectile.damage/3, 1, Projectile.owner);
			Projectile.Kill();
		}
    }
}