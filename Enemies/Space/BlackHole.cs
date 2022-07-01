using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using JackspajfsRandomStuff.Items.Banners;
using Terraria.GameContent.ItemDropRules;

//Update: no longer archived. Thanks ZoneSkyHeight.

namespace JackspajfsRandomStuff.Enemies.Space
{
    public class BlackHole : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Probe];

            DisplayName.SetDefault("Black Hole");
        }
        public override void SetDefaults() {
            NPC.width = 78;
            NPC.height = 84;
            NPC.damage = 14;
            NPC.defense = 4;
            NPC.lifeMax = 30;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 50f;
            NPC.aiStyle = 5;
            NPC.alpha = 0;
            NPC.knockBackResist = 1f;
            AIType = NPCID.DemonEye;
            AnimationType = NPCID.Probe;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BlackHoleBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            if (spawnInfo.Player.ZoneSkyHeight) 
                return JackspajfsRandomStuff.CommonSpawn();
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("???")
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