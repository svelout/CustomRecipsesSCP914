using Exiled.API.Interfaces;
using System.ComponentModel;
using Scp914;

namespace CustomRecipsesSCP914
{
    public class Config : IConfig
    {
        [Description("Включить либо выключить плагин")]
        public bool IsEnabled { get; set; } = true;
        [Description("Выключен по дефолту")]
        public bool Debug { get; set; } = false;   
        public string ConfigFile { get; set; } = "FileName";
        public string RecipeName { get; set; } = "RecipeName";
        [Description("Предмет который помещается в SCP-914")]
        public ItemType old_item { get; set; } = ItemType.None;
        [Description("Режим, который установлен на SCP-914, Default: стоит режим 1:1")]
        public Scp914KnobSetting SCP914Setting { get; set; } = Scp914KnobSetting.OneToOne;
        [Description("Как SCP914 будет выдавать предметы")]
        public Scp914Mode Scp914Mode { get; set; } = Scp914Mode.DroppedAndPlayerTeleport;
        [Description("Предмет, который появляется после процесса улучшения")]
        public ItemType new_item { get; set; } = ItemType.None;
    }
}
