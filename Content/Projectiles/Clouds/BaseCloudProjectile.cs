using Microsoft.Xna.Framework;
using witchclass.Content.Players;
using witchclass.Content.DamageClasses;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.GameContent;

namespace witchclass.Content.Projectiles.Clouds
{
    public class BaseCloudProjectile : ModProjectile
    {
        public static Random random = new Random();
        private List<int> debuffTypes = new List<int>();
        private List<int> debuffDurations = new List<int>();
        float movementque = 0f;
        float rotatetby = (random.NextSingle() - 0.5f) * 2f;
        float projSpeed = 0f;
        public int penetrateindex;

        public void InitializeDebuff(List<int> debuffTypes, List<int> debuffDurations)
        {
            this.debuffTypes = debuffTypes;
            this.debuffDurations = debuffDurations;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<WitchClass>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300; // 15 seconds * 60 ticks per second
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.scale = 0.8f;
            penetrateindex = 2;
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.frame = random.Next(0, Main.projFrames[Projectile.type]);
        }

        public override void AI()
        {
            movementque++;
            Projectile.scale += (1.6f - Projectile.scale) / 100f;
            Projectile.rotation += MathHelper.ToRadians(rotatetby);
            if (movementque < 30)
            {
                Projectile.velocity *= new Vector2(1.01f, 1.01f);
                if (penetrateindex > 0)
                {
                    Projectile.Opacity = movementque / 40f;
                }
            }
            else
            {
                Projectile.velocity *= 0.97f;
                Projectile.velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.velocity.Y += random.NextSingle() / 100;
                if (penetrateindex > 0)
                {
                    Projectile.Opacity = 0.75f - movementque * (0.75f / 300f);
                }
            }

            if (penetrateindex <= 0)
            {
                Projectile.Opacity *= 0.8f;
                if (Projectile.Opacity < 0.1f)
                {
                    Projectile.Kill();
                }
            }
        /*
            float maxDetectRadius = 400f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            projSpeed += (0.6f - projSpeed) / 40f;
            Projectile.velocity += (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
        */
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            penetrateindex--;
            Player player = Main.player[Projectile.owner];
            for (int i = 0; i < debuffTypes.Count; i++)
            {
                target.AddBuff(debuffTypes[i], debuffDurations[i]+player.GetModPlayer<AccessoryChanges>().buffDurationIncrease);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            base.OnHitPlayer(target, info);
            penetrateindex--;
            Player player = Main.player[Projectile.owner];
            for (int i = 0; i < debuffTypes.Count; i++)
            {
                target.AddBuff(debuffTypes[i], debuffDurations[i]+player.GetModPlayer<AccessoryChanges>().buffDurationIncrease);
            }
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = 6;
            height = 6;
            hitboxCenterFrac = new Vector2(0f, 0f);
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X / (random.NextSingle() * 2 + 0.5f);
            }
            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y / (random.NextSingle() * 2 + 0.5f);
            }
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
    }
}
