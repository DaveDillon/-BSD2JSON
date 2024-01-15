namespace BSData2JSON.Application
{
    using BSData2JSON.Models;
    using System.Text;

    public class SeedDataBuilder
    {
        private const string unitInsert = " ({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";
        private StringBuilder sbUnitSQL;
        private ConfigManager _cfgMger;
        private readonly int _visiable = 1;

        public SeedDataBuilder()
        {
            _cfgMger = new ConfigManager();
        }

        public string GetUnitListSeedData(IEnumerable<Unit> unitList, ArmyConfig armyConfig)
        {
            int lineCount = 1;
            int sqlUnitId = int.Parse($"{armyConfig.ArmyId}0000");

            sbUnitSQL = new StringBuilder();
            sbUnitSQL.AppendLine("INSERT INTO[dbo].[Unit] ([Id], [visible], [SubFactionId], [UnitName], [Movement], [Toughness], [Save], [Wounds], [Leadership], [ObjectControl], [Invulnerability]) VALUES");

            foreach (Unit? unitData in unitList)
            {
                //id,visible,ArmyId,unit name, base line stats ....
                sbUnitSQL.Append(string.Format(unitInsert,
                    sqlUnitId++,
                    _visiable,
                    armyConfig.ArmyId,
                    unitData.UnitName.Replace("'", "''"),
                    unitData.Movement,
                    unitData.Toughness,
                    unitData.Save,
                    unitData.Wounds,
                    unitData.Leadership,
                    unitData.ObjectControl,
                    unitData.Invulnerability.Replace("'", "''")));

                if (lineCount != unitList.Count())
                {
                    sbUnitSQL.AppendLine(",");
                    lineCount++;
                }
                else
                {
                    sbUnitSQL.AppendLine();
                }
            }

            sbUnitSQL.AppendLine("GO");
            return sbUnitSQL.ToString();
        }

        public string GetArmySeedData()
        {
            int armyId = 0;
            var armyList = _cfgMger.GetAllConfigs;

            var sbArmySQL = new StringBuilder();
            sbArmySQL.AppendLine("INSERT INTO[dbo].[SubFaction] ([id], [SubFactionName], [FactionId]) VALUES");

            foreach (var dic in armyList)
            {
                var armyCFG = dic.Value;
                sbArmySQL.AppendLine(string.Format("({1}, '{2}',{0})", armyCFG.FactionId, armyCFG.ArmyId, dic.Key.Replace("'", "''")));
                armyId++;
            }
            sbArmySQL.AppendLine("GO");
            return sbArmySQL.ToString();
        }
    }
}