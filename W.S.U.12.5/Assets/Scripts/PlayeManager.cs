using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public Transform blasterSpawner;
    public GameObject blasPrefab;

    private Animator anim;
    private Rigidbody2D rb2d;
    private bool movement = true;

    Vector2 mov;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Pausa.isPause)
        {
            return;
        }
        else
        {
            anim.SetFloat("rolling", Mathf.Abs(rb2d.velocity.x));
            anim.SetBool("Grounded", grounded);
            Fire();
        }
	}
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(blasPrefab, blasterSpawner.position, blasterSpawner.rotation);
        }
    }

    void FixedUpdate()
    {
        Vector3 fixVel = rb2d.velocity;
        fixVel.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixVel;
        }

        if (Pausa.isPause)
        {
            return;
        }
        else
        {
            mov.x = Input.GetAxis("Horizontal");
            if (!movement) mov.x = 0;
            rb2d.AddForce(Vector2.right * speed * mov);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        }
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector2(1, 0);
    }
}
