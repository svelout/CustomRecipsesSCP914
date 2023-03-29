using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Scp914 = Exiled.Events.Handlers.Scp914;

namespace CustomRecipesSCP914
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "SveloutDevelop";
        public override string Name => "CustomRecipesSCP914";
        public override string Prefix => "crscp914";

        public static Plugin Instance;
        private EventHandlers _eh;

        public override void OnEnabled()
        {
            Instance = this;
            OnRegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            OnUnRegisterEvents();
            base.OnDisabled();
        }

        public void OnRegisterEvents()
        {
            _eh = new EventHandlers();
            Server.WaitingForPlayers += _eh.OnWaitingForPlayers;
            Exiled.Events.Handlers.Scp914.UpgradingPickup += _eh.OnUpgradingPickup;
        }

        public void OnUnRegisterEvents()
        {
            _eh = null;
            Server.WaitingForPlayers -= _eh.OnWaitingForPlayers;
            Exiled.Events.Handlers.Scp914.UpgradingPickup -= _eh.OnUpgradingPickup;
        }
    }
}