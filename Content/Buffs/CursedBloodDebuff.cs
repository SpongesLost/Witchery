using witchclass.Content.GlobalNPCs;
using witchclass.Content.Players;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace witchclass.Content.Buffs
{
	/// <summary>
	/// This debuff reduces enemy armor by 25%. Use <see cref="Content.Items.Weapons.HitModifiersShowcase"/> to apply.
	/// By using a buff we can apply to both players and NPCs, and also rely on vanilla to sync the AddBuff calls so we don't need to write our own netcode
	/// </summary>
	public class CursedBloodDebuff : ModBuff
	{
		//public const int DefenseReductionPercent = 25;
		//public static float DefenseMultiplier = 1 - DefenseReductionPercent / 100f;
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<GlobalNPCModification>().CursedBloodDebuff = true; 
		}
	}
}
