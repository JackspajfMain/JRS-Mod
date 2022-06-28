using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Items.Materials
{
    public class Prism : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
