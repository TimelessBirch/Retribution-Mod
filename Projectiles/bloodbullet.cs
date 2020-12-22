using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class bloodbullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Bullet");
		}
		public override void SetDefaults()
		{  		
			projectile.width = 2;
			projectile.height = 12;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 1000000;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			aiType = 5;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 3);
		}



		public override void AI()
		{
			Dust dust;
			Vector2 position = projectile.Center;
			dust = Terraria.Dust.NewDustPerfect(position, 273, new Vector2(0f, 0f), 0, new Color(255, 50, 0), 1.118421f);
			dust.noGravity = true;

		}
	}
}