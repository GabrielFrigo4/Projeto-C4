using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/EnemyType")]
public class InimigoType : ScriptableObject
{
    public RuntimeAnimatorController animatorControler;
    public int hp, damage;
    public float speed;
	public GameObject dead;
}