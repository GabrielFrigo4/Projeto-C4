using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Tower : MonoBehaviour
{
	public TowerType type;
	Vector3 projectileShootFromPositon;
	GameObject rangeObj;
	Enemy enemySelect = null;

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
		//pega todos os inimigos na scene
		allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());
		
		//remove os inimigos que estão longe do range
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
		
		//seleciona o inimigo que estiver mais perto do final
		if(allEnemys.Count > 0)
        {
			if(enemySelect == null || !allEnemys.Contains(enemySelect))
			{
				enemySelect = allEnemys[0];
				foreach(Enemy en in allEnemys)
				{
					if(en.path.Count < enemySelect.path.Count)
					{
						enemySelect = en;
					}
					else if(en.path.Count == enemySelect.path.Count)
					{
						if(GetDistance2D(en.path[0], en.path[1]) < GetDistance2D(enemySelect.path[0], enemySelect.path[1]))
						{
							enemySelect = en;
						}
					}
				}
			}
		}
		
		//atira no inimigo selecionado
		if(enemySelect != null)
        {
			Projectile.Create(projectileShootFromPositon, enemySelect.gameObject.transform.position);
		}

		if (Input.GetMouseButtonDown(0))
		{
			Projectile.Create(projectileShootFromPositon, GetMouseWorldPosition());
		}
		
		rangeObj.transform.localScale = new Vector3(type.range, type.range, 1);
	}
}
