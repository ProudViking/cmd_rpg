namespace cmd_rpg.Items
{
    partial class Consumeable : Item
    {
        public override string Name { get; set; }
        public override int Weight { get; set; }
        public override int BaseCost { get; set; }
        public override ItemQuality Quality { get; set; }
        public override int LevelReq { get; set; }
        public override Classes.Class ClassReq { get; set; }
    }
}
