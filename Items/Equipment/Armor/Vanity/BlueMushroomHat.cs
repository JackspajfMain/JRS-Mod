using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Items.Equipment.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class BlueMushroomHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blue Mushroom Hat");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(silver: 75);
			Item.vanity = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(4779)
				.AddIngredient(1014)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}