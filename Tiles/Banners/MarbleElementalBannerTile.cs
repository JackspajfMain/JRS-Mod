using Microsoft.Xna.Framework;
using JackspajfsRandomStuff.Items.Banners;
using JackspajfsRandomStuff.Enemies.Marble ;
using Terraria;
//using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace JackspajfsRandomStuff.Tiles.Banners
{
    public class MarbleElementalBannerTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            //TileID.Sets.SwaysInWindBasic[Type] = true; Honestly, fuck wind, seriously, what is up with tmod/terraria being so fucky with it? someone should put in a PR for this shit or something lmao.
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            AddMapEntry(Color.White);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<MarbleGolemBanner>());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.SceneMetrics.hasBanner = true;
                Main.SceneMetrics.NPCBannerBuff[ModContent.NPCType<MarbleElemental>()] = true;
            }
        }
    }
}