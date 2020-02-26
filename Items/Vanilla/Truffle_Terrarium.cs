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
	public class Truffle_Terrarium : ModItem
	{
		

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Truffle Terrarium"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Not consumable\nSummons Duke Fishron Indefinitely.\nJust the scent from this thing is enough to attract pigs.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
	
			item.value = 0;
			item.maxStack = 1;

			item.rare = 9;
			item.useAnimation = 10;
			item.useTime = 10;
			item.useStyle = 4;
			item.consumable = false;
		}
		
		public override bool CanUseItem(Player player)
		{
			
			if (ModContent.GetInstance<Config>().MultiBoss) 
			{
				return player.ZoneBeach;
			}
			else
			{
				return player.ZoneBeach && !NPC.AnyNPCs(NPCID.DukeFishron);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 370);


			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TruffleWorm, 1);
			recipe.AddIngredient(ItemID.GlowingMushroom, 20);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}