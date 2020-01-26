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
	public class Lunar_Tablet : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Tablet");
			Tooltip.SetDefault("Not Comsumable\nSummons Lunatic Cultist Indefinitely.\nDefeating multiple Cultists will invoke multiple sets of Pillars to spawn\n'Will spark the interest of Lovecraftian Cults.'");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			item.rare = 10;
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
				return NPC.downedGolemBoss;
			}
			else
			{
				return NPC.downedGolemBoss && !NPC.AnyNPCs(NPCID.CultistBoss);
			}
		}

		public override bool UseItem(Player player)
		{
			
			NPC.NewNPC((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, NPCID.CultistBoss);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1101, 10);
			recipe.AddIngredient(2766, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

