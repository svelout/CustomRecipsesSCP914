using Exiled.API.Features;
using System;
using System.Collections;
using System.Collections.Generic;
using Scp914;
using System.IO;
using CustomPlayerEffects;
using YamlDotNet.Serialization;
using System.Collections;
using MEC;
using Exiled.API.Enums;
using Exiled.API.Features.Pickups;
using PlayerRoles;

namespace CustomRecipsesSCP914
{
    public class Recipe : Plugin 
    { 
        public ItemType OldItem { get;  set; }
        public int Chance { get; set; }
        public Scp914KnobSetting Setting { get; set; }
        public EffectType NewEffect { get; set; }
        public RoleTypeId NewRole { get; set; }
        public ItemType NewItem { get; set; }
        public float Duration { get; set; }
    }

    public class CustomRecipe : Recipe
    {
        public void InjectConfig()
        {
            string filename = Plugin.Instance.Config.ConfigFile;
            FileStream fileStream = new FileStream(filename, FileMode.Open);
            var deserializer = new Deserializer();
            var result = deserializer.Deserialize<Recipe>(new StringReader(filename));
            if (result != null)
            {
                for (int i = 0; i < fileStream.Length; i++)
                {
                    Plugin.Instance.Config.recipes.Add(new Recipe()
                    {
                        OldItem = result.OldItem,
                        Chance = result.Chance,
                        NewEffect = result.NewEffect,
                        NewRole = result.NewRole,
                        NewItem = result.NewItem
                    });
                }
            }
        }
    }
 } 


