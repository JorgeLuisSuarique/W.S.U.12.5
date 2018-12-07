using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    private Rigidbody2D bullRb2d;
    private Transform playTrans;
    private GameObject player;
    public float bullSpeed;
    public float bullLife;
    public Transform mira;

    void Awake()
    {
        bullRb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playTrans = player.transform;
    }

    void Start()
    {
        mira = GameObject.Find("Mira").transform;
        bullRb2d.AddForce((mira.position - transform.position) * bullSpeed, ForceMode2D.Impulse);
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
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
