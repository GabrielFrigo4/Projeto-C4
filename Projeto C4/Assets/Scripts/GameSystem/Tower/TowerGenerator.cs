using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
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
                gameObject.AddComponent<TowerRangeArea>().towerType = towerType;
                break;
			case TowerMode.RangeSolo:
                gameObject.AddComponent<TowerRangeSolo>().towerType = towerType;
                break;
        }
        Destroy(this);
    }
}
