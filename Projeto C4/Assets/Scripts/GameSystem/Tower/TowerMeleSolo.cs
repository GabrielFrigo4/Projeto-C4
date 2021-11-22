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
    }
	
	//atira no inimigo selecionado
	protected override IEnumerator AttackTower(float time)
    {
		while(true)
		{	
			if(enemySelect != null && allEnemys.Contains(enemySelect))
			{
				animator.SetBool("Ataque", true);
				time -= 0.3f;
				yield return new WaitForSeconds(0.3f);
				if(enemySelect != null && allEnemys.Contains(enemySelect))
				{
					enemySelect.Damage(2);
					attack = true;
				}
				else
				{
					attack = false;
				}
				time -= 0.1f;
				yield return new WaitForSeconds(0.1f);
				animator.SetBool("Ataque", false);
				yield return new WaitForSeconds(time);
			}
			else
			{
				animator.SetBool("Ataque", false);
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
    }
}
