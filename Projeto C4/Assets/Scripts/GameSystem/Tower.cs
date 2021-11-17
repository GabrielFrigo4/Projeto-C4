using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Tower : MonoBehaviour
{
	public TowerType type;
	Vector3 projectileShootFromPositon;
	GameObject rangeObj;

	public List<Enemy> allEnemys = new List<Enemy>();
	
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
		allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());
		List<Enemy> removeEnemys = new List<Enemy>();
		foreach (Enemy enemy in allEnemys)
        {
			if (GetDistance2D(enemy.transform.position, transform.position) <= type.range) continue;
			removeEnemys.Add(enemy);
        }

		foreach (Enemy enemy in removeEnemys)
		{
			allEnemys.Remove(enemy);
		}

		if(allEnemys.Count > 0)
        {
			Projectile.Create(projectileShootFromPositon, allEnemys[allEnemys.Count - 1].gameObject.transform.position);
		}

		if (Input.GetMouseButtonDown(0))
		{
			Projectile.Create(projectileShootFromPositon, GetMouseWorldPosition());
		}
		
		rangeObj.transform.localScale = new Vector3(type.range, type.range, 1);
	}
}
