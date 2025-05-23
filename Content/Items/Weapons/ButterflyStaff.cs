using CalamityMod;
using CalRemix.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Weapons;

public class ButterflyStaff : ModItem
{

    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Wooden Butterfly Staff");
        // Tooltip.SetDefault("Summons a butterfly to attack enemies\n" + "Does not consume minion slots\n" + "Only 3 can be summoned at a time\n" + "\'The oldest in butterfly technology\'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 2;
        Item.DamageType = DamageClass.Summon;
        Item.width = 10;
        Item.height = 10;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.noMelee = true;
        Item.knockBack = 0;
        Item.rare = ItemRarityID.Blue;
        Item.Calamity().donorItem = true;
        Item.value = Item.sellPrice(silver:15);
        Item.UseSound = SoundID.Item44;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<ButterflyMinion>();
        Item.shootSpeed = 10f;

    }
    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[ModContent.ProjectileType<ButterflyMinion>()] < 3;
    }
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        damage /= 3;
    }
    public override void AddRecipes()
    {
        CreateRecipe().
            AddRecipeGroup(RecipeGroupID.Wood, 10).
            AddRecipeGroup(RecipeGroupID.Butterflies, 3).
            AddTile(TileID.Anvils).
            Register();
    }

}

