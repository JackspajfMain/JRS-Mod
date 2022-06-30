//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.GameContent.Bestiary;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Terraria.GameContent;
//using Terraria.GameContent.ItemDropRules;

//Archived for now, F.

//namespace JackspajfsRandomStuff.Enemies.Space
//{
    //public class BlackHole : ModNPC
    //{
        //public override void SetStaticDefaults()
        //{
            //Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Probe];

            //DisplayName.SetDefault("Black Hole");
        //}
        //public override void SetDefaults() {
            //NPC.width = 78;
            //NPC.height = 84;
            //NPC.damage = 14;
            //NPC.defense = 4;
            //NPC.lifeMax = 30;
            //NPC.HitSound = SoundID.NPCHit1;
            //NPC.DeathSound = SoundID.NPCDeath1;
            //NPC.value = 50f;
            //NPC.aiStyle = 5;
            //NPC.alpha = 0;
            //NPC.knockBackResist = 1f;
            //AIType = NPCID.DemonEye;
            //AnimationType = NPCID.Probe;
            //Banner = Item.NPCtoBanner(NPCID.Zombie);
            //BannerItem = Item.BannerToItem(Banner);
        //}

        //public override float SpawnChance(NPCSpawnInfo spawnInfo)
        //{
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            //if (Main.bloodMoon && spawnInfo.Player.ZoneOverworldHeight) 
                //return JackspajfsRandomStuff.UncommonSpawn();
            //return 0f;
        //}

        //public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        //{
            //bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                //BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                //new FlavorTextBestiaryInfoElement("???")
            //});
        //}

        //public override void ModifyNPCLoot(NPCLoot npcLoot) {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Line>(), 1));
        //}
    //}
//}