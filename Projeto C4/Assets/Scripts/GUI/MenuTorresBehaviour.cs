using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 1f;
    [SerializeField] GameObject miniC�lulaDendr�tica, miniNeutr�filo, miniC�lulaB, miniMacr�fago, preview;

    // Update is called once per frame
    void Update()
    {
        bool active = false;
        CheckButton(miniC�lulaDendr�tica, TowerMode.MeleArea, ref active);
        CheckButton(miniNeutr�filo, TowerMode.RangeArea, ref active);
        CheckButton(miniC�lulaB, TowerMode.RangeSolo, ref active);
        CheckButton(miniMacr�fago, TowerMode.MeleSolo, ref active);
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
