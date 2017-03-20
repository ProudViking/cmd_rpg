namespace cmd_rpg.Items
{
    public enum WearableSlot
    {
        Head = 8,
        Shoulders = 7,
        Chest = 6,
        Wrist = 5,
        Hands = 4,
        Belt = 3,
        Leggings = 2,
        Feet = 1
    }
    public enum ArmorType
    {
        Plate = 4,
        Chain = 3,
        Leather = 2,
        Cloth = 1
    }

    partial class Wearable : Item
    {
        public Wearable(string pName, int pWeight, ItemQuality pQuality, WearableSlot pSlot, 
            int pLevelReq = 0, Classes.Class pClassReq = Classes.Class.Unknown)
        {
            Name = pName;
            Weight = pWeight;
            Quality = pQuality;
            Slot = pSlot;
            LevelReq = pLevelReq;
            ClassReq = pClassReq;
        }

        #region Item Info
        public override string Name             { get; set; }
        public override int Weight              { get; set; }
        public override int BaseCost            { get; set; }
        public override ItemQuality Quality     { get; set; }
        public override int LevelReq            { get; set; }
        public override Classes.Class ClassReq  { get; set; }
        #endregion

        #region Wearable info
        public int Armor                        { get; set; }
        public int MaxHealthMod                 { get; set; }
        public int MaxStamMod                   { get; set; }
        public int MaxManaMod                   { get; set; }
        public WearableSlot Slot                { get; set; }
        #endregion
    }
}
