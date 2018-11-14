using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject menuOpcion;
    [SerializeField]
    GameObject menu;

    public void CergarScena(string nombreScene)
    {
        SceneManager.LoadScene(nombreScene);
    }
    public void Creditos(string nombreScene)
    {
        SceneManager.LoadScene(nombreScene);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void MenuOp()
    {
        menu.SetActive(false);
        menuOpcion.SetActive(true);
    }
    public void Menu()
    {
        menu.SetActive(true);
        menuOpcion.SetActive(false);
    }

}
