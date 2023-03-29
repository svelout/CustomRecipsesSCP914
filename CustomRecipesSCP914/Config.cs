using System.Collections.Generic;
using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using Scp914;

namespace CustomRecipesSCP914
{
    public class Config : IConfig
    {
        [Description("Включен ли плагин")] 
        public bool IsEnabled { get; set; } = true;
        [Description("Дебаг")] 
        public bool Debug { get; set; } = false;

        [Description("Логи после того как игрок используется рецепт")]
        public bool Logs { get; set; } = false;

        [Description("Список рецептов")]
        public Dictionary<Scp914KnobSetting, List<ItemRecipe>> Recipes { get; set; } = new()
        {
            {
                Scp914KnobSetting.VeryFine, new List<ItemRecipe>
                {
                    new()
                    {
                        OldItem = ItemType.KeycardO5,
                        Chance = 100,
                        NewItem = ItemType.MicroHID
                    },
                    new()
                    {
                        OldItem = ItemType.KeycardScientist,
                        Chance = 50,
                        NewItem = ItemType.KeycardO5    
                    }
                }
            }
        };
    }
}    
