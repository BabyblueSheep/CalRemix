using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Core.Scenes
{
    public class SmoothFilterScene : ModSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh + 10;

        public override bool IsSceneEffectActive(Player player)
        {
            return true;//player.GetModPlayer<CalRemixPlayer>().soRetro;
        }

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("CalRemix:SmoothFilter", isActive, player.position);
        }
    }
}
