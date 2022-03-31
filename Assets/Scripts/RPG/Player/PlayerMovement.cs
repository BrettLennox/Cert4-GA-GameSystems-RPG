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
    public float jumpSpeed = 8f, gravity = 20f;
    #endregion

    void Start()
    {
        charC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (GameManager.gamePlayState == GamePlayState.Game)
        {
            if (charC.isGrounded)
            {
                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= moveSpeed;
                if (Input.GetButton("Jump"))
                {
                    moveDir.y = jumpSpeed;
                }
            }
            moveDir.y -= gravity * Time.deltaTime;
            charC.Move(moveDir * Time.deltaTime);
        }
    }
}
