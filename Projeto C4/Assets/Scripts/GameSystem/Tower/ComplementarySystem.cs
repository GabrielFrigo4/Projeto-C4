using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class ComplementarySystem : MonoBehaviour
{
    [SerializeField] int damage, total;
    [SerializeField] float time;
    private Animator animator;
    private IEnumerator corroutineDamage, corroutineDie;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        corroutineDamage = StartDamage(time);
        StartCoroutine(corroutineDamage);
        corroutineDie = StartDie(time*total);
        StartCoroutine(corroutineDie);
    }

    IEnumerator StartDamage(float time)
    {
        while(total > 0)
        {
            yield return new WaitForSeconds(time);
            total--;
            foreach(Enemy enemy in GetEnemyInRange())
            {
                enemy.Damage(damage);
            }
        }
        yield break;
    }

    IEnumerator StartDie(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    List<Enemy> GetEnemyInRange()
    {
        //pega todos os inimigos na scene
        List<Enemy> allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());

        //remove os inimigos que estão longe do range
        List<Enemy> removeEnemys = new List<Enemy>();
        foreach (Enemy enemy in allEnemys)
        {
            if (GetDistance2D(enemy.transform.position, transform.position) <= 1f) continue;
            removeEnemys.Add(enemy);
        }
        foreach (Enemy enemy in removeEnemys)
        {
            allEnemys.Remove(enemy);
        }

        return allEnemys;
    }
}
