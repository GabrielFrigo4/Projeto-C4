using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScale : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(1/transform.parent.transform.localScale.x,1/transform.parent.transform.localScale.y);
    }
}
