using System;
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
            //InjectConfig();
        }
        Random r = new Random();
        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (ev.Pickup.Type != null)
            {
                foreach (Recipe recipe in Config.recipes)
                {
                    if (ev.Pickup.Type == recipe.OldItem)
                    {
                        if (ev.KnobSetting == recipe.Setting)
                        {
                            var chance = GetResultFromChance(recipe.Chance);
                            if (chance != false)
                            {
                                Upgradeitem(ev.Pickup, recipe.NewItem, ev.Scp914.OutputChamber.position);
                                ev.IsAllowed = false;
                                break;
                            }
                            else ev.Pickup.Destroy();
                            break;
                        }
                    }
                    else continue;
                }
            }              
        }
        
        public void OnUpgradingInventoryItem(UpgradingInventoryItemEventArgs ev)
        {
            if (ev.Item != null)
            {
                foreach (Recipe recipe in Config.recipes)
                {
                    if (ev.KnobSetting == recipe.Setting && recipe.OldItem != null && ev.Item.Type == recipe.OldItem)
                    {
                        var chance = GetResultFromChance(recipe.Chance);
                        if (chance != false)
                        {
                            ev.Player.RemoveItem(ev.Item);
                            ev.Player.AddItem(recipe.NewItem);
                            break;
                        }
                    }
                }
            }
        } 
        
        public void OnUpgradingPlayer(UpgradingPlayerEventArgs ev)
        {
            if (ev.Player != null && ev.Player.Role.Side != Side.Scp)
            {
                foreach(Recipe recipe in Config.recipes)
                {
                    if (recipe.NewEffect != null && recipe.Duration != 0f && recipe.Chance != null)
                    {
                        var chance = GetResultFromChance(recipe.Chance);
                        if (chance != false)
                            UpgradingEffect(ev.Player, recipe.NewEffect, recipe.Duration, ev.OutputPosition);
                    }
                    else if (recipe.NewRole != null && recipe.Chance != null)
                    {
                        var chance = GetResultFromChance(recipe.Chance);
                        if (chance != false)
                            UpdrageRole(ev.Player, recipe.NewRole, ev.OutputPosition);
                    }
                }
            }
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

        internal void UpgradingEffect(Player player, EffectType new_effect, float duration, Vector3 pos, Pickup old_item = null)
        {
            bool ds = true;
            if (old_item == null)
                ds = false;
            if (new_effect != null)
            {
                player.EnableEffect(new_effect, duration: duration);
                player.Position = pos;
            }
            if (ds != false)
                old_item.Destroy();
        }
        private bool GetResultFromChance(int chance)
        {
            if (chance == 0) return false;
            if (chance == 100) return true;
            int ran = r.Next(100);
            if (ran <= chance) return true;
            else return false;          
        }
    }
}
