using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int power = 2000;

    public GameObject Bullet;
    public GameObject Explosion;

    public Transform FirePos;

    private Transform tr;

    private float timer;
    private float waitingTime;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 3f;

        timer = Random.Range(0.0f, 3.0f);

        tr = GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Instantiate(Explosion, FirePos.transform.position, FirePos.transform.rotation);

            timer = 0;
        }
    }
}
