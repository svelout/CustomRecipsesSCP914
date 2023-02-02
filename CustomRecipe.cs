using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Scp914;
using System.IO;
using CustomPlayerEffects;
using YamlDotNet.Serialization;
using System.Collections;
using MEC;
using Exiled.API.Enums;
//public List<Scp914KnobSetting> machine_settings = new List<Scp914KnobSetting>();
//public List<Scp914Mode> _914mode = new List<Scp914Mode>();
//public List<Scp914Sound> _914sound = new List<Scp914Sound>();
//public List<Scp914KnobSetting> result = new List<Scp914KnobSetting>();

namespace CustomRecipsesSCP914
{
    public class Recipe 
    {
        public string Name { get; set; }
        public ItemType old_item { get; set; }
        public EffectType old_effect { get; set; }
        public Scp914KnobSetting _SCP914Settings { get; set; }
        public Scp914Mode _SCP914Mode { get; set; }
        public Scp914Mode scp914Sound { get; set; }
        public EffectType new_effect { get; set; }
        public ItemType new_item { get; set; }
        public bool add { get; set; }
    }
    public class CustomRecipe : Recipe
    {
        private string filename = Plugin.Instance.Config.ConfigFile;
        public List<Recipe> recipes = new List<Recipe>();
        public void InjectConfig(string filename)
        {
            while (add != false)
            {
                var deserializer = new Deserializer();
                var result = deserializer.Deserialize<Recipe>(new StringReader(filename));
            }                           
        }
    }
 } 


