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
	RangeSolo = 0,
	RangeArea = 1,
	MeleSolo = 2,
	MeleArea = 3,
}
