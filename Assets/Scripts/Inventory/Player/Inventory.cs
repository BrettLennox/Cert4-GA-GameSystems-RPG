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
        public string[] enumTypesForItems = { "All", "Food", "Weapon", "Apparel", "Crafting", "Ingredient", "Potion", "Scroll", "Quest", "Money" };

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
#if UNITY_EDITOR
            playerInv.Add(ItemData.CreateItem(0));
            playerInv.Add(ItemData.CreateItem(1));
            playerInv.Add(ItemData.CreateItem(100));
            playerInv.Add(ItemData.CreateItem(200));
            playerInv.Add(ItemData.CreateItem(300));
            playerInv.Add(ItemData.CreateItem(500));
            playerInv.Add(ItemData.CreateItem(600));
            playerInv.Add(ItemData.CreateItem(700));
            playerInv.Add(ItemData.CreateItem(800));
#endif
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

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                playerInv.Add(ItemData.CreateItem(0));
                playerInv.Add(ItemData.CreateItem(1));
                playerInv.Add(ItemData.CreateItem(100));
                playerInv.Add(ItemData.CreateItem(200));
                playerInv.Add(ItemData.CreateItem(300));
                playerInv.Add(ItemData.CreateItem(500));
                playerInv.Add(ItemData.CreateItem(600));
                playerInv.Add(ItemData.CreateItem(700));
                playerInv.Add(ItemData.CreateItem(800));
            }
#endif
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
                    //scroll zone(extra space) that we can move withi the View Window
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
