using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TowerRangeSolo: TowerAbstratc
{
	Transform projectileShootFromPositon;
	Enemy enemySelect = null;
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon");
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
			
			//mirar no inimigo
			Vector2 moveDir = ((Vector2)enemySelect.transform.position - (Vector2)transform.position).normalized;
			float angle = GetAngleFromVector(moveDir);
			transform.eulerAngles = new Vector3(0, 0, angle);
		}

		UpdateRotateRange();
	}
	
	//atira no inimigo selecionado
	protected override IEnumerator AttackTower(float time)
    {
		while(true)
		{
			if(enemySelect != null && allEnemys.Contains(enemySelect))
			{
				ProjectileCelulaB.Create(projectileShootFromPositon.position, enemySelect, towerType.damage);
			}
			yield return new WaitForSeconds(time);	
		}
    }
}
