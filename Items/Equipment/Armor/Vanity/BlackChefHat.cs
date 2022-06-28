using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Items.Equipment.Armor.Vanity
{
	// This tells tModLoader to look for a texture called BlackChefHat_Head, which is the texture on the player
	// and then registers this item to be accepted in head equip slots
	[AutoloadEquip(EquipType.Head)]
	public class BlackChefHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Black Chef Hat");
            Tooltip.SetDefault("This chicken is raw!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;

			// Common values for every boss mask
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(silver: 75);
			Item.vanity = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(4555)
				.AddIngredient(254, 3)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}