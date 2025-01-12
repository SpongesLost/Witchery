using Terraria.ModLoader;
using witchclass.Content.Buffs;

namespace witchclass.Content.Projectiles.Clouds.SnakeBiteCloud
{
    public class SnakeBiteCloudProjectile : BaseCloudProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            InitializeDebuff([ModContent.BuffType<SnakeBiteDebuff>()], [300]);
            penetrateindex = 1;
        }
    }
}