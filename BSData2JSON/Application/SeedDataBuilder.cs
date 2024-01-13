using BSData2JSON.Models;
using System.Collections.Generic;
using System.Text;

namespace BSData2JSON.Application
{
    public class SeedDataBuilder
    {
        private const string unitInsert = " ({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'),";
        private StringBuilder sb;

        public SeedDataBuilder()
        {
        }

        public string BuilScripts(IEnumerable<Unit> unitList, ArmyConfig armyConfig)
        {
            int unitId = int.Parse($"{armyConfig.ArmyId}0000");

            sb = new StringBuilder();
            sb.AppendLine("INSERT INTO[dbo].[Unit] ([Id], [visible], [SubFactionId], [UnitName], [Movement], [Toughness], [Save], [Wounds], [Leadership], [ObjectControl], [Invulnerability]))");

            foreach (var u in unitList)
            {
                //id,visible,ArmyId,unit name, base line stats ....
                sb.AppendLine(string.Format(unitInsert, unitId++, 1, armyConfig.ArmyId, u.UnitName.Replace("'", "''"), u.Movement, u.Toughness, u.Save, u.Wounds, u.Leadership, u.ObjectControl, u.Invulnerability.Replace("'", "''")));
            }

            sb.AppendLine("GO");

            return sb.ToString();
        }
    }
}