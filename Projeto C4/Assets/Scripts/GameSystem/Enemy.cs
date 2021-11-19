using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Enemy : MonoBehaviour, IDamage
{
	public InimigoType inimigoType;
	
	public List<Vector2> path = new List<Vector2>();
	Vector2 randomPos;
	float destroySelfDistance, speed;
	private Animator animator;
	
	private GameObject lifeBar, hpBar;
	int hp;
	public int Hp
	{
		get
		{
			return hp;
		}
		
		set
		{
			hp = value;
			hpBar.transform.localScale = new Vector3((float)hp/(float)inimigoType.hp, 0.8f, 1f);
			hpBar.transform.localPosition = new Vector3((hpBar.transform.localScale.x - 1f)/2f, 0, 0);
		}
	}
	
	public void ShowLifeBar(bool show)
	{
		lifeBar.SetActive(show);
	}

	// Start is called before the first frame update
	void Start()
    {
		lifeBar = Instantiate((GameObject)Resources.Load("LifeBarEnemy"));
		lifeBar.transform.localScale = new Vector3(inimigoType.sizeLifeBar * lifeBar.transform.localScale.x, lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);
		hpBar = lifeBar.transform.GetChild(2).gameObject;
		ShowLifeBar(false);
		
		animator = GetComponent<Animator>();
		animator.runtimeAnimatorController = inimigoType.animatorControler;

		randomPos = new Vector2(Random.Range(-0.35f, 0.35f), Random.Range(-0.35f, 0.35f));
		destroySelfDistance = Random.Range(0.35f, 0.65f);
		
		Hp = inimigoType.hp;
	}

    // Update is called once per frame
    void Update()
    {	
		Vector2 targetPosition = path[0] * 2 + new Vector2(-15f, -8f) + randomPos;
		Vector2 moveDir = (targetPosition - (Vector2)transform.position).normalized;

		transform.position += (Vector3)moveDir * inimigoType.speed * Time.deltaTime;

		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);

		if (Vector2.Distance(transform.position, targetPosition) < destroySelfDistance)
		{
			if (path.Count > 1)
				path.RemoveAt(0);
			else
				PassedOn();
		}
		
		lifeBar.transform.position = new Vector3(transform.position.x, transform.position.y + inimigoType.heightLifeBar, transform.position.z);
		
		if(GetDistance2D(GetMouseWorldPosition(), transform.position) < inimigoType.rangeLifeBar && Time.timeScale != 0)
		{
			ShowLifeBar(true);
		}
		else
		{
			ShowLifeBar(false);
		}
	}

	void PassedOn()
    {
		GameIA.PlayerHp -= inimigoType.damage;
		Destroy(lifeBar);
		Destroy(gameObject);
    }
	
	void IDamage.Damage(int damage)
	{
		Hp -= damage;
		if(Hp <= 0) Dead();
	}
	
	void Dead()
	{
		GameIA.Kills++;
		Instantiate(inimigoType.dead, transform.position, transform.rotation);
		Destroy(lifeBar);
		Destroy(gameObject);
	}
}
