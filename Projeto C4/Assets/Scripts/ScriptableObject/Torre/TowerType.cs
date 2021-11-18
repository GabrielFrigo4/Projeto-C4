using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerType", menuName = "ScriptableObjects/TowerType")]
public class TowerType : ScriptableObject
{
	public RuntimeAnimatorController animatorControler;
	public TowerMode towerMode;
	public float range, time;
}

public enum TowerMode
{
	Range = 0,
	Mele = 1,
}
