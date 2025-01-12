using Terraria.ID;
using Terraria.ModLoader;
using witchclass.Content.Buffs;

namespace witchclass.Content.Projectiles.Clouds.FrostburnCloud
{
    public class FrostburnCloudProjectile : BaseCloudProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            InitializeDebuff([BuffID.Chilled,BuffID.Frostburn], [300,300]);
            penetrateindex = 1;
        }
    }
}