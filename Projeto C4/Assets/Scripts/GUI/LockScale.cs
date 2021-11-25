using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScale : MonoBehaviour
{
	Animator animator;
	void Start() 
	{
		animator = GetComponentInParent<Animator>();
	}
    void Update()
    {
        transform.localScale = new Vector3(1/transform.parent.transform.localScale.x,1/transform.parent.transform.localScale.y);
		if (animator.GetBool("Purchased")) {
			Destroy(this.gameObject,0);
		}
    }
}
