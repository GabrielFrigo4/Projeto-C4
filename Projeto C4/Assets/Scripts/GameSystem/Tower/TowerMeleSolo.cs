using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TowerMeleSolo : TowerAbstratc
{
	Enemy enemySelect = null;
	bool attack = false;
	
	
    // Update is called once per frame
    void Update()
    {
		//pega os inimigos no alcance da torre
		GetEnemyInRange();
			
		if(!attack)
		{
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
		
		//mirar no inimigo
		if(enemySelect != null || allEnemys.Contains(enemySelect))
		{
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
				animator.SetBool("Ataque", true);
				enemySelect.Damage(1);
				attack = true;
				yield return new WaitForSeconds(time/2f);
			}
			else
			{
				animator.SetBool("Ataque", false);
				attack = false;
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
    }
}
