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
	public class Man_Made_Hive : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Man-Made Hive");
			Tooltip.SetDefault("Not Comsumable\nSummons Queen Bee Indefinitely.\nNothing angers monarchs more than the enslavement of their people.");
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
				return player.ZoneJungle;
			}
			else
			{
				return player.ZoneJungle && !NPC.AnyNPCs(NPCID.QueenBee);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Abeemination, 1);
			recipe.AddIngredient(ItemID.Hive, 10);
			recipe.AddIngredient(ItemID.BottledHoney, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}