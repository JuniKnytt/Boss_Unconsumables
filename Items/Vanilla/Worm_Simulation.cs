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
	public class Worm_Simulation : ModItem
	{
		

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Worm Simulation"); 
			Tooltip.SetDefault("Not consumable\nSummons The Destroyer Indefinitely.\nIt's a computerized simulation of a mechanical worm.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			item.rare = 7;
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
				return !Main.dayTime;
			}
			else
			{
				return !Main.dayTime && !NPC.AnyNPCs(NPCID.TheDestroyer);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
	
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MechanicalWorm);
			recipe.AddIngredient(ItemID.Wire, 10);
			recipe.AddRecipeGroup("IronBar",  5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}