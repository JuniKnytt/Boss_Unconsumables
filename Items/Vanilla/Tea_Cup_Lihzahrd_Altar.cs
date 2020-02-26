using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace Boss_Unconsumables.Items.Vanilla
{
	public class Tea_Cup_Lihzahrd_Altar : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Lihzahrd Altar");
			Tooltip.SetDefault("Not consumable\nSummons Golem Indefinitely.\nCan only be used after Plantera is defeated.\n'It's the size of a teacup.'");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			item.rare = 9;
			item.value = 0;
			item.maxStack = 1;
			item.value = 100;

			item.useAnimation = 10;
			item.useTime = 10;
			item.useStyle = 4;
			item.consumable = false;
		}

		public override bool CanUseItem(Player player)
		{

			if (ModContent.GetInstance<Config>().MultiBoss)
			{
				return NPC.downedPlantBoss;
			}
			else
			{
				return NPC.downedPlantBoss && !NPC.AnyNPCs(NPCID.Golem);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 245);
	

			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1293, 1);
			recipe.AddIngredient(2766, 5);
			recipe.AddIngredient(ItemID.SpectreBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

