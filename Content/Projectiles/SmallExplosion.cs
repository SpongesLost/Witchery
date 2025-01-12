using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using witchclass.Content.Buffs;
using witchclass.Content.DamageClasses;

namespace witchclass.Content.Projectiles
{
    public class SmallExplosion : ModProjectile
    {
        int frame = 0;
        public override void SetDefaults()
        {
            Projectile.width = 150;
            Projectile.height = 150;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
            Projectile.rotation += Main.rand.Next(0,360);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {   
            base.OnHitNPC(target, hit, damageDone);
            if (frame>5)
                Projectile.friendly = false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("witchclass/Content/Projectiles/SmallExplosionAnimation", AssetRequestMode.ImmediateLoad).Value;
            
            int frameHeight = texture.Height / 29;
            int startY = frameHeight * frame;
            
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = new Vector2(sourceRectangle.Width / 2f, sourceRectangle.Height / 2f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition;
            
            Main.EntitySpriteDraw(texture, drawPos, sourceRectangle, Color.White, Projectile.rotation, origin, 0.5f, SpriteEffects.None, 0f);

            if (++frame >= 29)
            {
                Projectile.Kill();
            }
            return false;
        }
    }
}
