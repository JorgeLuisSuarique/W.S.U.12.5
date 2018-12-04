using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsMove : MonoBehaviour
{
    float mouseY;
    public GameObject cuerpo;

    void Update()
    {
        if (Pausa.isPause)
        {
            return;
        }
        else
        {
            mouseY += Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, -45.0f, 45.0f);
            transform.eulerAngles = new Vector3(0, 0, mouseY);
        }
        if (Tutorial.isTutorial)
        {
            return;
        }
    }
}
