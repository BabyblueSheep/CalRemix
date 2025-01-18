using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace CalRemix.Core.Auras
{
    /// <summary>
    /// This class allows you to define a custom aura prefix for an item and customize its behavior.
    /// </summary>
    public abstract class ModAura : ModType
    {
        public int Type { get; internal set; }

        public sealed override void SetupContent() => SetStaticDefaults();

        protected sealed override void Register()
        {
            ModTypeLookup<ModAura>.Register(this);
            Type = AuraLoader.Add(this);
        }

        public string DisplayName => Language.GetTextValue($"Mods.{Mod.Name}.Auras.{Name}");

        public virtual AuraRarity Rarity => AuraRarity.Common;

        public virtual void DrawTooltip() { }
    }
}
