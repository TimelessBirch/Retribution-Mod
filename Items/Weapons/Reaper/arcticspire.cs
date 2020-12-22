using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles.Minions;
using Retribution.Projectiles;

namespace Retribution.Items.Weapons.Reaper
{
	public class ArcticSpire : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ArcticSpire");
			Tooltip.SetDefault("A powerful ice scythe.");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 76;
			item.width = 56;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 3;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			var retributionPlayer = player.GetModPlayer<RetributionPlayer>();

			if (player.altFunctionUse == 2 && retributionPlayer.soulCurrent >= 2)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 50;
				item.crit = 20;
				item.noMelee = true;
				item.melee = false;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = ModContent.ProjectileType<ArcticSpireproj>();
				item.shootSpeed = 25f;

				soulCost = 2;

			}
			else
			{
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 20;
				item.noMelee = false;
				item.melee = true;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = 0;
				item.shootSpeed = 1f;

				soulCost = 0;
			}
			return base.CanUseItem(player);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (player.altFunctionUse == 2)
			{
				{
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					Lighting.AddLight(item.Center, Color.Orange.ToVector3() * 0.98f);
				}
			}
			else
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
				Lighting.AddLight(item.Center, Color.Orange.ToVector3() * 0.98f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}