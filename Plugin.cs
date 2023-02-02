using System;
using Exiled.API.Features;
using SCP914 = Exiled.Events.Handlers.Scp914;

namespace CustomRecipsesSCP914
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CustomRecipesSCP914";
        public override string Author => "SveloutDevelop";
        public override string Prefix => base.Prefix;
        public static Plugin Instance { get; set; }

        public override void OnEnabled()
        {
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }

        public void OnRegisterEvents()
        {
            
        }
        public void OnUnregisterEvents()
        {
            
        }
    }
}
