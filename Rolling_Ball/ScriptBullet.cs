using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Cannon;

    private Rigidbody rb;
    private Transform tr;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        rb.AddForce(tr.forward * 200000000);

        Destroy(gameObject, 5);
    }
}
