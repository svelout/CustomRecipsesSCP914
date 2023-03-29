using System.Collections.Generic;
using Scp914;

namespace CustomRecipesSCP914
{
    public class ItemRecipe
    {
        public ItemType OldItem { get; set; }
        public double Chance { get; set; }
        public ItemType NewItem { get; set; }
        
        public void Deconstruct(out ItemType old_item, out ItemType new_item, out double i)
        {
            old_item = OldItem;
            new_item = NewItem;
            i = Chance;
        }
    }
}    