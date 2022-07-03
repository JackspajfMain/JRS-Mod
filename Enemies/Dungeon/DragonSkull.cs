using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using JackspajfsRandomStuff.Items.Banners;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Dungeon
{
    public class DragonSkull : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.DarkCaster];

            DisplayName.SetDefault("Dragon Skull");
        }
        public override void SetDefaults()
        {
            NPC.width = 56;
            NPC.height = 90;
            NPC.damage = 20;
            NPC.defense = 8;
            NPC.lifeMax = 75;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 150f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.aiStyle = 10;
            NPC.alpha = 0;
            NPC.knockBackResist = 1f;
            AIType = NPCID.CursedSkull;
            AnimationType = NPCID.CursedSkull;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<DragonSkullBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (spawnInfo.Player.ZoneDungeon)
                return JackspajfsRandomStuff.CommonSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
                new FlavorTextBestiaryInfoElement("???")
            });
        }

        //public override void ModifyNPCLoot(NPCLoot npcLoot) {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Line>(), 1));
        //}
    }
}