using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public void CreateTowerType(TowerType towerType)
    {
        switch(towerType.towerMode)
        {
            case TowerMode.Mele:
                gameObject.AddComponent<TowerMele>().towerType = towerType;
                break;
            case TowerMode.Range:
                gameObject.AddComponent<TowerRange>().towerType = towerType;
                break;
        }
        Destroy(this);
    }
}
