using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Core.Auras
{
    public static class AuraLoader
    {
        public static int AuraCount => auras.Count;
        internal static readonly List<ModAura> auras = new List<ModAura>();
        internal static readonly Dictionary<AuraRarity, List<ModAura>> aurasByRarity = new Dictionary<AuraRarity, List<ModAura>>
        {
            { AuraRarity.Common, [] },
            { AuraRarity.Uncommon, [] },
            { AuraRarity.Rare, [] },
            { AuraRarity.Mythic, [] },
            { AuraRarity.Legendary, [] },
        };

        internal static int Add(ModAura aura)
        {
            auras.Add(aura);
            aurasByRarity[aura.Rarity].Add(aura);
            return AuraCount - 1;
        }

        internal static void Unload()
        {
            auras.Clear();
        }

        /// <summary>
        /// Gets the ModDust instance with the given type. Returns null if no ModDust with the given type exists.
        /// </summary>
        public static ModAura GetAura(int type)
        {
            return type >= 0 && type < AuraCount ? auras[type] : null;
        }

        public static ModAura GetRandomAura(AuraRarity rarity)
        {
            return Main.rand.NextFromCollection(aurasByRarity[rarity]);
        }
    }
}
