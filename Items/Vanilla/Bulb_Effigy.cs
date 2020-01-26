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
	public class Bulb_Effigy : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera's Effigy");
			Tooltip.SetDefault("Not Comsumable\nSummons Plantera Indefinitely.\nIt's an effigy of Plantera's bulb, but made out of mud powered by Chlorophyte.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
	
			item.value = 0;
			item.maxStack = 1;
			item.value = 100;
			item.rare = 7;
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
				return player.ZoneJungle && !NPC.AnyNPCs(NPCID.Plantera);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);

			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.MudBlock, 15);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

