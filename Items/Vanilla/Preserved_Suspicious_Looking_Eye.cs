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


namespace Boss_Uncomsumables.Items.Vanilla
{
	public class Preserved_Suspicious_Looking_Eye : ModItem
	{
		

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Preserved Suspicious Looking Eye"); 
			Tooltip.SetDefault("Not Comsumable\nSummons Eye of Cthulhu Indefinitely.\nAn eyeball preserved with mushroom vinegar in a jar.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			
			item.value = 0;
			item.maxStack = 1;
		
			item.rare = 1;
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
				return !Main.dayTime && !NPC.AnyNPCs(NPCID.EyeofCthulhu);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SuspiciousLookingEye, 1);
			recipe.AddIngredient(ItemID.Mushroom, 3);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}