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

		public class Clothier_Doll_Lava : ModItem
		{


			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Clothier Voodoo Doll & Lava Bucket");
				Tooltip.SetDefault("Not consumable\nSummons Skeletron Indefinitely.\nThe doll taking a little bit of heat is enough to invoke the curse while keeping the cursed alive.");
				ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;

			}

			public override void SetDefaults()
			{

				item.width = 32;
				item.height = 32;

				item.value = 0;
				item.maxStack = 1;

				item.rare = 2;
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
					return !Main.dayTime && !NPC.AnyNPCs(NPCID.Skeleton);
				}
			}
			
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronHead);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll, 1);
			recipe.AddIngredient(ItemID.LavaBucket, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}