using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events;
using Exiled.Events.EventArgs.Scp914;
using Mono.WebBrowser;
using UnityEngine;
using Log = PluginAPI.Core.Log;
using Random = System.Random;

namespace CustomRecipesSCP914
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            if (Plugin.Instance.Config.Logs)
            {
                Log.Info("Log system enabled");
            }
            else Log.Info("Log system disabled");
            Log.Info($"{Plugin.Instance.Config.Recipes.Count} custom recipes was add in the game");
        }

        public void OnUpgradingPickup(UpgradingPickupEventArgs e)
        {
            if (e.Pickup != null && Plugin.Instance.Config.Recipes.Count > 0 && Plugin.Instance.Config.Recipes.ContainsKey(e.KnobSetting))
            {
                foreach ((ItemType old_item, ItemType new_item, double chance) in Plugin.Instance.Config.Recipes[e.KnobSetting])
                {
                    if (old_item != e.Pickup.Type) continue;
                    if (GetChance(chance))
                    {
                         UpgradeItem(e.Pickup, new_item, e.OutputPosition);
                         e.IsAllowed = false;
                         if (Plugin.Instance.Config.Logs) Log.Info($"Игрок успешно улучшил {e.Pickup.Type} до {new_item} ");
                         break;
                    }
                    if (Plugin.Instance.Config.Logs) Log.Info($"Игрок неудачно {e.Pickup.Type} до {new_item} ");
                }
            }
        }

        private bool GetChance(double chance)
        {
            Random r = new Random();
            if (chance == 0) return false;
            if (chance == 100) return true;
            double chn = r.NextDouble() * 100;
            if (chance >= chn) return true;
            return false;
        }
        private void UpgradeItem(Pickup oldItem, ItemType newItem, Vector3 pos)
        {
            if (newItem != ItemType.None)
            {
                Item item = Item.Create(newItem);
                if (oldItem is FirearmPickup oldFirearm && item is Firearm firearm)
                    firearm.Ammo = oldFirearm.Ammo <= firearm.MaxAmmo ? oldFirearm.Ammo : firearm.MaxAmmo;

                item.CreatePickup(pos);
            }
            oldItem.Destroy();
        }
    }
}