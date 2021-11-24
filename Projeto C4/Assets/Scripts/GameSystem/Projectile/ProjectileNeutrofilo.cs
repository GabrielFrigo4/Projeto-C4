using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class ProjectileNeutrofilo : MonoBehaviour
{
	Vector2 moveDir;
	GameObject projectileDead;
	Vector2 lastPosition;
	float moveSpeed = 20f;
	int damage;
	List<Enemy> allEnemys = new List<Enemy>();
	[SerializeField] float range;

	void Start()
	{
		projectileDead = (GameObject)Resources.Load("TiroNeutrofiloExplodindo");
	}

	void Update()
	{
		lastPosition = transform.position;
		GotoDirection(moveDir, moveSpeed);

		if (GetEnemyInRange()) 
		{
			GameObject obj = Instantiate(projectileDead, lastPosition, transform.rotation);
			obj.GetComponent<TiroNeutrofiloExplodindo>().damage = damage;
			Destroy(gameObject);
		}
	}

	bool GetEnemyInRange()
    {
        //pega todos os inimigos na scene
        allEnemys = new List<Enemy>(FindObjectsOfType<Enemy>());

        foreach (Enemy enemy in allEnemys)
        {
            if (GetDistance2D(enemy.transform.position, transform.position) <= range) return true;
        }
		return false;
    }

	void GotoDirection(Vector2 direction, float moveSpeed)
	{
		transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
			
		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}

    public static void Create(Vector3 spawnPosition, Vector3 target, int damage)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("ProjectileNeutrofilo"), spawnPosition, Quaternion.identity).transform;
		
		ProjectileNeutrofilo projectile = arrowTranform.GetComponent<ProjectileNeutrofilo>();
		projectile.damage = damage;
		projectile.moveDir = ((Vector2)target - (Vector2)projectile.transform.position).normalized;;
	}
}