using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIf : MonoBehaviour
{
    [SerializeField] Plataform[] plataforms;
    [SerializeField] TranformType tranformType;
    [SerializeField] Vector3 newScale;

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
            if (tranformType == TranformType.RectTranform)
            {
                gameObject.GetComponent<RectTransform>().localScale = newScale;
            }
            if (tranformType == TranformType.Tranform)
            {
                transform.localScale = newScale;
            }
        }
    }
}