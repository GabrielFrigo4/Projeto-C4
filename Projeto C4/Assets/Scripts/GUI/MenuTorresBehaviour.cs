using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 0.6f;
    [SerializeField] GameObject miniC�lulaDendr�tica, miniNeutr�filo, miniC�lulaB, miniMacr�fago;
    [SerializeField] GameObject previewC�lulaDendr�tica, previewNeutr�filo, previewC�lulaB, previewMacr�fago;

    void Start()
    {
        SetRangeScale(previewC�lulaDendr�tica, "TowerMeleArea");
        SetRangeScale(previewNeutr�filo, "TowerRangeArea");
        SetRangeScale(previewC�lulaB, "TowerRangeSolo");
        SetRangeScale(previewMacr�fago, "TowerMeleSolo");
    }

    void Update()
    {
        CheckButton(miniC�lulaDendr�tica, previewC�lulaDendr�tica, TowerMode.MeleArea);
        CheckButton(miniNeutr�filo, previewNeutr�filo, TowerMode.RangeArea);
        CheckButton(miniC�lulaB, previewC�lulaB, TowerMode.RangeSolo);
        CheckButton(miniMacr�fago, previewMacr�fago, TowerMode.MeleSolo);
    }

    void CheckButton(GameObject button, GameObject preview, TowerMode mode)
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
            }
        }
        else
        {
            button.transform.localScale = new Vector3(1f, 1f, 1f);
            preview.SetActive(false);
        }
    }

    void SetRangeScale(GameObject previewRange, string data)
    {
        float scale = ((TowerType)Resources.Load(data)).range;
        previewRange.transform.Find("Range").localScale = new Vector3(scale, scale, 1);
    }
}