using Exiled.API.Interfaces;
using System.ComponentModel;
using Scp914;
using System.Collections.Generic;
using System;
using CustomPlayerEffects;
using Exiled.API.Enums;
using PlayerRoles;

namespace CustomRecipsesSCP914
{
    public class Config : IConfig
    {
        private const string _Item = "";
        [Description("Включить либо выключить плагин")]
        public bool IsEnabled { get; set; } = true;
        [Description("Выключен по дефолту")]
        public bool Debug { get; set; } = false;
        [Description("Имя конфиг файла")]
        public string ConfigFile { get; set; } = "Example.yaml";
        [Description("Рецепты")]
        public List<Recipe> recipes = new List<Recipe>();
    }
}
