using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateImages : MonoBehaviour
{
	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}
    void OnMouseOver()
	{
		animator.SetBool("Purchased", true);
		
	}
	void OnMouseExit()
	{
		animator.SetBool("Purchased", false);
	}
}
