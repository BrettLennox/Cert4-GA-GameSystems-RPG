using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
    }
}
