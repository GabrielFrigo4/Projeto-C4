using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TowerRangeArea : TowerAbstratc
{
	[HideInInspector] public AudioClip clipDie;
	float timeDestroy = 84f/60f;
	Transform projectileShootFromPositon;
	Enemy enemySelect = null;
	IEnumerator corroutineDestroy, corroutineDie;
	bool attack = false, isDie = false;
	int bullet = 12;
	Vector3 lastEnemyPosition;
	
    void Awake()
	{
		projectileShootFromPositon = transform.Find("projectileShootFromPositon");
		corroutineDestroy = DieDestroy(timeDestroy);
		corroutineDie = DieDamage(0.8f);
	}
	
	void Update()
	{
		//pega os inimigos no alcance da torre
		GetEnemyInRange();

		if(!attack && !isDie)
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
		if(enemySelect != null && allEnemys.Contains(enemySelect) && !isDie)
		{
			lastEnemyPosition = enemySelect.transform.position;
			Vector2 moveDir = ((Vector2)enemySelect.transform.position - (Vector2)transform.position).normalized;
			float angle = GetAngleFromVector(moveDir);
			transform.eulerAngles = new Vector3(0, 0, angle);
		}
        else if(isDie)
        {
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		
		UpdateRotateRange();
	}

	void DamageAllEnemyInRangeDie()
	{
		SoundPlay.PlayClip(clipDie, new Address<float>(in SliderScript.volumeSound), false, false, "Torre Morrendo");
		
		//pega todos os inimigos na scene
		allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());

		foreach (Enemy enemy in allEnemys)
		{
			if (GetDistance2D(enemy.transform.position, transform.position) <= 3.7f) enemy.Damage(towerType.damage);
		}
	}

	//atira no inimigo selecionado
	protected override IEnumerator AttackTower(float time)
    {
		while(true)
		{	
			if(enemySelect != null && allEnemys.Contains(enemySelect) && !isDie)
			{
				animator.SetBool("Ataque", true);
				attack = true;
				yield return new WaitForSeconds(time - Time.deltaTime);
				ProjectileNeutrofilo.Create(projectileShootFromPositon.position, lastEnemyPosition, damage);
				bullet--;
				if (bullet <= 0 && !isDie)
				{
					animator.SetBool("Morto", true);
					isDie = true;
					StartCoroutine(corroutineDestroy);
					StartCoroutine(corroutineDie);
				}
			}
			else
			{
				animator.SetBool("Ataque", false);
				attack = false;
				yield return new WaitForSeconds(Time.unscaledDeltaTime);
			}
		}
    }

	IEnumerator DieDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
	
	IEnumerator DieDamage(float time)
	{
		yield return new WaitForSeconds(time - Time.deltaTime);
		DamageAllEnemyInRangeDie();
	}
}
