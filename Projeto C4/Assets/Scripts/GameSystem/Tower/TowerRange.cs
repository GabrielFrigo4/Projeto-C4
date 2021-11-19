using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TowerRange: TowerAbstratc
{
	Vector3 projectileShootFromPositon;
	Enemy enemySelect = null;
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon").position;
	}
	
	void Update()
	{
		//pega os inimigos no alcance da torre
		GetEnemyInRange();

		//seleciona o inimigo que estiver mais perto do final
		if (allEnemys.Count > 0)
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
	}
	
	//atira no inimigo selecionado
	protected override IEnumerator AttackTower(float time)
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
