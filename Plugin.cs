using System;
using Exiled.API.Features;

namespace CustomRecipsesSCP914
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CustomRecipesSCP914";
        public override string Author => "SveloutDevelop";
        public override string Prefix => base.Prefix;
        public static Plugin Instance { get; set; }

    }
}
