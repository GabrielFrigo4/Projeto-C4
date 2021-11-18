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
	int hp;

	private Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
		animator.runtimeAnimatorController = inimigoType.animatorControler;

		randomPos = new Vector2(Random.Range(-0.35f, 0.35f), Random.Range(-0.35f, 0.35f));
		destroySelfDistance = Random.Range(0.35f, 0.65f);
		
		hp = inimigoType.hp;
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
	}

	public void PassedOn()
    {
		GameIA.PlayerHp -= 1;
		Debug.Log(GameIA.PlayerHp);
		Destroy(gameObject);
    }
	
	void IDamage.Damage(int damage)
	{
		hp -= damage;
		if(hp <= 0) Destroy(gameObject);
	}
}
