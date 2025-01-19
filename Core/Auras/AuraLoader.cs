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
        private static readonly Dictionary<string, ModAura> _auras = [];
        private static readonly Dictionary<AuraRarity, List<ModAura>> aurasByRarity = new()
        {
            { AuraRarity.Common, [] },
            { AuraRarity.Uncommon, [] },
            { AuraRarity.Rare, [] },
            { AuraRarity.Mythic, [] },
            { AuraRarity.Legendary, [] },
        };

        internal static void Register(ModAura aura)
        {
            _auras[aura.ID] = aura;
            aurasByRarity[aura.Rarity].Add(aura);
        }

        internal static void Unload()
        {
            _auras.Clear();
        }

        /// <summary>
        /// Gets the ModAura instance with the given ID. Returns null if no ModAura with the given ID exists.
        /// </summary>
        public static ModAura GetAura(string id)
        {
            if (_auras.ContainsKey(id))
                return _auras[id];
            return null;
        }

        /// <summary>
        /// Gets a random ModAura instance given a rarity.
        /// </summary>
        /// <param name="rarity">The aura rarity.</param>
        /// <returns>The random ModAura.</returns>
        public static ModAura GetRandomAura(AuraRarity rarity)
        {
            return Main.rand.NextFromCollection(aurasByRarity[rarity]);
        }
    }
}
