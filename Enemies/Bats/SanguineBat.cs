using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;

namespace JackspajfsRandomStuff.Enemies.Bats
{
    public class SanguineBat : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.CaveBat];

            DisplayName.SetDefault("Sanguine Bat");
        }
        public override void SetDefaults() {
            NPC.width = 30;
            NPC.height = 22;
            NPC.damage = 14;
            NPC.defense = 4;
            NPC.lifeMax = 30;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 50f;
            NPC.aiStyle = 14;
            NPC.alpha = 0;
            NPC.knockBackResist = 1f;
            AIType = NPCID.CaveBat;
            AnimationType = NPCID.CaveBat;
            //Banner = Item.NPCtoBanner(NPCID.Zombie);
            //BannerItem = Item.BannerToItem(Banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (Main.bloodMoon && spawnInfo.Player.ZoneOverworldHeight) 
                return JackspajfsRandomStuff.UncommonSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new FlavorTextBestiaryInfoElement("The Sanguine Bat seems to oringinate from bats biting Blood Zombies, turning them into a sanguine-red color.")
            });
        }

        //public override void ModifyNPCLoot(NPCLoot npcLoot) {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Line>(), 1));
        //}

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D Glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            var effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            if (!Main.dayTime && Main.moonPhase != 4)
                spriteBatch.Draw(Glow, NPC.Center - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

            return false;
        }

    }
}