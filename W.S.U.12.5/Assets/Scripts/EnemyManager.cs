using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;
    public Transform target;

    public Vector3 the, end;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool isRight;

    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            the = transform.position;
            end = target.position;
        }

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        if (transform.position == target.position)
        {
            target.position = (target.position == the) ? end : the;
        }
        */

        if(isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate((Vector3.right * speed) * Time.deltaTime);
            if(transform.position.x >= the.x)
            {
                isRight = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate((Vector3.left * speed) * Time.deltaTime);
            if(transform.position.x <= target.position.x)
            {
                isRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlasterDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
