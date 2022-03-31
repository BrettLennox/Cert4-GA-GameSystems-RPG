using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController controller;
    public Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Vector3.forward;
        controller.Move(moveDir * speed * Time.deltaTime);
    }
}
