using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using JackspajfsRandomStuff.Items.Banners;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Beach
{
    public class YellowJellyfish : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueJellyfish];

            DisplayName.SetDefault("Yellow Jellyfish");
        }
        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 26;
            NPC.height = 26;
            NPC.aiStyle = 18;
            NPC.damage = 25;
            NPC.defense = 4;
            NPC.lifeMax = 34;
            NPC.HitSound = SoundID.NPCHit25;
            NPC.DeathSound = SoundID.NPCDeath28;
            NPC.value = 100f;
            NPC.alpha = 20;
            AIType = NPCID.BlueJellyfish;
            AnimationType = NPCID.BlueJellyfish;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<YellowJellyfishBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (spawnInfo.Player.ZoneBeach)
                return JackspajfsRandomStuff.CommonSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("???")
            });
        }

         public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Glowstick, 1));
        }
    }
}