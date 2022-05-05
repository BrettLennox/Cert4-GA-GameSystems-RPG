using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int _itemId)
    {
        string _name = "";
        string _description = "";
        int _value = 0;
        int _amount = 0;
        string _icon = "";
        string _mesh = "";
        ItemTypes _type = ItemTypes.Apparel;
        int _damage = 0;
        int _armour = 0;
        int _heal = 0;

        switch (_itemId)
        {
            #region Food 0-99
            case 0:
                _name = "Apple";
                _description = "Munchies and Crunchies";
                _value = 1;
                _amount = 1;
                _icon = "Food/Apple";
                _type = ItemTypes.Food;
                _heal = 10;
                break;
            case 1:
                _name = "Meat";
                _description = "Munchies and Crunchies";
                _value = 1;
                _amount = 1;
                _icon = "Food/Meat";
                _type = ItemTypes.Food;
                _heal = 10;
                break;
            #endregion
            #region Weapon 100-199
            #endregion
            #region Apparel 200-299
            #endregion
            #region Crafting 300-399
            #endregion
            #region Ingredients 400-499
            #endregion
            #region Potions 500-599
            #endregion
            #region Scrolls 600-699
            #endregion
            #region Quest 700-799
            #endregion
            #region Misc 800-899
            #endregion
            default:
                _itemId = 0;
                _name = "Apple";
                _description = "Munchies and Crunchies";
                _value = 1;
                _amount = 1;
                _icon = "Food/Apple";
                _type = ItemTypes.Food;
                _heal = 10;
                break;
        }
        Item temp = new Item()
        {
            ID = _itemId,
            Name = _name,
            Description = _description,
            Value = _value,
            Amount = _amount,
            Type = _type,
            Icon = Resources.Load("Icon/" + _icon) as Texture2D,
            Prefab = Resources.Load("Prefab/" + _mesh) as GameObject,
            Damage = _damage,
            Armour = _armour,
            Heal = _heal
        };
        return temp;
    }
}
