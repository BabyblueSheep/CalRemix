﻿using CalamityMod;
using CalamityMod.Buffs.StatDebuffs;
using CalamityMod.Projectiles.Rogue;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Projectiles
{
    public class WarrowProjectile : ModProjectile
    {
        public override string Texture => "CalRemix/Items/Ammo/WarArrow";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrow");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<ArmorCrunch>(), time);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<ArmorCrunch>(), time);
        }
    }
}