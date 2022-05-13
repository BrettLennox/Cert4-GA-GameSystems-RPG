using System.Collections.Generic;//lists and dictionaries
using UnityEngine;
namespace Inventory.Player
{
    public class Inventory : MonoBehaviour
    {
        #region Variables
        public static List<Item> playerInv = new List<Item>();
        public Item selectedItem;
        public static bool showInv;
        public static int money;

        public Vector2 scrollPos;
        public string sortType = "All";
        public string[] enumTypesForItems = { "All", "Food", "Weapon", "Apparel", "Crafting", "Ingredient", "Potion", "Scroll", "Quest" };

        public Transform dropLocation;
        [System.Serializable]
        public struct Equipment
        {
            public string slotName;
            public Transform equipLocation; //Character Rig loation for that item
            public GameObject currentItem;
        }
        public Equipment[] equipmentSlots;

        public static Chest.Inventory currentChest;
        public static Shop.Inventory currentShop;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
//#if UNITY_EDITOR
//            playerInv.Add(ItemData.CreateItem(0));
//            playerInv.Add(ItemData.CreateItem(1));
//            playerInv.Add(ItemData.CreateItem(100));
//            playerInv.Add(ItemData.CreateItem(101));
//            playerInv.Add(ItemData.CreateItem(200));
//            playerInv.Add(ItemData.CreateItem(300));
//            playerInv.Add(ItemData.CreateItem(500));
//            playerInv.Add(ItemData.CreateItem(600));
//            playerInv.Add(ItemData.CreateItem(700));
//            playerInv.Add(ItemData.CreateItem(800));
//#endif
        }

