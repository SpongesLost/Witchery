using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace witchclass.Content
{
	public class Recipes : ModSystem
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup gems = new RecipeGroup(() => $"Any Gem", ItemID.Ruby, ItemID.Diamond, ItemID.Topaz, ItemID.Amethyst, ItemID.Amber, ItemID.Sapphire, ItemID.Emerald);
			RecipeGroup.RegisterGroup("Gems", gems);
			RecipeGroup evilBars = new RecipeGroup(() => $"Any Evil Bar", ItemID.CrimtaneBar,ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("evilBars", evilBars);
		}
	}
}