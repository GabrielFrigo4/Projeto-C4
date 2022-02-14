using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionIf : MonoBehaviour
{
    [SerializeField] Plataform[] plataforms;
    [SerializeField] TranformType tranformType;
    [SerializeField] Vector3 newPosition;

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
#elif UNITY_STANDALONE
            if (pla == Plataform.Desktop)
            {
                plataformIsUsing = true;
            }
#endif
        }
        if (plataformIsUsing)
        {
            if(tranformType == TranformType.RectTranform)
            {
                RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = newPosition;
            }
            if (tranformType == TranformType.Tranform)
            {
                transform.localPosition = newPosition;
            }
        }
    }
}
