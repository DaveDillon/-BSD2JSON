namespace BSData2JSON
{
    using BSData2JSON.Application;
    using BSData2JSON.Models;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;
    using System.Xml;

    internal class Program
    {
        private static ConfigManager cfgManger = new ConfigManager();
        private static ArmyConfig? armyCfg = null;
        private static List<Unit> unitList;
        private static SeedDataBuilder seebuilder = new SeedDataBuilder();
        private static string OutDiectoryName = string.Empty;
        private static StringBuilder sbFullSeeScript = new StringBuilder();

        private static void Main(string[] args)
        {
            Console.WriteLine("BSData2JSON Battlescribe Data 2 JSON");
            var CWD = Environment.CurrentDirectory;
            Console.WriteLine($"Current working directory:{CWD}");

            DirectoryInfo inDir = new DirectoryInfo(CWD + "/in");
            if (!inDir.Exists) { inDir.Create(); }

            DirectoryInfo outDir = new DirectoryInfo(CWD + "/out");
            if (!outDir.Exists) { outDir.Create(); }

            var catFIles = inDir.GetFiles("*.cat");

            if (catFIles.Length == 0)
            {
                Console.WriteLine("No files to process. Please ensure you place the data failes into in directory with this application.");
            }

            XmlDocument doc = new XmlDocument();
            foreach (FileInfo catfile in catFIles)
            {
                Console.WriteLine($"Processing{catfile.Name}");
                armyCfg = cfgManger.GetArmyConfig(catfile.Name.Replace(".cat", ""));
                if (armyCfg == null)
                    continue;

                unitList = new List<Unit>();
                OutDiectoryName = catfile.Name.Replace(".cat", "");

                doc.Load(catfile.FullName);
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("BSD", "http://www.battlescribe.net/schema/catalogueSchema");

                BSDataUtil dataUtil = new BSDataUtil(nsmgr);
                var nodes = doc.SelectNodes("//BSD:categoryEntries/BSD:categoryEntry", nsmgr);

                foreach (XmlNode node in nodes)
                {
                    var unitName = node.Attributes["name"].Value.ToString();
                    Console.WriteLine(unitName);

                    var unitId = node.Attributes["id"].Value.ToString();
                    Console.WriteLine(unitId);

                    var cNode = doc.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry", "BSD", unitId), nsmgr);
                    XmlNode UnitXmlNode = cNode[0];

                    if (UnitXmlNode != null)
                    {
                        Unit u = dataUtil.GetBaseLineDetails(UnitXmlNode, unitId, unitName);
                        unitList.Add(u);
                        string unitString = JsonConvert.SerializeObject(u, Newtonsoft.Json.Formatting.Indented);

                        var writeFile = new FileInfo(outDir + "/" + catfile.Name.Replace(".cat", "") + "/" + unitName + ".txt");
                        if (!writeFile.Directory.Exists)
                            writeFile.Directory.Create();

                        using (StreamWriter writetext = new StreamWriter(writeFile.FullName))
                        {
                            writetext.WriteLine(unitString);
                        }
                    }
                }

                if (unitList.Count > 0)
                {
                    var seedScript = seebuilder.BuilScripts(unitList, armyCfg);
                    var sqlWriteFile = new FileInfo(outDir + "/" + OutDiectoryName + "/" + OutDiectoryName + ".sql");
                    if (!sqlWriteFile.Directory.Exists)
                        sqlWriteFile.Directory.Create();

                    using (StreamWriter writetext = new StreamWriter(sqlWriteFile.FullName))
                    {
                        writetext.Write(seedScript);
                    }
                    sbFullSeeScript.AppendLine(seedScript);
                }
            }
            // Create sql see scripts.

            var fullSeeScriptSQL = new FileInfo(outDir + "/FullSeedScript.sql");
            if (!fullSeeScriptSQL.Directory.Exists)
                fullSeeScriptSQL.Directory.Create();

            var ArmySeedData = seebuilder.BuildArmyListSeedData();
            using (StreamWriter writetext = new StreamWriter(fullSeeScriptSQL.FullName))
            {
                writetext.Write(ArmySeedData);
                writetext.Write(sbFullSeeScript.ToString());
            }

           


            Console.WriteLine("Application has completed, press enter to exit.");
            Console.ReadLine();
        }
    }
}