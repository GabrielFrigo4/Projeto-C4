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
	
	private IEnumerator coroutine;

	public List<Enemy> allEnemys = new List<Enemy>();
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon").position;
	}
	
	void Start()
	{
		rangeObj = gameObject.transform.Find("distancia").gameObject;
		
		coroutine = ShotLoop(type.time);
        StartCoroutine(coroutine);
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
						if(GetDistance2D(en.path[0], en.transform.position) < GetDistance2D(enemySelect.path[0], enemySelect.transform.position))
						{
							enemySelect = en;
						}
					}
				}
			}
		}
		
		rangeObj.transform.localScale = new Vector3(type.range, type.range, 1);
	}
	
	//atira no inimigo selecionado
	private IEnumerator ShotLoop(float time)
    {
		while(true)
		{
			if(enemySelect != null)
			{
				Projectile.Create(projectileShootFromPositon, enemySelect.gameObject.transform);
			}
			yield return new WaitForSeconds(time);	
		}
    }
}
