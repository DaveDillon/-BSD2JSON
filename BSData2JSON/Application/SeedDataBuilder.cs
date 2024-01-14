using BSData2JSON.Models;
using System.Collections.Generic;
using System.Text;
using static BSData2JSON.Application.Common;

namespace BSData2JSON.Application
{
    public class SeedDataBuilder
    {
        private const string unitInsert = " ({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";
        private StringBuilder sb;

        public SeedDataBuilder()
        {
        }

        public string BuilScripts(IEnumerable<Unit> unitList, ArmyConfig armyConfig)
        {
            int lineCount = 1;
            int unitId = int.Parse($"{armyConfig.ArmyId}0000");

            sb = new StringBuilder();
            sb.AppendLine("INSERT INTO[dbo].[Unit] ([Id], [visible], [SubFactionId], [UnitName], [Movement], [Toughness], [Save], [Wounds], [Leadership], [ObjectControl], [Invulnerability]) VALUES");

            foreach (var u in unitList)
            {
                //id,visible,ArmyId,unit name, base line stats ....
                sb.Append(string.Format(unitInsert, unitId++, 1, armyConfig.ArmyId, u.UnitName.Replace("'", "''"), u.Movement, u.Toughness, u.Save, u.Wounds, u.Leadership, u.ObjectControl, u.Invulnerability.Replace("'", "''")));

                if (lineCount != unitList.Count())
                {
                    sb.AppendLine(",");
                    lineCount++;
                }
                else
                {
                    sb.AppendLine();
                }
            }

            sb.AppendLine("GO");

            return sb.ToString();
        }

        public string BuildArmyListSeedData()
        {
            int armyId = 0;

            var cfgMger = new ConfigManager();
            var armyList = cfgMger.GetAllConfigs;

            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO[dbo].[SubFaction] ([id], [SubFactionName], [FactionId]) VALUES");

            foreach (var dic in armyList)
            {
                var army = dic.Value;

                sb.AppendLine(string.Format("({1}, '{2}',{0})", army.FactionId, army.ArmyId, dic.Key.Replace("'", "''")));
            }
            sb.AppendLine("GO");
            return sb.ToString();
        }
    }
}