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
                _heal = 2;
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
            case 100:
                _name = "Axe";
                _description = "Heavy but deadly";
                _value = 1;
                _amount = 1;
                _icon = "Weapon/Axe";
                _type = ItemTypes.Weapon;
                _heal = 10;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                _name = "Gold Ring";
                _description = "Protects a very small amount of your finger";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Ring";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 201:
                _name = "Bronze Armour";
                _description = "Keeps your body protected. Slightly";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 202:
                _name = "Steel Armour";
                _description = "Just a bit better at protecting your body";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour1";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 203:
                _name = "Wizard Armour";
                _description = "Armour for wizards. It looks cool but probably won't do much against a blade";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour2";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 204:
                _name = "Mithril Armour";
                _description = "Protects much better and looks nice";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour3";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 205:
                _name = "Black Armour";
                _description = "Good at protecting from hits and hiding in the shadows";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour4";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            case 206:
                _name = "Elite Mithril Armour";
                _description = "Damn good looking armour";
                _value = 1;
                _amount = 1;
                _icon = "Apparel/Armour5";
                _type = ItemTypes.Apparel;
                _heal = 0;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                _name = "Ingot";
                _description = "Useful for creating armour and weapons";
                _value = 1;
                _amount = 1;
                _icon = "Crafting/Ingots";
                _type = ItemTypes.Crafting;
                _heal = 0;
                break;
            #endregion
            #region Ingredients 400-499
            #endregion
            #region Potions 500-599
            case 500:
                _name = "Health Potion";
                _description = "Restores health";
                _value = 1;
                _amount = 1;
                _icon = "Potions/HP";
                _type = ItemTypes.Potion;
                _heal = 20;
                break;
            case 501:
                _name = "Mana Potion";
                _description = "Restores mana";
                _value = 1;
                _amount = 1;
                _icon = "Potions/MP";
                _type = ItemTypes.Potion;
                _heal = 10;
                break;
            #endregion
            #region Scrolls 600-699
            case 600:
                _name = "Scroll";
                _description = "Contains a small amount of magical power";
                _value = 1;
                _amount = 1;
                _icon = "Scrolls/Scroll";
                _type = ItemTypes.Scroll;
                _heal = 0;
                break;
            #endregion
            #region Quest 700-799
            case 700:
                _name = "Gem";
                _description = "Very valuable";
                _value = 1;
                _amount = 1;
                _icon = "Quest/Gem";
                _type = ItemTypes.Quest;
                _heal = 10;
                break;
            #endregion
            #region Misc 800-899
            case 800:
                _name = "Coin";
                _description = "Shiney!";
                _value = 1;
                _amount = 1;
                _icon = "Misc/Coins";
                _type = ItemTypes.Money;
                _heal = 0;
                break;
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
