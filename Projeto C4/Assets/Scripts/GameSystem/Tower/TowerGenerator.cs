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
				if(UpgradeMenu.vaccine)
				{
					towerType.damage *= 2;
				}
                gameObject.AddComponent<TowerMeleArea>().towerType = towerType;
                break;
			case TowerMode.MeleSolo:
				if(UpgradeMenu.vaccine)
				{
					towerType.damage *= 2;
				}
                gameObject.AddComponent<TowerMeleSolo>().towerType = towerType;
                break;
            case TowerMode.RangeArea:
				if(UpgradeMenu.vaccine)
				{
					towerType.damage *= 2;
				}
                TowerRangeArea range = gameObject.AddComponent<TowerRangeArea>();
				range.towerType = towerType;
				range.clipDie = soundDeadNeutrofilo;
                break;
			case TowerMode.RangeSolo:
				if(UpgradeMenu.vaccine)
				{
					towerType.damage *= 2;
				}
                gameObject.AddComponent<TowerRangeSolo>().towerType = towerType;
                break;
        }
        Destroy(this);
    }
}
