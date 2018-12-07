using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveEnemy : MonoBehaviour
{
    public float vida;
    public float maximaVida;
    public Image barraVida;
    
    void Start ()
    {
        maximaVida = vida;
        ActualizeUI();
    }

    public void Applyvida(int Ivida)
    {
        vida = vida - Ivida;
        ActualizeUI();
    }

    public void Applyrecaga(int Rvida)
    {
        vida = vida + Rvida;
        ActualizeUI();
    }

    public void ActualizeUI()
    {
        barraVida.fillAmount = (vida / maximaVida);
    }
}
