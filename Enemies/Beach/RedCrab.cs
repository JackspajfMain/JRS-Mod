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
    public class RedCrab : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Crab];

            DisplayName.SetDefault("Red Crab");
        }
        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 20;
            NPC.damage = 20;
            NPC.defense = 10;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.aiStyle = 3;
            NPC.alpha = 0;
            AIType = NPCID.Crab;
            AnimationType = NPCID.Crab;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<BlackHoleBanner>();
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
                new FlavorTextBestiaryInfoElement("This red hard shelled coastal creature could snip the toes right off a man, among other things. They are not to be trifled with.")
            });
        }

        //public override void ModifyNPCLoot(NPCLoot npcLoot) {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Line>(), 1));
        //}
    }
}