using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private Rigidbody2D bullRb2d;
    public float bullLife;

    void Start()
    {
        bullRb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Destroy(gameObject, bullLife);
        if (Pausa.isPause)
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
