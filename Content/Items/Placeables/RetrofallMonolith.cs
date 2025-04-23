using CalamityMod;
using CalRemix.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Placeables
{
    public class RetrofallMonolith : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RetrofallMonolithPlaced>(), 0);
            Item.width = 22;
            Item.height = 32;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 25);
            Item.accessory = true;
            Item.vanity = true;
        }

        public override void UpdateEquip(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.GetModPlayer<CalRemixPlayer>().retrofall = true;
            }
        }
        public override void UpdateVanity(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.GetModPlayer<CalRemixPlayer>().retrofall = true;
            }
        }
    }
}
