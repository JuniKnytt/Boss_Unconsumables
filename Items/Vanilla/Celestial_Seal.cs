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
	public class Celestial_Seal : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Tablet");
			Tooltip.SetDefault("Not consumable\nSummons Moonlord Indefinitely.\nCan only be used during Lunar Event.\n'After years of pefection, I've finally made a structually sound sigil.'");
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
				return NPC.downedGolemBoss && !NPC.AnyNPCs(NPCID.MoonLordCore);
			}
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.MoonLordCore);

			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialSigil, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

