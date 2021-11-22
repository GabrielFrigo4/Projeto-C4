using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Projectile : MonoBehaviour
{
	Enemy target;
	Vector2 lastTargetPositon, lastPosition;
	float moveSpeed = 20f;
	GameObject projectileDead;
	
	public static void Create(Vector3 spawnPosition, Enemy target)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("Projectile"), spawnPosition, Quaternion.identity).transform;
		
		Projectile projectile = arrowTranform.GetComponent<Projectile>();
		projectile.Setup(target);
	}

    void Setup(Enemy target)
	{
		this.target = target;
	}

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
			
			if(Vector2.Distance(transform.position, lastTargetPositon) < 0.75f)
			{
				Vector2 moveDir = (lastTargetPositon - (Vector2)lastPosition).normalized;
				lastPosition = (Vector3)(lastTargetPositon - (Vector2)moveDir*0.75f);
		
				target.gameObject.GetComponent<Enemy>().Damage(1);
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
	
	void GotoPosition(Vector2 position, float moveSpeed)
	{
		Vector2 moveDir = (position - (Vector2)transform.position).normalized;
			
		transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
			
		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}
}
