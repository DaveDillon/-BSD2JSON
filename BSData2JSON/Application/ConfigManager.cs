using BSData2JSON.Models;

namespace BSData2JSON.Application
{
    public class ConfigManager
    {
        private Dictionary<string, ArmyConfig> ArmyConfigs { get; set; }


        public Dictionary<string, ArmyConfig> GetAllConfigs { get { return ArmyConfigs; } }

        public ConfigManager()
        {
            ArmyConfigs = new Dictionary<string, ArmyConfig>()
            {
                {"Aeldari - Aeldari Library" , new ArmyConfig() {
                    ArmyId = 1, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Aeldari - Craftworlds", new ArmyConfig() {
                    ArmyId = 2, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Aeldari - Drukhari", new ArmyConfig() {
                    ArmyId = 3, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Aeldari - Ynnari", new ArmyConfig() {
                    ArmyId = 4, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Chaos - Chaos Daemons Library", new ArmyConfig() {
                    ArmyId = 5, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Chaos Daemons", new ArmyConfig() {
                    ArmyId = 6, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Chaos Knights Library", new ArmyConfig() {
                    ArmyId = 7, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Chaos Knights", new ArmyConfig() {
                    ArmyId = 8, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Chaos Space Marines", new ArmyConfig() {
                    ArmyId = 9, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Death Guard", new ArmyConfig() {
                    ArmyId = 10, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Thousand Sons", new ArmyConfig() {
                    ArmyId = 11, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - Titanicus Traitoris", new ArmyConfig() {
                    ArmyId = 12, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Chaos - World Eaters", new ArmyConfig() {
                    ArmyId = 13, FactionId = (int)Common.Factions.ArmiesOfChaos }
                },
                {"Genestealer Cults", new ArmyConfig() {
                    ArmyId = 14, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Imperium - Adepta Sororitas", new ArmyConfig() {
                    ArmyId = 15, FactionId = (int)Common.Factions.ArmiesOfTheImperium }
                },
                {"Imperium - Adeptus Custodes", new ArmyConfig() {
                    ArmyId = 16, FactionId = (int)Common.Factions.ArmiesOfTheImperium }
                },
                {"Imperium - Adeptus Mechanicus", new ArmyConfig() {
                    ArmyId = 17, FactionId = (int)Common.Factions.ArmiesOfTheImperium }
                },
                {"Imperium - Adeptus Titanicus", new ArmyConfig() {
                    ArmyId = 18, FactionId = (int)Common.Factions.ArmiesOfTheImperium }
                },
                //{"Imperium - Agents of the Imperium", new ArmyConfig() {
                //    ArmyId = 19, FactionId = Common.Factions.ArmiesOfTheImperium }
                //},
                //{"Imperium - Astra Militarum - Library", new ArmyConfig() {
                //    ArmyId = 20, FactionId = Common.Factions.ArmiesOfTheImperium }
                //},
                {"Imperium - Astra Militarum", new ArmyConfig() {
                    ArmyId = 21, FactionId = (int)Common.Factions.ArmiesOfTheImperium }
                },
                {"Imperium - Black Templars", new ArmyConfig() {
                    ArmyId = 22, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Blood Angels", new ArmyConfig() {
                    ArmyId = 23, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Dark Angels", new ArmyConfig() {
                    ArmyId = 24, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Deathwatch", new ArmyConfig() {
                    ArmyId = 25, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Grey Knights", new ArmyConfig() {
                    ArmyId = 26, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Imperial Fists", new ArmyConfig() {
                    ArmyId = 27, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Imperial Knights - Library", new ArmyConfig() {
                    ArmyId = 28, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Imperial Knights", new ArmyConfig() {
                    ArmyId = 29, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Iron Hands", new ArmyConfig() {
                    ArmyId = 30, FactionId = (int) Common.Factions.SpaceMarines }
                },
                {"Imperium - Raven Guard", new ArmyConfig() {
                    ArmyId = 31, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Salamanders", new ArmyConfig() {
                    ArmyId = 32, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Space Marines", new ArmyConfig() {
                    ArmyId = 33, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Space Wolves", new ArmyConfig() {
                    ArmyId = 34, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - Ultramarines", new ArmyConfig() {
                    ArmyId = 35, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Imperium - White Scars", new ArmyConfig() {
                    ArmyId = 36, FactionId = (int)Common.Factions.SpaceMarines }
                },
                {"Leagues of Votann", new ArmyConfig() {
                   ArmyId = 38, FactionId = (int)Common.Factions.XenosArmies }
                },
                //{"Library - Astartes Heresy Legends", new ArmyConfig() {
                //    ArmyId = 37, FactionId = Common.Factions.SpaceMarines }
                //},
                //{"Library - Titans", new ArmyConfig() {
                //    ArmyId = 38, FactionId = Common.Factions.XenosArmies }
                //},
                {"Necrons", new ArmyConfig() {
                    ArmyId = 39, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Orks", new ArmyConfig() {
                    ArmyId = 40, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"T'au Empire", new ArmyConfig() {
                    ArmyId = 41, FactionId = (int)Common.Factions.XenosArmies }
                },
                {"Tyranids", new ArmyConfig() {
                    ArmyId = 42 , FactionId = (int)Common.Factions.XenosArmies }
                },
                //{"Unaligned Forces", new ArmyConfig() {
                //    ArmyId = 43 , FactionId = Common.Factions.XenosArmies }
                //},
            };
        }

        public ArmyConfig? GetArmyConfig(string armyName)
        {
            if (!ArmyConfigs.ContainsKey(armyName))
            {
                Console.WriteLine($"Could not find config for {armyName}");
                return null;
            }

            return ArmyConfigs[armyName];
        }
    }
}