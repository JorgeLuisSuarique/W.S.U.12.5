using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;

    public static bool InputHabilitado = true;
    public static bool isTutorial = true;

    public void PausarJuego()
    {
        if (Time.timeScale == 1.0F)
        {
            InputHabilitado = false;
            Time.timeScale = 0.0F;
            isTutorial = !isTutorial;
        }
        else
        {
            Time.timeScale = 1.0F;
            InputHabilitado = true;
            isTutorial = false; 
        }
    }

    public void PanelTutorial()
    {
        tutorial.SetActive(false);
    }
}
