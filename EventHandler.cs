﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Scp914;
using Exiled.Events.EventArgs.Player;
using Scp914;
using UnityEngine;
using InventorySystem.Items;
using PluginAPI.Enums;
using PlayerRoles;
using Random = System.Random;

namespace CustomRecipsesSCP914
{
    public class EventHandler : CustomRecipe
    {
        public void OnWaitingPlayers()
        {
            InjectConfig();
        }
        Random r = new Random();
        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (ev.Pickup.Type != null)
            {
                foreach (Recipe recipe in Plugin.Instance.Config.recipes)
                {
                    if (ev.Pickup.Type == recipe.old_item)
                    {
                        var chance = GetResultFromChance(recipe.chance);
                        if (chance == true)
                        {
                            Upgradeitem(ev.Pickup, recipe.new_item, ev.Scp914.OutputChamber.position);
                            ev.IsAllowed = false;
                        }
                    }
                }
            }              
        }
        public void OnUpgradingInventoryItem(UpgradingInventoryItemEventArgs ev)
        {
            
        }
        
        public void OnUpgradingPlayer(UpgradingPlayerEventArgs ev)
        {

        }
        public void OnActivating(ActivatingEventArgs ev)
        {
            
        }

        internal void Upgradeitem(Pickup old_item, ItemType newItem, Vector3 pos)
        {
            if (newItem != ItemType.None)
            {
                Item obj = Item.Create(newItem);               
                obj.CreatePickup(pos);
            }
            old_item.Destroy();
        }
        internal void UpdrageRole(Player player, RoleTypeId new_role, Vector3 pos)
        {
            if (player.Role != RoleTypeId.Spectator && player.Role != RoleTypeId.Tutorial)
            {
                player.Role.Set(new_role);
                player.Position = pos;
            }
        }

        internal void UpgradingEffect(Player player, Pickup old_item, EffectType new_effect, float duration, Vector3 pos)
        {
            if (new_effect != null)
            {
                player.EnableEffect(new_effect, duration: duration);
            }
            old_item.Destroy();
        }
        private bool GetResultFromChance(int chance)
        {
            if (chance == 0) return false;
            if (chance == 100) return true;
            int ran = r.Next(100);
            if (ran < chance) return true;
            else return false;          
        }
    }
}
