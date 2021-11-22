using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 1f;
    [SerializeField] GameObject miniCélulaDendrítica, miniNeutrófilo, miniCélulaB, miniMacrófago, preview;

    // Update is called once per frame
    void Update()
    {
        bool active = false;
        CheckButton(miniCélulaDendrítica, TowerMode.MeleArea, ref active);
        CheckButton(miniNeutrófilo, TowerMode.RangeArea, ref active);
        CheckButton(miniCélulaB, TowerMode.RangeSolo, ref active);
        CheckButton(miniMacrófago, TowerMode.MeleSolo, ref active);
        if (!active) preview.SetActive(false);
    }

    void CheckButton(GameObject button, TowerMode mode, ref bool active)
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
                preview.SetActive(true);
                active = true;
            }
        }
        else
        {
            button.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
