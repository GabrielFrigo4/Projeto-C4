using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Projectile : MonoBehaviour
{
	Vector3 targetPosition;
	
	public static void Create(Vector3 spawnPosition, Vector3 targetPosition)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("Projectile"), spawnPosition, Quaternion.identity).transform;
		
		Projectile projectile = arrowTranform.GetComponent<Projectile>();
		projectile.Setup(targetPosition);
	}
	
	void Setup(Vector3 targetPosition)
	{
		this.targetPosition = targetPosition;
	}	
	
	void Update()
	{
		Vector2 moveDir = ((Vector2)targetPosition - (Vector2)transform.position).normalized;
		
		float moveSpeed = 60f;
		
		transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
		
		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);
		
		float destroySelfDistance = 1f;
		if(Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
		{
			Destroy(gameObject);
		}
	}
}
