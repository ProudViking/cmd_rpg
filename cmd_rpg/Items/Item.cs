namespace cmd_rpg.Items
{
    public enum ItemQuality  //Rarity in WoW'esque color scheme
    {
        Common,     //White
        Uncommon,   //Green
        Rare,       //Blue
        Epic,       //Purple
        Legendary   //Orange
    }

    abstract class Item
    {
        #region Item Info
        public abstract string Name { get; set; }
        public abstract int Weight { get; set; }
        public abstract int BaseCost { get; set; }
        public abstract ItemQuality Quality { get; set; }
        #endregion

        #region Requirements
        public abstract int LevelReq { get; set; }
        public abstract Classes.Class ClassReq { get; set; }
        #endregion
    }
}
