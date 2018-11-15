using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;

    private Rigidbody2D rb2d;
    private bool movement = true;

    Vector2 mov;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        Vector3 fixVel = rb2d.velocity;
        fixVel.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixVel;
        }

        mov.x = Input.GetAxis("Horizontal");
        if (!movement) mov.x = 0;
        rb2d.AddForce(Vector2.right * speed * mov);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        if (mov.x > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (mov.x < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
