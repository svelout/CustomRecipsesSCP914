using Exiled.API.Features;
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using Scp914;
using System.Collections;
using System.IO;
using Rainbow.Storage.Yaml;
using YamlDotNet.RepresentationModel;

namespace CustomRecipsesSCP914
{
    public class CustomRecipe : Recipe
    {
        private string filename = Plugin.Instance.Config.ConfigFile;
        private List<ItemType> items = new List<ItemType>();
        private List<Scp914KnobSetting> machine_settings = new List<Scp914KnobSetting>();
        public void CreateRecipe(string first_item, string SCP914Setting, string SCP914Mode, string new_item)
        {
            if (Plugin.Instance.Config.new_item == null && Plugin.Instance.Config.SCP914Setting == null & Plugin.Instance.Config.old_item == null)
                Log.Info("Новых рецептов не создано");

        }
        public void ParseYaml(string filename)
        {
            var reader = new StreamReader(filename);
            var yaml = new YamlStream();
            yaml.Load(reader);
        }
    }
    public class Recipe
    {
        public string Name { get; set; }
        public int old_item { get; set; }
        public int _SCP914Settings { get; set; }
        public int _SCP914Mode { get; set; } 
        public int new_something { get; set; }
    }
}
