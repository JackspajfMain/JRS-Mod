using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using JackspajfsRandomStuff.Items.Banners;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Underground
{
    public class CoolTim : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Tim];

            DisplayName.SetDefault("Cool Tim");
        }
        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 20;
            NPC.defense = 4;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 5000f;
            NPC.aiStyle = 8;
            NPC.alpha = 0;
            NPC.knockBackResist = 0.6f;
            NPC.rarity = 4;
            AIType = NPCID.Tim;
            AnimationType = NPCID.Tim;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<CoolTimBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (spawnInfo.Player.ZoneRockLayerHeight)
                return JackspajfsRandomStuff.UltraRareSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement("What a cool dude.")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(ItemDropRule.Common(ItemID.RuneHat, 1));
        }
    }
}