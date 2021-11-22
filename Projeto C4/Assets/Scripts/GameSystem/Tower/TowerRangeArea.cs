using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeArea : TowerAbstratc
{
    // Update is called once per frame
    void Update()
    {
        //pega os inimigos no alcance da torre
		GetEnemyInRange();
    }
	
	//atira no inimigo selecionado
	protected override IEnumerator AttackTower(float time)
    {
		yield return null;
    }
}
