using witchclass.Content.Projectiles.Clouds.SnakeBiteCloud;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using Terraria.ID;
using witchclass.Content.Projectiles.Minion;
using witchclass.Content.Players;
using Terraria.GameContent.ItemDropRules;
using witchclass.Content.Items.Weapons.Scrolls;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace witchclass.Content.GlobalNPCs
{
	internal class GlobalNPCModification : GlobalNPC
	{
		static Random random = new Random();
		public override bool InstancePerEntity => true;
		public int MoltenBrewDebuffTimer = 0;
		public int CurseOfTheBeesDebuffIndex = 0;
		public int MoltenBrewDebuffIndex = 0;
		public bool GolemsCurse, CursedBloodDebuff, CurseOfTheBeesDebuff, SnakeBiteDebuff, MoltenBrewDebuff;

		public override void ResetEffects(NPC npc)
		{
			GolemsCurse = MoltenBrewDebuff = CurseOfTheBeesDebuff = CursedBloodDebuff = SnakeBiteDebuff = false;
		}

		//public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers) {

		//}
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			base.UpdateLifeRegen(npc, ref damage);
			if (SnakeBiteDebuff)
			{
				npc.lifeRegen -= 36;
				damage = 4;
			}
			if (CursedBloodDebuff)
			{
				npc.lifeRegen -= ((int)(npc.lifeMax * (npc.boss ? 0.01 : 0.1))) / 2;
				damage = (int)(npc.lifeMax * (npc.boss ? 0.2 : 0.4));
			}
			if (GolemsCurse)
			{
				npc.lifeRegen -= 80;
				damage = 10;
			}
		}

		public override void OnKill(NPC npc)
		{
			base.OnKill(npc);
			if (SnakeBiteDebuff)
			{
				SoundEngine.PlaySound(SoundID.Item107, npc.position);
				float range = 0.7f;
				int numberOfProjectiles = (int)(10f * range);
				for (int i = 0; i < numberOfProjectiles / 3; i++)
				{
					Projectile.NewProjectile(npc.GetSource_FromThis(), npc.position, new Vector2(random.NextSingle() * range, random.NextSingle() * range).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<SnakeBiteCloudProjectileBackgroundVariant>(), npc.damage, 1f);
				}
				for (int i = 0; i < numberOfProjectiles; i++)
				{
					Projectile.NewProjectile(npc.GetSource_FromThis(), npc.position, new Vector2(random.NextSingle() * range, random.NextSingle() * range).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<SnakeBiteCloudProjectile>(), npc.damage, 1f);
				}
			}
			
			Player player = Main.player[npc.lastInteraction];
            if (player.GetModPlayer<AccessoryChanges>().fungiArmorOn)
            {
                Projectile.NewProjectile(NPC.GetSource_NaturalSpawn(), npc.position, Vector2.Zero, ModContent.ProjectileType<FungiMinion>(), npc.damage / 2, 0, player.whoAmI);
            }
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			base.DrawEffects(npc, ref drawColor);
			// This simple color effect indicates that the buff is active
			if (SnakeBiteDebuff)
				drawColor = Color.Green;
			if (CursedBloodDebuff)
				drawColor = Color.Red;
			if (CurseOfTheBeesDebuff)
				drawColor = Color.Yellow;
			if (MoltenBrewDebuff)
				drawColor = Color.Orange;
			if (GolemsCurse && !npc.boss)
				drawColor = Color.Gray;
		}

        public override void AI(NPC npc)
		{
			if (CurseOfTheBeesDebuff)
			{
				CurseOfTheBeesDebuffIndex++;
				if (CurseOfTheBeesDebuffIndex > 60)
				{
					float range = 1.5f;
					int numberOfProjectiles = (int)(5f * range);
					for (int i = 0; i < numberOfProjectiles; i++)
					{
						Projectile.NewProjectile(npc.GetSource_FromThis(), npc.position, new Vector2(random.NextSingle() * range, random.NextSingle() * range).RotatedByRandom(MathHelper.ToRadians(360)), ProjectileID.Bee, 8, 4);
					}
					CurseOfTheBeesDebuffIndex = 0;
				}
			}
			if (!MoltenBrewDebuff)
			{
				if (MoltenBrewDebuffIndex == 1){
					npc.SimpleStrikeNPC(MoltenBrewDebuffTimer/6,1);
					//player.addDPS(MoltenBrewDebuffTimer/6);
					MoltenBrewDebuffIndex=0;
				}
				MoltenBrewDebuffTimer = 0;
			} else {
				MoltenBrewDebuffTimer++;
			}
			base.AI(npc);
			if (GolemsCurse && !npc.boss)
				npc.velocity = npc.velocity/1.4f;
		}

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScrollOfFortune>(), 1, 1, 1));
            }
        }
	}
}
