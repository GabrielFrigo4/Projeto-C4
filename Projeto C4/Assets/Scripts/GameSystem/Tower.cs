using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Tower : MonoBehaviour
{
	public TowerType type;
	Vector3 projectileShootFromPositon;
	GameObject rangeObj;
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon").position;
	}
	
	void Start()
	{
		rangeObj = gameObject.transform.Find("distancia").gameObject;
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Projectile.Create(projectileShootFromPositon, GetMouseWorldPosition());
		}
		
		rangeObj.transform.localScale = new Vector3(type.range, type.range, 1);
	}
}
