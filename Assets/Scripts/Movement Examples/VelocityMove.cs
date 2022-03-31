using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
