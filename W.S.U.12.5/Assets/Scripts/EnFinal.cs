using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnFinal : MonoBehaviour
{
    public bool isRight;
    public float speed = 1f;
    public Vector3 the, end;
    public Transform target;
    public LiveEnemy live;
    private Rigidbody2D rb2d;


    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            the = transform.position;
            end = target.position;
        }
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Pausa.isPause)
        {
          return;
        }
        else
        {
          Idle();
        }
    }

    void Idle()
    {
        if (isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate((Vector3.right * speed) * Time.deltaTime);
            if (transform.position.x >= the.x)
            {
                isRight = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate((Vector3.left * speed) * Time.deltaTime);
            if (transform.position.x <= target.position.x)
            {
                isRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D go)
    {
        if (go.CompareTag("BlasterDestroy"))
        {
            live.Applyvida(150);
        }
        
    }
}
