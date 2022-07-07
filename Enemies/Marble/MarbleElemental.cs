using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using JackspajfsRandomStuff.Items.Banners;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Marble
{
	public class MarbleElemental : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = Main.npcFrameCount[483];

			DisplayName.SetDefault("Marble Elemental");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{ // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}
		public override void SetDefaults()
		{
			NPC.CloneDefaults(483);
			NPC.damage = 30;
			NPC.defense = 18;
			NPC.lifeMax = 110;
			NPC.value = 500f;
			NPC.aiStyle = 91;
			NPC.HitSound = SoundID.NPCHit41;
			NPC.DeathSound = SoundID.NPCDeath43;
			NPC.knockBackResist = 0.35f;
			AIType = 483;
			AnimationType = 483;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<MarbleElementalBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneMarble)
				return JackspajfsRandomStuff.CommonSpawn();
			return 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Marble,
				new FlavorTextBestiaryInfoElement("???")
			});
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(3081, 10));
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

		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode == NetmodeID.Server) return;

			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Marble, hitDirection, -1f);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (NPC.life <= 0)
			{
				for (int i = 0; i < 15; i++)
				{
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Marble, hitDirection, -1f);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
			}
		}
	}
}
