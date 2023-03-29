/*
 * It unused code for other config
 */


namespace CustomRecipesSCP914
{
    public class YamlReader
    {
        
        /*
        public static void LoadConfig()
        {
            string file = "recipes_config.yaml";
            int count = -1;
            using (var reader = new StreamReader(file))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            var des = new Deserializer();
            var config = des.Deserialize<Recipes>(file);
            for (int i = 1; i <= count; i++)
            {
                try
                {
                    var recipe = config?.recipe[$"recipe{i}"];
                    Plugin.Instance.Config.Recipes.Add(
                        $"recipes{i}", new Recipe(
                            recipe.OldItem,
                            recipe.Chance,
                            recipe.Setting,
                            recipe.NewItem
                        ));
                    Log.Info($"[{i}|{count}] Recipe loaded!");
                }
                catch (Exception ex) { Log.Error($"Failed to load {i} recipe! Error:\n{ex}");}
            }
        }
        */
    }
}