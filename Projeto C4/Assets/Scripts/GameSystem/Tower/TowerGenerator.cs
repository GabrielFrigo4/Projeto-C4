using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
	public AudioClip soundDeadNeutrofilo;
	
    public void CreateTowerType(TowerType towerType)
    {
        switch(towerType.towerMode)
        {
            case TowerMode.MeleArea:
                gameObject.AddComponent<TowerMeleArea>().towerType = towerType;
                break;
			case TowerMode.MeleSolo:
                gameObject.AddComponent<TowerMeleSolo>().towerType = towerType;
                break;
            case TowerMode.RangeArea:
                TowerRangeArea range = gameObject.AddComponent<TowerRangeArea>();
				range.towerType = towerType;
				range.clipDie = soundDeadNeutrofilo;
                break;
			case TowerMode.RangeSolo:
                gameObject.AddComponent<TowerRangeSolo>().towerType = towerType;
                break;
        }
        Destroy(this);
    }
}