        // Update is called once per frame
        void Update()
        {
            //using keybinds
            if (Input.GetKeyDown(KeyBinds.keys["Inventory"]))
            {
                //toggle inventory
                //toggle mouselook
                //toggle mouse
                showInv = !showInv;
                GameManager.gamePlayState = showInv ? GamePlayState.MenuPause : GamePlayState.Game;
            }

//#if UNITY_EDITOR
//            if (Input.GetKey(KeyCode.KeypadPlus))
//            {
//                playerInv.Add(ItemData.CreateItem(0));
//                playerInv.Add(ItemData.CreateItem(1));
//                playerInv.Add(ItemData.CreateItem(100));
//                playerInv.Add(ItemData.CreateItem(200));
//                playerInv.Add(ItemData.CreateItem(300));
//                playerInv.Add(ItemData.CreateItem(500));
//                playerInv.Add(ItemData.CreateItem(600));
//                playerInv.Add(ItemData.CreateItem(700));
//                playerInv.Add(ItemData.CreateItem(800));
//            }
//#endif
        }
        void Display()
        {
            //if we want to display everything in our inventory
            if (sortType == "All" | sortType == "")
            {
                //if we have 34 or less (space at top and bottom
                if (playerInv.Count <= 34)
                {
                    for (int i = 0; i < playerInv.Count; i++)
                    {
                        if (GUI.Button(new Rect(0.5f * GameManager.scr.x, 0.25f * GameManager.scr.y + i * (0.25f * GameManager.scr.y), 3 * GameManager.scr.x, 0.25f * GameManager.scr.y), playerInv[i].Name))
                        {
                            selectedItem = playerInv[i];
                        }
                    }
                }
                //more then 34 items
                else
                {
                    //our movable scroll position
                    scrollPos =
                    //the start of the viewable area
                    GUI.BeginScrollView(
                    //our view window
                    new Rect(0, 0.25f * GameManager.scr.y, 3.75f * GameManager.scr.x, 8.5f * GameManager.scr.y),
                    //our current scroll position within that window
                    scrollPos,
                    //scroll zone(extra space) that we can move within the View Window
                    new Rect(0, 0, 0, playerInv.Count * 0.25f * GameManager.scr.y),
                    //can we see the horizontal bar?
                    false,
                    //can we see the vertical bar?
                    true
                    );
                    #region Scroll View
                    for (int i = 0; i < playerInv.Count; i++)
                    {
                        if (GUI.Button(new Rect(0.5f * GameManager.scr.x, i * (0.25f * GameManager.scr.y), 3 * GameManager.scr.x, 0.25f * GameManager.scr.y), playerInv[i].Name))
                        {
                            selectedItem = playerInv[i];
                        }
                    }
                    #endregion
                    //End the scroll space
                    GUI.EndScrollView();
                }
            }
            else //else we are displaying  based off type
            {
                ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
                //amount of that type
                int a = 0;
                //slot position
                int s = 0;
                for (int i = 0; i < playerInv.Count; i++)
                {
                    if (playerInv[i].Type == type)
                    {
                        a++;//increase a so we know how many we have
                    }
                }
                //we are less than equal to 34 items of this type
                if (a <= 34)
                {
                    for (int i = 0; i < playerInv.Count; i++)
                    {
                        if (playerInv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * GameManager.scr.x, 0.25f * GameManager.scr.y + s * (0.25f * GameManager.scr.y), 3 * GameManager.scr.x, 0.25f * GameManager.scr.y), playerInv[i].Name))
                            {
                                selectedItem = playerInv[i];
                            }
                            s++;
                        }
                    }
                }
                //we are greater than 34 items of this type
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * GameManager.scr.y, 3.75f * GameManager.scr.x, 8.5f * GameManager.scr.y), scrollPos, new Rect(0, 0, 0, a * 0.25f * GameManager.scr.y), false, true);
                    #region Scroll View
                    for (int i = 0; i < playerInv.Count; i++)
                    {
                        if (playerInv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * GameManager.scr.x, s * (0.25f * GameManager.scr.y), 3 * GameManager.scr.x, 0.25f * GameManager.scr.y), playerInv[i].Name))
                            {
                                selectedItem = playerInv[i];
                            }
                            s++;
                        }
                    }
                    #endregion
                    GUI.EndScrollView();
                }
            }
        }

        void UseItem()
        {
            GUI.Box(new Rect(4 * GameManager.scr.x, GameManager.scr.y, 3.5f * GameManager.scr.x, 7.25f * GameManager.scr.y), "");
            GUI.Box(new Rect(4.25f * GameManager.scr.x, 1.25f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y), selectedItem.Icon);
            GUI.Box(new Rect(4.55f * GameManager.scr.x, 4.25f * GameManager.scr.y, 2.5f * GameManager.scr.x, 0.5f * GameManager.scr.y), selectedItem.Name);
            switch (selectedItem.Type)
            {
                case ItemTypes.Food:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount + "\nHeal: " + selectedItem.Heal);
                    if (PlayerHandler.playerHandlerInstance.attributes[0].curValue < PlayerHandler.playerHandlerInstance.attributes[0].maxValue)
                    {
                        if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                        {
                            PlayerHandler.playerHandlerInstance.attributes[0].curValue = Mathf.Clamp
                                (PlayerHandler.playerHandlerInstance.attributes[0].curValue += selectedItem.Heal, 0, PlayerHandler.playerHandlerInstance.attributes[0].maxValue);
                            if (selectedItem.Amount > 1)
                            {
                                selectedItem.Amount--;
                            }
                            else
                            {
                                playerInv.Remove(selectedItem);
                                selectedItem = null;
                                return;
                            }
                        }
                    }
                    break;
                case ItemTypes.Weapon:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage);
                    //if we are not holding a weapon or the weapon we are holding is different
                    if (equipmentSlots[0].currentItem == null || selectedItem.Name != equipmentSlots[0].currentItem.name)
                    {
                        if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Equip"))
                        {
                            if (equipmentSlots[0].currentItem != null)
                            {
                                Destroy(equipmentSlots[0].currentItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[0].equipLocation);
                            equipmentSlots[0].currentItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else //else we are holding the item already
                    {
                        if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[0].currentItem);
                        }
                    }
                    break;
                case ItemTypes.Apparel:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour);
                    if (equipmentSlots[0].currentItem == null || selectedItem.Name != equipmentSlots[0].currentItem.name)
                    {
                        if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Equip"))
                        {
                            if (equipmentSlots[0].currentItem != null)
                            {
                                Destroy(equipmentSlots[0].currentItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[0].equipLocation);
                            equipmentSlots[0].currentItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else //else we are holding the item already
                    {
                        if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[0].currentItem);
                        }
                    }
                    break;
                case ItemTypes.Crafting:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                    if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                    {
                        Debug.LogWarning("NOT IMPLEMENTED");
                    }
                    break;
                case ItemTypes.Ingredient:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                    if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                    {
                        Debug.LogWarning("NOT IMPLEMENTED");
                    }
                    break;
                case ItemTypes.Potion:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount + "\nHeal: " + selectedItem.Heal);
                    if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                    {
                        if (PlayerHandler.playerHandlerInstance.attributes[0].curValue < PlayerHandler.playerHandlerInstance.attributes[0].maxValue)
                        {
                            if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                            {
                                PlayerHandler.playerHandlerInstance.attributes[0].curValue = Mathf.Clamp
                                    (PlayerHandler.playerHandlerInstance.attributes[0].curValue += selectedItem.Heal, 0, PlayerHandler.playerHandlerInstance.attributes[0].maxValue);
                                if (selectedItem.Amount > 1)
                                {
                                    selectedItem.Amount--;
                                }
                                else
                                {
                                    playerInv.Remove(selectedItem);
                                    selectedItem = null;
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case ItemTypes.Scroll:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                    if (GUI.Button(new Rect(4.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Use"))
                    {
                        Debug.LogWarning("NOT IMPLEMENTED");
                    }
                    break;
                case ItemTypes.Quest:
                    GUI.Box(new Rect
                        (4.25f * GameManager.scr.x, 4.75f * GameManager.scr.y, 3f * GameManager.scr.x, 3 * GameManager.scr.y),
                        selectedItem.Description);
                    break;
                default:
                    Debug.LogWarning("SOMETHING WENT WRONG");
                    break;
            }
            //if not a quest item
            if (selectedItem.Type != ItemTypes.Quest)
            {
                if (GUI.Button(new Rect(5.25f * GameManager.scr.x, 7.75f * GameManager.scr.y, GameManager.scr.x, 0.25f * GameManager.scr.y), "Discard"))
                {
                    for (int i = 0; i < equipmentSlots.Length; i++)
                    {
                        //check slots
                        if (equipmentSlots[0].currentItem != null && selectedItem.Name == equipmentSlots[i].currentItem.name)
                        {
                            //remove item from world
                            Destroy(equipmentSlots[i].currentItem);
                        }
                    }
                    //spawn item
                    GameObject droppedItem = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
                    droppedItem.name = selectedItem.Name;
                    droppedItem.AddComponent<Rigidbody>().useGravity = true;
                    droppedItem.GetComponent<ItemHandler>().enabled = true;
                    //if its stacked, reduce stack
                    if(selectedItem.Amount > 1)
                    {
                        selectedItem.Amount--;
                    }
                    else //else remove item from inventory
                    {
                        playerInv.Remove(selectedItem);
                        selectedItem = null;
                        return;
                    }
                }
            }
        }

        private void OnGUI()
        {
            if (showInv)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
                for (int i = 0; i < enumTypesForItems.Length; i++)
                {
                    if (GUI.Button(new Rect(4f * GameManager.scr.x + i * GameManager.scr.x, GameManager.scr.y * 0.5f, GameManager.scr.x, 0.25f * GameManager.scr.y), enumTypesForItems[i]))
                    {
                        sortType = enumTypesForItems[i];
                    }
                }
                Display();
                if (selectedItem != null)
                {
                    UseItem();
                }
            }
        }
    }
}
