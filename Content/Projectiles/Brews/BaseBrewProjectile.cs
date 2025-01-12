using Microsoft.Build.Evaluation;
using witchclass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using witchclass.Content.Players;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ReLogic.Content;

namespace witchclass.Content.Projectiles.Brews
{
	public class BaseBrewProjectile : ModProjectile
	{
		public static Random random = new Random();
		int delay = 0;
		int ID;
		string usedFlask;
		public int dustID = DustID.Stone;
		float projSpeed = 0.1f;
		float maxDetectRadius = 400f;
		float oldPlayerpos; 
		public override void SetDefaults() {
			Projectile.width = 10; // The width of projectile hitbox
			Projectile.height = 10; // The height of projectile hitbox
			Projectile.aiStyle = 0;
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = ModContent.GetInstance<WitchClass>();
			Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.alpha = 0; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			Projectile.light = 0.5f; // How much light emit around the projectile
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame
		}
        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
			Player player = Main.player[Projectile.owner];
			ID=player.GetModPlayer<FlaskProperties>().usedFlaskID;
			Projectile.tileCollide = player.GetModPlayer<FlaskProperties>().usedFlask=="PhantomFlask" ? false : true;
			usedFlask = player.GetModPlayer<FlaskProperties>().usedFlask;
			projSpeed = Projectile.velocity.X;
        }
        public override bool PreDraw(ref Color lightColor)
        {
			Player player = Main.player[Projectile.owner];
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			
			int startY = texture.Height * 0;

			Rectangle sourceRectangle = new(0, startY, texture.Width, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2f;
			Vector2 drawPos = Projectile.Center - Main.screenPosition;

			Main.EntitySpriteDraw(texture, drawPos, new Microsoft.Xna.Framework.Rectangle?(sourceRectangle), Color.White, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
			
			texture = ModContent.Request<Texture2D>("witchclass/Content/Projectiles/Brews/BrewProjectileTop", AssetRequestMode.ImmediateLoad).Value;
			
			int frameHeight = texture.Height / 2;
     		startY = frameHeight * ID;

			sourceRectangle = new(0, startY, texture.Width, frameHeight);
			origin = sourceRectangle.Size() / 2f;
			drawPos = Projectile.Center - Main.screenPosition;

			Main.EntitySpriteDraw(texture, drawPos, new Microsoft.Xna.Framework.Rectangle?(sourceRectangle), Color.White, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void AI() 
		{
			delay++;

			if (usedFlask!="ChlorophyteFlask") Projectile.velocity.X *= 0.99f;
			else if (delay < 30) Projectile.velocity.X *= 0.99f;

			if (delay > 30)
				Projectile.velocity.Y += 0.10f;
			Projectile.rotation += Projectile.velocity.X/30;
			
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, dustID, Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += Projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, dustID, 0, 0, 254, Scale: 0.3f);
				dust.velocity += Projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
			if (delay%8==0 && usedFlask=="HellstoneFlask") // 33% chance to spawn a lava trail each frame
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<LavaTrailProjectile>(), Projectile.damage / 2, 0, Projectile.owner);
            }
			if (delay%8==0 && usedFlask=="StarfallFlask") // 33% chance to spawn a lava trail each frame
            {
				float radius = 2 * 16f;
                Vector2 projectilePosition = Projectile.Center+new Vector2(Main.rand.Next(-100,100),-500+Main.rand.Next(-1000,0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), projectilePosition, projectilePosition.DirectionTo(Projectile.Center)*40, ModContent.ProjectileType<FallingStarModified>(), Projectile.damage/2, 1, Projectile.owner);
				CreateDustCircle(Projectile.Center, radius, 10);
            }
			if (usedFlask=="ChlorophyteFlask" && delay>=30)
            {
				NPC closestNPC = FindClosestNPC(maxDetectRadius);
				if (closestNPC == null){
					Projectile.velocity.X *= 0.99f;
					projSpeed = Projectile.velocity.X;
					return;
				}

				if(IsHeadingTowardsOnX(closestNPC))
					Projectile.velocity.X = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero).X * Math.Abs(projSpeed);
            }
		}
		private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.YellowTorch, new Vector2(Main.rand.NextFloat(-0.3f,0.3f),Main.rand.NextFloat(-0.3f,0.3f))); // You can change DustID.MagicMirror to any dust type you like
            }
        }
		private bool IsHeadingTowardsOnX(NPC target)
		{
			float directionToTargetX = target.Center.X - Projectile.Center.X;
			if (directionToTargetX > 0 && Projectile.velocity.X > 0)
				return true;
			else if (directionToTargetX < 0 && Projectile.velocity.X < 0)
				return true;
			return false;
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
			OnHit();
			return false;
		}
		public override void OnHitNPC(NPC npc, NPC.HitInfo hit,int damageDone)
		{
			npc.immune[Projectile.owner] = 0;
			OnHit();
		}

		public virtual void OnHit()
		{
			if (usedFlask=="CrystalFlask")
				for (int i = 0; i < 15; i++)
                	Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1)).RotatedByRandom(MathHelper.ToRadians(360))*16f, ProjectileID.CrystalShard, Projectile.damage / 2, 0, Projectile.owner);
			if (usedFlask=="ExplosiveFlask")
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, -Projectile.velocity.SafeNormalize(Vector2.Zero)*4, ModContent.ProjectileType<ClusterGrenade>(), Projectile.damage, 0, Projectile.owner);
		}
    }
}