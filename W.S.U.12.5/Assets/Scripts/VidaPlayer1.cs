using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer1 : MonoBehaviour
{
    public float vida;
    public float maximaVida;
    public Image barraVida;
    public Transform player;
    public Transform Spawnpoint;

    void Start()
    {
        maximaVida = vida;
        ActualizeUI();
    }

    public void Applyvida(int Ivida)
    {
        vida = vida - Ivida;
        ActualizeUI();
        if (vida <= 0)
        {
            player.transform.position = Spawnpoint.position;
            vida = maximaVida;
        }
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
