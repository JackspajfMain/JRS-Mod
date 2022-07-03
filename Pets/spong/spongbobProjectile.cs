using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JackspajfsRandomStuff.Pets.spong
{
	public class spongbobProjectile : ModProjectile //SpongbobProj
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("spongbob");

			Main.projFrames[Projectile.type] = 1;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish); // Copy the stats of the Zephyr Fish

			AIType = ProjectileID.ZephyrFish; // Copy the AI of the Zephyr Fish.
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];

			player.zephyrfish = false; // Relic from aiType

			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<spongbobBuff>()))
			{
				Projectile.timeLeft = 2;
			}
		}
	}
}
