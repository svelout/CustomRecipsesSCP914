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
//public List<Scp914KnobSetting> machine_settings = new List<Scp914KnobSetting>();
//public List<Scp914Mode> _914mode = new List<Scp914Mode>();
//public List<Scp914Sound> _914sound = new List<Scp914Sound>();
//public List<Scp914KnobSetting> result = new List<Scp914KnobSetting>();

namespace CustomRecipsesSCP914
{
    public class Recipe : Plugin
    {
        public ItemType old_item { get; set; }
        public int chance { get; set; }
        public EffectType new_effect { get; set; }
        public RoleTypeId new_role { get; set; }
        public ItemType new_item { get; set; }
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
                        old_item = result.old_item,
                        chance = result.chance,
                        new_effect = result.new_effect,
                        new_role = result.new_role,
                        new_item = result.new_item
                    });
                }
            }
        }
    }
 } 


