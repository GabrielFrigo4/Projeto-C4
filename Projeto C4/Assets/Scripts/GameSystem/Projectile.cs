using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Projectile : MonoBehaviour
{
	Transform targetPosition;
	Vector2 lastPositon;
	float moveSpeed = 60f;
	GameObject projectileDead;
	
	public static void Create(Vector3 spawnPosition, Transform targetPosition)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("Projectile"), spawnPosition, Quaternion.identity).transform;
		
		Projectile projectile = arrowTranform.GetComponent<Projectile>();
		projectile.Setup(targetPosition);
	}

    void Setup(Transform targetPosition)
	{
		this.targetPosition = targetPosition;
	}

	void Start()
	{
		projectileDead = (GameObject)Resources.Load("TiroExplodindo");
	}

	void Update()
	{
		if(targetPosition != null)
		{
			lastPositon = targetPosition.position;	
			GotoPosition(lastPositon, moveSpeed);
			
			if(Vector2.Distance(transform.position, lastPositon) < Time.deltaTime * moveSpeed)
			{
				targetPosition.gameObject.GetComponent<Enemy>().Damage(1);
				Instantiate(projectileDead, transform.position, transform.rotation);
				Destroy(gameObject);
			}	
		}
		else
		{
			GotoPosition(lastPositon, moveSpeed);
			
			if(Vector2.Distance(transform.position, lastPositon) < Time.deltaTime * moveSpeed)
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
