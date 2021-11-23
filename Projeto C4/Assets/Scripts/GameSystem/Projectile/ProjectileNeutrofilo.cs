using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNeutrofilo : ProjectileAbstract
{
    public static void Create(Vector3 spawnPosition, Enemy target, int damage)
	{
		Transform arrowTranform = Instantiate((GameObject)Resources.Load("ProjectileNeutrofilo"), spawnPosition, Quaternion.identity).transform;
		
		ProjectileNeutrofilo projectile = arrowTranform.GetComponent<ProjectileNeutrofilo>();
		projectile.SetDamage(damage);
		projectile.Setup(target);
	}
}