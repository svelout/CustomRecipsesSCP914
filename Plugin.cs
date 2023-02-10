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
        public override string Prefix => base.Prefix;
        public static Plugin Instance { get; set; }

        private EventHandler eh;
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
            eh = new EventHandler();
            Server.WaitingForPlayers += eh.OnWaitingPlayers;
            SCP914.UpgradingInventoryItem += eh.OnUpgradingInventoryItem;
            SCP914.UpgradingPlayer += eh.OnUpgradingPlayer;
            SCP914.UpgradingPickup += eh.OnUpgradingPickup;
            
        }
        public void OnUnregisterEvents()
        {
            eh = null;
            Server.WaitingForPlayers -= eh.OnWaitingPlayers;
            SCP914.UpgradingInventoryItem -= eh.OnUpgradingInventoryItem;
            SCP914.UpgradingPlayer -= eh.OnUpgradingPlayer;
            SCP914.UpgradingPickup -= eh.OnUpgradingPickup;
        }
    }
}
