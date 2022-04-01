using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("RPG Game/Character/Movement")]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Character")]
    [Tooltip("Use this to apply the direction we are moving")]
    public Vector3 moveDir;
    public CharacterController charC;
    [Header("Speed")]
    public float moveSpeed = 5f;
    public float walkSpeed = 5f, crouchSpeed = 2.5f, runSpeed = 10f;
    public float jumpSpeed = 8f, gravity = 20f;
    public Vector2 input;
    #endregion
    [System.Serializable]
    #if UNITY_EDITOR
    public struct KeyUISetup
    {
        public string keyName;
        public string defaultKey;
    }
    public KeyUISetup[] baseSetup;
    #endif
    void Start()
    {
        charC = GetComponent<CharacterController>();
        #if UNITY_EDITOR
        //    if (KeyBinds.keys.Count == 0)
        //    {
        //        for (int i = 0; i < baseSetup.Length; i++)
        //        {
        //            //add key according to the saved string or default value
        //            KeyBinds.keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode),
        //                PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));
        //        }
        //    }
        if(KeyBinds.keys.Count == 0)
        {
            for (int i = 0; i < baseSetup.Length; i++)
            {
                //Change the Keys now they exist to the saved keys values
                HandleTextFile.ReadString();
            }
        }
#endif
    }

    void Update()
    {
        if (GameManager.gamePlayState == GamePlayState.Game)
        {
            if (charC.isGrounded)
            {
                /*moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= moveSpeed;
                if (Input.GetButton("Jump"))
                {
                    moveDir.y = jumpSpeed;
                }*/

                //Using ? allows us to evaluate a boolien xpression and return resuults based off
                //which expression is met. We are also using a default value if neither are met

                // this is the same as writing an if else if statement for movement directions
                //sets the input.y vector to 1 or -1 depending on what key is pressed from the keybind dictionary
                //default is 0 if neither is pressed
                input.y = Input.GetKey(KeyBinds.keys["Forward"]) ? 1 :
                input.y = Input.GetKey(KeyBinds.keys["Backward"]) ? -1 : 0;

                //sets the input.x vector to 1 or -1 depending on what key is pressed from the keybind dictionary
                //default is 0 if neither is pressed
                input.x = Input.GetKey(KeyBinds.keys["Right"]) ? 1 :
                input.x = Input.GetKey(KeyBinds.keys["Left"]) ? -1 : 0;

                //sets the move speed based on what key is pressed from the keybinds dictionary
                //default speed is walkSpeed if neither Sprint nor Crouch is pressed
                moveSpeed = Input.GetKey(KeyBinds.keys["Sprint"]) ? runSpeed :
                moveSpeed = Input.GetKey(KeyBinds.keys["Crouch"]) ? crouchSpeed : walkSpeed;

                moveDir = transform.TransformDirection(new Vector3(input.x, 0, input.y));
                moveDir *= moveSpeed;

                if (Input.GetKey(KeyBinds.keys["Jump"]))
                {
                    moveDir.y = jumpSpeed;
                }
            }
            moveDir.y -= gravity * Time.deltaTime;
            charC.Move(moveDir * Time.deltaTime);
        }
    }
}
