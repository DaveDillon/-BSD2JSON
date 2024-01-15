namespace BSData2JSON.Models
{
    public class Unit
    {
        public Unit()
        {
            Abilities = new List<Ability>();
            RangedSkills = new List<RangedSkill>();
            MeleeSkills = new List<MeleeSkill>();
        }

        public string id { get; set; } = "";
        public string UnitName { get; set; } = "";
        public string Movement { get; set; } = "";
        public string Toughness { get; set; } = "";
        public string Save { get; set; } = "";
        public string Wounds { get; set; } = "";
        public string Leadership { get; set; } = "";
        public string ObjectControl { get; set; } = "";
        public string Invulnerability { get; set; } = "";
        public List<Ability> Abilities { get; set; }
        public List<RangedSkill> RangedSkills { get; set; }
        public List<MeleeSkill> MeleeSkills { get; set; }
    }

    public class RangedSkill
    {
        public string id { get; set; } = "";
        public string WeaponName { get; set; } = "";
        public string Range { get; set; } = "";
        public string Attacks { get; set; } = "";
        public string BallisticSkill { get; set; } = "";
        public string Strength { get; set; } = "";
        public string ArnorPirecing { get; set; } = "";
        public string Damage { get; set; } = "";
        public string Text { get; set; } = "";
    }

    public class MeleeSkill
    {
        public string id { get; set; } = "";
        public string WeaponName { get; set; } = "";
        public string Attacks { get; set; } = "";
        public string WeaponSkill { get; set; } = "";
        public string Strength { get; set; } = "";
        public string ArnorPirecing { get; set; } = "";
        public string Damage { get; set; } = "";
    }

    public class Ability
    {
        public string Id { get; set; } = "";
        public string AbilityName { get; set; } = "";
        public string AbilityText { get; set; } = "";
    }
}