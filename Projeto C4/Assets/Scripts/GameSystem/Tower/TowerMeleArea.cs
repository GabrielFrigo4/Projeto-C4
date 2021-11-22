using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMeleArea : TowerAbstratc
{
    // Update is called once per frame
    void Update()
    {
        //pega os inimigos no alcance da torre
        GetEnemyInRange();
    }

    protected override IEnumerator AttackTower(float time)
    {
        while (true)
        {
            foreach(Enemy enemy in allEnemys)
            {
                if(enemy != null)
                    enemy.Damage(1);
            }
            yield return new WaitForSeconds(time);
        }
    }
}
