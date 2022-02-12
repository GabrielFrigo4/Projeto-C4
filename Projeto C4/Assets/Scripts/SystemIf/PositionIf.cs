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
#elif UNITY_STANDALONE_WIN
            if (pla == Plataform.Windows)
            {
                plataformIsUsing = true;
            }
#endif
        }
        if (plataformIsUsing)
        {
            if(tranformType == TranformType.RectTranform)
            {
                gameObject.GetComponent<RectTransform>().localPosition = newPosition;
            }
            if (tranformType == TranformType.Tranform)
            {
                transform.localPosition = newPosition;
            }
        }
    }
}
