namespace BSData2JSON.Application
{
    using BSData2JSON.Models;
    using System.Xml;

    public class BSDataUtil
    {
        private readonly XmlNamespaceManager _nsmgr;

        private Unit rtnUnit;

        public BSDataUtil(XmlNamespaceManager m)
        {
            _nsmgr = m;
        }

        public Unit GetBaseLineDetails(XmlNode unitNode, string unitId, string unitName)
        {
            rtnUnit = new Unit() { UnitName = unitName };

            var baseStatNodes = unitNode.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry//{0}:profile[@typeId = 'c547-1836-d8a-ff4f']//{0}:characteristic", "BSD", unitId), _nsmgr);

            var m = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "M")
                .Select(x => x.InnerText).FirstOrDefault();

            var t = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "T")
                .Select(x => x.InnerText).FirstOrDefault();

            var sv = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "SV")
                .Select(x => x.InnerText).FirstOrDefault();

            var w = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "W")
                .Select(x => x.InnerText).FirstOrDefault();

            var ld = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "LD")
                .Select(x => x.InnerText).FirstOrDefault();

            var oc = baseStatNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "LD")
                .Select(x => x.InnerText).FirstOrDefault();

            rtnUnit.Movement = m;
            rtnUnit.Toughness = t;
            rtnUnit.Save = sv;
            rtnUnit.Wounds = w;
            rtnUnit.Leadership = ld;
            rtnUnit.ObjectControl = oc;

            var InvulnerableSave = unitNode.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry//{0}:profile[@typeId = '9cc3-6d83-4dd3-9b64' and @name='Invulnerable Save']//{0}:characteristic", "BSD", unitId), _nsmgr);
            if (InvulnerableSave.Count == 1)
            {
                rtnUnit.Invulnerability = InvulnerableSave[0].InnerText;
            }

            var abilities = unitNode.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry//{0}:profile[@typeId = '9cc3-6d83-4dd3-9b64' and @name!='Invulnerable Save']", "BSD", unitId), _nsmgr);

            foreach (XmlNode n in abilities)
            {
                string abilityName = n.Attributes["name"].Value;
                string abilityId = n.Attributes["id"].Value;

                var AbilityTextNode = unitNode.SelectNodes(string.Format("//{0}:profile[@typeId = '9cc3-6d83-4dd3-9b64' and @id='{1}']", "BSD", abilityId), _nsmgr);

                rtnUnit.Abilities.Add(new Ability()
                {
                    AbilityName = abilityName,
                    AbilityText = AbilityTextNode[0].InnerText
                });
            }

            var RangedWeapons = unitNode.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry//{0}:profile[@typeName = 'Ranged Weapons']/../..", "BSD", unitId), _nsmgr);
            Console.WriteLine($"Number of ranged weapons found: {RangedWeapons.Count}");

            foreach (XmlNode rw in RangedWeapons)
            {
                string weaponName = rw.Attributes["name"].Value;
                string skillId = rw.Attributes["id"].Value;


                var weaponProfiles = unitNode.SelectNodes(string.Format("//{0}:selectionEntry[@id = '{1}']//{0}:profile[@typeName = 'Ranged Weapons']", "BSD", skillId), _nsmgr);
                foreach (var item in weaponProfiles) // each weapon profile.
                {
                    var a = "";


                    var u = new Unit()
                    {


                    };

                }





                // var attacks = rw.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == "A")
                //.Select(x => x.InnerText).FirstOrDefault();


            }

            var MeleedWeapons = unitNode.SelectNodes(string.Format("//{0}:categoryLink[@targetId = '{1}']/ancestor::{0}:selectionEntry//{0}:profile[@typeName = 'Melee Weapons']/../..", "BSD", unitId), _nsmgr);
            Console.WriteLine($"Number of melee weapons found: {MeleedWeapons.Count}");

            foreach (XmlNode rw in MeleedWeapons)
            {
                string weaponName = rw.Attributes["name"].Value;
                string skillId = rw.Attributes["id"].Value;

                var AbilityTextNode = unitNode.SelectNodes(string.Format("//{0}:profile[@typeId = '9cc3-6d83-4dd3-9b64' and @id='{1}']", "BSD", skillId), _nsmgr);

                rtnUnit.MeleeSkills.Add(new MeleeSkill()
                {
                    WeaponName = weaponName,
                });
            }

            return rtnUnit;
        }
    }
}