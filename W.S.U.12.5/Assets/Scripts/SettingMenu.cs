using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider volumen;
    public AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = volumen.value;
    }

}
