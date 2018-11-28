using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayeManager play;

    void Start ()
    {
       play = GetComponentInParent<PlayeManager>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            play.transform.parent = collision.transform;
            play.grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            play.transform.parent = null;
            play.grounded = false;
        }
    }
}
