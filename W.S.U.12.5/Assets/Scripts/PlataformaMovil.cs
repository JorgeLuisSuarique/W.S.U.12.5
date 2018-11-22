using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform target;
    private Vector3 the, end;

    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            the = transform.position;
            end = target.position;
        }
    }

    void FixedUpdate()
    {
        if (transform.position == target.position)
        {
            target.position = (target.position == the) ? end : the;
        }
    }
}
