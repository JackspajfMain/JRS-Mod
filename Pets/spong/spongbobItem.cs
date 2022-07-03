using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Pets.spong
{
	public class spongbobItem : ModItem //SpongbobItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sad Sponge");
			Tooltip.SetDefault("why he sad tho D:");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish); // Copy the Defaults of the Zephyr Fish Item.

			Item.shoot = ModContent.ProjectileType<spongbobProjectile>(); // "Shoot" your pet projectile.
			Item.buffType = ModContent.BuffType<spongbobBuff>(); // Apply buff upon usage of the Item.
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600);
			}
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(3032)
				.AddIngredient(126)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
