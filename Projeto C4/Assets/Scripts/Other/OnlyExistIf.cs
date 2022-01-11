using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyExistIf : MonoBehaviour
{
    public Plataform[] plataforms;

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
#elif UNITY_ANDROID
           if(pla == Plataform.Android)
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

public enum Plataform
{
    IOS = 0,
    Android = 1,
    Desktop = 2,
}