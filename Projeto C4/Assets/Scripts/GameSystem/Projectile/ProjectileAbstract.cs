using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAbstract : MonoBehaviour
{
	protected GameObject projectileDead;
	protected Vector2 lastPosition;
	protected float moveSpeed = 20f;
	protected int damage;
}
