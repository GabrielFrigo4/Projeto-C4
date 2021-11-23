using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCelulaB : ProjectileAbstract
{
    public static void Create(Vector3 spawnPosition, Enemy target, int damage)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("ProjectileCelulaB"), spawnPosition, Quaternion.identity).transform;
		
		ProjectileCelulaB projectile = arrowTranform.GetComponent<ProjectileCelulaB>();
		projectile.SetDamage(damage);
		projectile.Setup(target);
	}
}