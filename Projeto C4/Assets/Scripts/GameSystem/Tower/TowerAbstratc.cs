using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public abstract class TowerAbstratc : MonoBehaviour
{
    private bool showRange;
    public bool ShowRange
    {
        get
        {
            return showRange;
        }
            
        set
        {
            showRange = value;
            rangeObj.SetActive(showRange);
        }
    }
    public TowerType towerType;
    public List<Enemy> allEnemys = new List<Enemy>();
    protected GameObject rangeObj;
    protected IEnumerator coroutine;
	public int damage;

    protected abstract IEnumerator AttackTower(float time);

    protected Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = towerType.animatorControler;

        rangeObj = gameObject.transform.Find("distancia").gameObject;
        ShowRange = false;

        coroutine = AttackTower(towerType.time);
        StartCoroutine(coroutine);
    }

    protected void GetEnemyInRange()
    {
        //pega todos os inimigos na scene
        allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());

        //remove os inimigos que estão longe do range
        List<Enemy> removeEnemys = new List<Enemy>();
        foreach (Enemy enemy in allEnemys)
        {
            if (GetDistance2D(enemy.transform.position, transform.position) <= towerType.range + 0.2f) continue;
            removeEnemys.Add(enemy);
        }
        foreach (Enemy enemy in removeEnemys)
        {
            allEnemys.Remove(enemy);
        }
    }

    protected void UpdateRotateRange()
    {
        rangeObj.transform.localEulerAngles = new Vector3(-transform.eulerAngles.x, -transform.eulerAngles.y, -transform.eulerAngles.z);
        rangeObj.transform.localScale = new Vector3(towerType.range, towerType.range, 1);
    }
}
