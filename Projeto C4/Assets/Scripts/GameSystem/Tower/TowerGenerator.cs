using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
	public AudioClip soundDeadNeutrofilo;
	
    public void CreateTowerType(TowerType towerType)
    {
		int damage = towerType.damage;
        switch(towerType.towerMode)
        {
            case TowerMode.MeleArea:
				if(UpgradeMenu.vaccine)
				{
					damage *= 2;
				}
                TowerMeleArea towerMeleArea = gameObject.AddComponent<TowerMeleArea>();
				towerMeleArea.towerType = towerType;
				towerMeleArea.damage = damage;
                break;
			case TowerMode.MeleSolo:
				if(UpgradeMenu.vaccine)
				{
					damage *= 2;
				}
                TowerMeleSolo towerMeleSolo = gameObject.AddComponent<TowerMeleSolo>();
				towerMeleSolo.towerType = towerType;
				towerMeleSolo.damage = damage;
                break;
            case TowerMode.RangeArea:
				if(UpgradeMenu.vaccine)
				{
					damage *= 2;
				}
                TowerRangeArea towerRangeArea = gameObject.AddComponent<TowerRangeArea>();
				towerRangeArea.towerType = towerType;
				towerRangeArea.clipDie = soundDeadNeutrofilo;
				towerRangeArea.damage = damage;
                break;
			case TowerMode.RangeSolo:
				if(UpgradeMenu.vaccine)
				{
					damage *= 2;
				}
                TowerRangeSolo towerRangeSolo = gameObject.AddComponent<TowerRangeSolo>();
				towerRangeSolo.towerType = towerType;
				towerRangeSolo.damage = damage;
                break;
        }
        Destroy(this);
    }
}
