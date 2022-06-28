using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Items.Materials
{
    public class Line : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Line");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.material = true;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(copper:10);
        }
    }

}

