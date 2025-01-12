using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles
{
	public class AbyssalCircle : ModProjectile
	{
        int frame=0;
        float scale;
		public override void SetDefaults() {
			Projectile.width = 21;
            Projectile.height = 22;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
            Projectile.scale = 1f;
            scale=4f;
		}
        public override void AI()
        {
            float radius = 10 * 16f;

            for (int i = 0; i < Main.npc.Length; i++) {
                NPC targetNPC = Main.npc[i];
                if (targetNPC.active && !targetNPC.boss && targetNPC.CanBeChasedBy())
                {
                    float distanceToPlayer = Vector2.Distance(Projectile.Center, targetNPC.Center);
                    if (distanceToPlayer <= radius) {
                        targetNPC.velocity += (Projectile.Center-targetNPC.Center).SafeNormalize(Vector2.Zero) * Math.Abs(0.8f);
                    }
                }
            }
            Projectile.rotation+=0.03f;
            scale+=(4-scale)/10;
            if (Projectile.timeLeft%40 == 0)
                scale=6f;

            CreateDustCircle(Projectile.Center, radius, 30);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("witchclass/Content/Projectiles/InfinityEffect", AssetRequestMode.ImmediateLoad).Value;
            
            int frameHeight = texture.Height / 61;
            int startY = frameHeight * frame;
            
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = new Vector2(sourceRectangle.Width / 2f, sourceRectangle.Height / 2f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition;
            
            Main.EntitySpriteDraw(texture, drawPos, sourceRectangle, new Color(200,200,200,(int)(scale*30f)), Projectile.rotation, origin+new Vector2(-2,2), scale, SpriteEffects.None, 0f);

            frame=++frame%61;
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.velocity /= 2;
        }

        private void CreateDustCircle(Vector2 center, float radius, int dustCount) {
            for (int i = 0; i < dustCount; i++) {
                float angle = MathHelper.ToRadians(360f / dustCount * i);
                Vector2 dustPosition = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust.NewDustPerfect(dustPosition, DustID.PurpleTorch, new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1)));
            }
        }
    }
}