using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Stubble.Core.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace CalRemix.Core.Auras
{
    public class AuraGlobalItem : GlobalItem
    {
        /*
        public List<ModAura> Auras { get; } = [];

        public override bool InstancePerEntity => true;
        //public override bool AppliesToEntity(Item entity, bool lateInstantiation) => lateInstantiation && entity.accessory;

        private void GenerateAuras(Item item, UnifiedRandom rand)
        {
            Auras.Clear();

            if (rand.NextBool(4))
            {
                Auras.Add(AuraLoader.GetRandomAura(AuraRarity.Uncommon));
            }

            Auras.Add(AuraLoader.GetRandomAura(AuraRarity.Common));
        }
        */

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            Main.NewText("test");
        }

        /*
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.IsAir) return;
            if (Auras == null) return;
            if (Auras.Count == 0) return;

            TooltipLine nameLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.Mod == "Terraria");
            if (nameLine == null) return;
            string aurasText = "";
            foreach (var aura in Auras)
            {
                aurasText = $"{aurasText} {aura.DisplayName}";
            }
            nameLine.Text = $"{aurasText} {nameLine.Text}";
        }

        public override GlobalItem Clone(Item from, Item to)
        {
            AuraGlobalItem myClone = (AuraGlobalItem)base.Clone(from, to);

            myClone.Auras.Clear();
            foreach (var aura in Auras)
            {
                myClone.Auras.Add(aura);
            }

            return myClone;
        }

        public override void SaveData(Item Item, TagCompound tag)
        {
            tag["Auras"] = Auras;
        }

        public override void LoadData(Item item, TagCompound tag)
        {
            Auras.Clear();
            List<ModAura> auras = tag.Get<List<ModAura>>("Auras");
            foreach (var aura in auras)
            {
                if (aura == null) continue;
                Auras.Add(aura);
            }
        }*/
    }
}