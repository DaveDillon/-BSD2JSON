namespace BSData2JSON
{
    using BSData2JSON.Application;
    using BSData2JSON.Models;
    using Newtonsoft.Json;
    using System.IO;
    using System.Xml;

    internal class Program
    {
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

                doc.Load(catfile.FullName);

                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("BSD", "http://www.battlescribe.net/schema/catalogueSchema");

                BSDataUtil dataUtil = new BSDataUtil(nsmgr);

                var nodes = doc.SelectNodes("//BSD:categoryEntries/BSD:categoryEntry", nsmgr);

                //var nodes = doc.SelectNodes("//*[local-name()='categoryEntry']");

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
                        string unitString = JsonConvert.SerializeObject(u, Newtonsoft.Json.Formatting.Indented);

                        var writeFile = new FileInfo(outDir + "/" + catfile.Name.Replace(".cat","") + "/" + unitName + ".txt");
                        if (!writeFile.Directory.Exists)
                                writeFile.Directory.Create();


                        using (StreamWriter writetext = new StreamWriter(writeFile.FullName))
                        {
                            writetext.WriteLine(unitString);
                        }
                    }

                    //Console.WriteLine(x);

                    //var unitXMLDoc = new XmlDocument();
                    //unitXMLDoc.LoadXml(cNode[0].InnerXml);

                    //var stateLineNode =
                    //.SelectNodes(string.Format("//{0}:profiles", "BSD", unitId), nsmgr);
                }
            }

            Console.WriteLine("Application has completed, press enter to exit.");
            Console.ReadLine();
        }
    }
}