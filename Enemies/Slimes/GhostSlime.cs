using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Slimes
{
    public class GhostSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime];

            DisplayName.SetDefault("Ghost Slime");
        }
        public override void SetDefaults() {
            NPC.width = 24;
            NPC.height = 18;
            NPC.damage = 14;
            NPC.defense = 4;
            NPC.lifeMax = 45;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 50f;
            NPC.aiStyle = 1;
            NPC.alpha = 0;
            NPC.knockBackResist = 1f;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.buffImmune[BuffID.Poisoned] = true;
            //Banner = Item.NPCtoBanner(NPCID.Zombie);
            //BannerItem = Item.BannerToItem(Banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (spawnInfo.Player.ZoneGraveyard && spawnInfo.Player.ZoneOverworldHeight) 
                return JackspajfsRandomStuff.CommonSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,
                new FlavorTextBestiaryInfoElement("A slime that was made from the ghostly spirits of the damned.")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot) {
            var slimeDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.BlueSlime, false);
            foreach (var slimeDropRule in slimeDropRules)
            { 
                npcLoot.Add(slimeDropRule);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.SpectreStaff, hitDirection, -1f);
                dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
                dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);
                dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
            }
        }
     }
}
