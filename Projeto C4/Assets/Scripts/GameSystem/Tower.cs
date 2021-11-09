using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Tower : MonoBehaviour
{
	Vector3 projectileShootFromPositon;
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon").position;
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Projectile.Create(projectileShootFromPositon, GetMouseWorldPosition());
		}
	}
}
