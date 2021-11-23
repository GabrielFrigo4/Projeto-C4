using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public abstract class ProjectileAbstract : MonoBehaviour
{
	Enemy target;
	Vector2 lastTargetPositon, lastPosition;
	float moveSpeed = 20f;
	GameObject projectileDead;
	int damage;

	void Start()
	{
		projectileDead = (GameObject)Resources.Load("TiroExplodindo");
	}

	void Update()
	{
		if(target != null)
		{
			lastPosition = transform.position;
			lastTargetPositon = target.transform.position;	
			GotoPosition(lastTargetPositon, moveSpeed);

			if (Vector2.Distance(transform.position, lastTargetPositon) < 0.75f) 
			{
				Vector2 moveDir = (lastTargetPositon - (Vector2)lastPosition).normalized;
				lastPosition = (Vector3)(lastTargetPositon - (Vector2)moveDir*0.75f);
		
				target.gameObject.GetComponent<Enemy>().Damage(damage);
				Instantiate(projectileDead, lastPosition, transform.rotation);
				Destroy(gameObject);
			}	
		}
		else
		{
			GotoPosition(lastTargetPositon, moveSpeed);
			
			if(Vector2.Distance(transform.position, lastTargetPositon) < Time.deltaTime * moveSpeed)
			{
				Instantiate(projectileDead, transform.position, transform.rotation);
				Destroy(gameObject);
			}	
		}
	}
	
	protected void SetDamage(int newDamage)
	{
		this.damage = newDamage;
	}
	
    protected void Setup(Enemy target)
	{
		this.target = target;
		lastTargetPositon = target.transform.position;
	}
	
	protected void GotoPosition(Vector2 position, float moveSpeed)
	{
		Vector2 moveDir = (position - (Vector2)transform.position).normalized;
			
		transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
			
		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}
}
