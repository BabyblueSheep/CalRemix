﻿using Terraria;
using Terraria.ModLoader;

namespace CalRemix
{
	public class CalRemixJump : ExtraJump
	{
		public override Position GetDefaultPosition() => BeforeBottleJumps;

		public override float GetDurationMultiplier(Player player) 
		{
			return 0.25f;
		}
		public override void OnStarted(Player player, ref bool playSound)
		{
			playSound = false;
        }
	}
}
