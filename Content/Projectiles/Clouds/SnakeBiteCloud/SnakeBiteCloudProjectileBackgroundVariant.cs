using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace witchclass.Content.Projectiles.Clouds.SnakeBiteCloud
{
    public class SnakeBiteCloudProjectileBackgroundVariant : BaseCloudProjectile
    {
        float movementque = 0f;
        float rotatetby = (random.NextSingle()-0.5f)*2f;
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 38;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 400;
            Projectile.scale = 1.2f;
        }
        public override void SetStaticDefaults(){}
        public override void OnSpawn(IEntitySource source){}
        public override void AI()
        {
            movementque++;
            Projectile.scale += (2.4f-Projectile.scale)/100f;
            Projectile.rotation += MathHelper.ToRadians(rotatetby);
            if (movementque < 30) {
                Projectile.velocity*=new Vector2(1.01f,1.01f);
                Projectile.Opacity = movementque/75f;
            } else {
                Projectile.velocity*=0.97f;
                Projectile.velocity=Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(3));
                Projectile.velocity.Y += random.NextSingle()/200;
                Projectile.Opacity = 0.4f-movementque*(0.4f/400f);
            }
        }
    }
}