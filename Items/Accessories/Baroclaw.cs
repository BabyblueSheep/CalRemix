using CalamityMod.Items;
using CalRemix.Projectiles.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;

namespace CalRemix.Items.Accessories
{
    public class Baroclaw : ModItem
    {
        public override string Texture => "CalamityMod/Items/Accessories/Baroclaw";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Baroclaw");
            Tooltip.SetDefault("The crab secret revealed!\n"+"Press x to chain a nearby enemy with crab claws");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 36;
            Item.value = CalamityGlobalItem.Rarity7BuyPrice;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalRemixPlayer modPlayer = player.GetModPlayer<CalRemixPlayer>();
            modPlayer.baroclaw = true;
        }
    }
}
