using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : MonoBehaviour
{
    public float speed;

    GameObject player;
    Rigidbody2D rb2d;
    Vector3 targ, dir;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            targ = player.transform.position;
            dir = (targ - transform.position).normalized;
        }
	}
	
	void FixedUpdate ()
    {
        if (targ != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
