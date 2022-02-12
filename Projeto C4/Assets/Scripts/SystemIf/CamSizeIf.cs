using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSizeIf : MonoBehaviour
{
    [SerializeField] Plataform[] plataforms;
    [SerializeField] int sizeCam;

    void Start()
    {
        bool plataformIsUsing = false;
        foreach (Plataform pla in plataforms)
        {
#if UNITY_IOS
            if (pla == Plataform.IOS)
            {
                plataformIsUsing = true;
            }
#elif UNITY_STANDALONE_WIN
            if (pla == Plataform.Windows)
            {
                plataformIsUsing = true;
            }
#endif
        }
        if (plataformIsUsing)
        {
            gameObject.GetComponent<Camera>().orthographicSize = sizeCam;
        }
    }
}