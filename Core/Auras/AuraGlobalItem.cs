using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalRemix.Core.Auras
{
    public class AuraGlobalItem : GlobalItem
    {
        public List<ModAura> Auras { get; } = [];

        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.accessory;

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            Main.NewText("test");
            Auras.Clear();

            if (rand.NextBool(4))
            {
                Auras.Add(AuraLoader.GetRandomAura(AuraRarity.Uncommon));
            }

            if (rand.NextBool())
            {
                Auras.Add(AuraLoader.GetRandomAura(AuraRarity.Common));
            }

            Main.NewText(Auras.Count);
            return -1;
        }

        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (Auras.Count == 0) return true;
            if (!(line.Mod == "Terraria" && line.Name == "ItemName")) return true;

            string lineText = Auras.First().DisplayName;
            foreach (var aura in Auras.Skip(1))
            {
                lineText = $"{lineText} {aura.DisplayName}";
            }
            lineText = $"{lineText} {line.Text}";
            Utils.DrawBorderString(Main.spriteBatch, lineText, new Vector2(line.X, line.Y), Color.Green);

            return false;
        }
    }
}