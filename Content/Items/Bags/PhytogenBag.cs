﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CalRemix.Content.Items.Weapons;
using CalRemix.Content.Items.Accessories;
using CalRemix.Content.Items.Placeables;
using CalamityMod.Items.Placeables;
using CalRemix.Content.Items.Materials;
using CalRemix.Content.Items.Armor;

namespace CalRemix.Content.Items.Bags
{
    public class PhytogenBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.BossBag[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Cyan;
            Item.expert = true;
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossBags;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Lerp(lightColor, Color.White, 0.4f);
        }
        public override void PostUpdate()
        {
            Item.TreasureBagLightAndDust();
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            return CalamityUtils.DrawTreasureBagInWorld(Item, spriteBatch, ref rotation, ref scale, whoAmI);
        }
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemID.Obsidian, 1, 8, 10);
            itemLoot.Add(ModContent.ItemType<PhytogenMask>(), 7);
            itemLoot.Add(ModContent.ItemType<SoulofPhytogen>());
            itemLoot.Add(ModContent.ItemType<Juicer>());
            itemLoot.Add(ModContent.ItemType<PineappleStaff>());
            itemLoot.AddRevBagAccessories();
        }
    }
}
