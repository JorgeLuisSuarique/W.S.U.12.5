using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;
    public GameObject PanelPausa;
    public GameObject OpcionPauce;
    public GameObject opciones;
    public GameObject tutorial;
    public static bool InputHabilitado = true;
    public static bool isPause = true;

    private void Start()
    {
        isPause = true;
    }

    public void PausarJuego()
    {
        if (Time.timeScale == 1.0F)
        {
            InputHabilitado = false;
            PausarJ();
            Time.timeScale = 0.0F;
            isPause = !isPause;
        }
        else
        {
            Time.timeScale = 1.0F;
            PanelJuego();
            InputHabilitado = true;
            isPause = false; 
        }
    }

    public void PausarJ()
    {
        pausa.SetActive(false);
        PanelPausa.SetActive(true);
    }
    public void PanelJuego()
    {
        pausa.SetActive(true);
        PanelPausa.SetActive(false);
    }
    public void Opciones()
    {
        OpcionPauce.SetActive(false);
        opciones.SetActive(true);
    }
    public void Pauce()
    {
        OpcionPauce.SetActive(false);
        opciones.SetActive(false);
    }
    public void PanelTutorial()
    {
        tutorial.SetActive(false);
        isPause = false;
    }

    public void MenuScene(string nombreScene)
    {
        SceneManager.LoadScene(nombreScene);
    }
    public void SetMuteVol(bool i)
    {
    }
    public void SetMuteMus(bool iterMute)
    {

    }
}
