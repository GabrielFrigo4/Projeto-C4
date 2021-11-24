using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TiroNeutrofiloExplodindo : MonoBehaviour
{
    [HideInInspector] public int damage;
    [SerializeField] float range;
	List<Enemy> allEnemys = new List<Enemy>();

    void GetEnemyInRange()
    {
        //pega todos os inimigos na scene
        allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());

        //remove os inimigos que estão longe do range
        List<Enemy> removeEnemys = new List<Enemy>();
        foreach (Enemy enemy in allEnemys)
        {
            if (GetDistance2D(enemy.transform.position, transform.position) <= range) continue;
            removeEnemys.Add(enemy);
        }
        foreach (Enemy enemy in removeEnemys)
        {
            allEnemys.Remove(enemy);
        }
    }

    void Start()
    {
        GetEnemyInRange();

        foreach(Enemy enemy in allEnemys)
        {
            enemy.Damage(damage);
        }
    }
}
