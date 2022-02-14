using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyExistIf : MonoBehaviour
{
    [SerializeField] Plataform[] plataforms;

    void Start()
    {
        bool plataformIsUsing = false;
        foreach (Plataform pla in plataforms)
        {
#if UNITY_IOS
            if(pla == Plataform.IOS)
            {
                plataformIsUsing = true;
            }
#elif UNITY_STANDALONE
            if (pla == Plataform.Desktop)
            {
                plataformIsUsing = true;
            }
#endif
        }
        if (!plataformIsUsing)
        {
            Destroy(gameObject);
        }
    }
}