using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Golems
{
    public class CoralGolem : ModNPC
    {
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 10; //Main.npcFrameCount[NPCID.GraniteGolem];

			DisplayName.SetDefault("Coral Golem");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{ // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.GraniteGolem);
			NPC.damage = 35;
			NPC.defense = 15;
			NPC.lifeMax = 130;
			NPC.value = 220f;
			NPC.aiStyle = 3;
			NPC.knockBackResist = 0.35f;
			AIType = NPCID.GoblinScout;
			AnimationType = NPCID.GraniteGolem;
			NPC.buffImmune[BuffID.OnFire] = true;
			NPC.buffImmune[BuffID.OnFire3] = true;
			//Banner = Item.NPCtoBanner(NPCID.Zombie);
			//BannerItem = Item.BannerToItem(Banner);
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.Player.ZoneBeach && spawnInfo.Player.ZoneOverworldHeight && !spawnInfo.PlayerInTown)
				return JackspajfsRandomStuff.CommonSpawn();
			return 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("A mysterious case of something growing from coral. This time, a golem.")
			});
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(169, 10));
			npcLoot.Add(ItemDropRule.Common(ItemID.Coral, 20));
			//Stone golem core
		}

   //     public override void OnHitPlayer(Player target, int damage, bool crit)
   //     {
			//if (Main.rand.NextFloat() <= .33f)
			//	target.AddBuff(BuffID.Chilled, 5*60);
   //     }

		//public override void AI()
		//{
		//	//int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Ice, 0.0f, 0.0f, 200, default(Color), 1.0f);
		//	//Main.dust[dust].velocity *= 0.3f;
		//	if (Main.rand.Next(10) == 0)
		//	{
		//		NPC.position += NPC.netOffset;
		//		int num6 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow);
		//		Main.dust[num6].noGravity = true;
		//		Main.dust[num6].velocity *= 0.1f;
		//		NPC.position -= NPC.netOffset;
		//	}
		//}
	}
}
