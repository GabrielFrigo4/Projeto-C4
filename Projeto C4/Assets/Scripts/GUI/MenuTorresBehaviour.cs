using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 1f;
    [SerializeField] GameObject miniCélulaDendrítica, miniNeutrófilo, miniCélulaB, miniMacrófago;

    // Update is called once per frame
    void Update()
    {
        CheckButton(miniCélulaDendrítica, TowerMode.MeleArea);
        CheckButton(miniNeutrófilo, TowerMode.RangeArea);
        CheckButton(miniCélulaB, TowerMode.RangeSolo);
        CheckButton(miniMacrófago, TowerMode.MeleSolo);
    }

    void CheckButton(GameObject button, TowerMode mode)
    {
        if (size > GetDistance2D(button.transform.position, GetMouseWorldPosition()))
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (mode)
                {
                    case TowerMode.MeleArea:
                        GameIA.SpawnTower("TowerMeleArea", transform.position, gridPosition);
                        Destroy(gameObject);
                        break;
                    case TowerMode.MeleSolo:
                        GameIA.SpawnTower("TowerMeleSolo", transform.position, gridPosition);
                        Destroy(gameObject);
                        break;
                    case TowerMode.RangeArea:
                        GameIA.SpawnTower("TowerRangeArea", transform.position, gridPosition);
                        Destroy(gameObject);
                        break;
                    case TowerMode.RangeSolo:
                        GameIA.SpawnTower("TowerRangeSolo", transform.position, gridPosition);
                        Destroy(gameObject);
                        break;
                }
            }
            else
            {
                button.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            }
        }
        else
        {
            button.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
