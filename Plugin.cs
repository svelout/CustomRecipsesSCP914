using System;
using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using SCP914 = Exiled.Events.Handlers.Scp914;

namespace CustomRecipsesSCP914
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CustomRecipesSCP914";
        public override string Author => "SveloutDevelop";
        public override string Prefix => "custom_recipes_scp914";
        public static Plugin Instance;

        private EventHandler _eh;
        public override void OnEnabled()
        {
            Instance = this;
            OnRegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            OnUnregisterEvents();
            base.OnDisabled();
        }

        public void OnRegisterEvents()
        {
            _eh = new EventHandler();
            Server.WaitingForPlayers += _eh.OnWaitingPlayers;
            SCP914.UpgradingInventoryItem += _eh.OnUpgradingInventoryItem;
            SCP914.UpgradingPlayer += _eh.OnUpgradingPlayer;
            SCP914.UpgradingPickup += _eh.OnUpgradingPickup;
            
        }
        public void OnUnregisterEvents()
        {
            _eh = null;
            Server.WaitingForPlayers -= _eh.OnWaitingPlayers;
            SCP914.UpgradingInventoryItem -= _eh.OnUpgradingInventoryItem;
            SCP914.UpgradingPlayer -= _eh.OnUpgradingPlayer;
            SCP914.UpgradingPickup -= _eh.OnUpgradingPickup;
        }
    }
}
