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
            InjectConfig();
        }
        Random r = new Random();
        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (ev.Pickup.Type != null)
            {
                foreach (Recipe recipe in Config.recipes)
                {
                    if (ev.Pickup.Type == recipe.old_item)
                    {
                        if (ev.KnobSetting == recipe.setting)
                        {
                            var chance = GetResultFromChance(recipe.chance);
                            if (chance != false)
                            {
                                Upgradeitem(ev.Pickup, recipe.new_item, ev.Scp914.OutputChamber.position);
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
                    if (ev.KnobSetting == recipe.setting && recipe.old_item != null && ev.Item.Type == recipe.old_item)
                    {
                        var chance = GetResultFromChance(recipe.chance);
                        if (chance != false)
                        {
                            ev.Player.RemoveItem(ev.Item);
                            ev.Player.AddItem(recipe.new_item);
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
                    if (recipe.new_effect != null && recipe.duration != 0f && recipe.chance != null)
                    {
                        var chance = GetResultFromChance(recipe.chance);
                        if (chance != false)
                            UpgradingEffect(ev.Player, recipe.new_effect, recipe.duration, ev.OutputPosition);
                    }
                    else if (recipe.new_role != null && recipe.chance != null)
                    {
                        var chance = GetResultFromChance(recipe.chance);
                        if (chance != false)
                            UpdrageRole(ev.Player, recipe.new_role, ev.OutputPosition);
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
                player.Position.Set(pos.x, pos.y, pos.z);
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
