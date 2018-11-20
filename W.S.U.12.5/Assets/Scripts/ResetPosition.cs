using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] private GameObject[] gos;
    [SerializeField] private Transform[] resetT;
    private int childCount;


    private void Awake()
    {
        childCount = transform.childCount;
    }

    private void ResetT()
    {
        resetT = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            resetT[i] = transform.GetChild(i);
        }
    }

    private void GetGoChilds()
    {
        gos = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            gos[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Start()
    {
        GetGoChilds();
    }

    private void Update()
    {
        ResetT();
    }

    private void OnBecameInvisible()
    {
        for (int i = 0; i < childCount; i++)
        {
            gos[i].transform.position = resetT[i].position;
        }
    }
}
