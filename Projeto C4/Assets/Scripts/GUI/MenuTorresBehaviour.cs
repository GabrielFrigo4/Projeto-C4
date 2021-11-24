using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 0.6f;
    [SerializeField] GameObject miniCelulaDendritica, miniNeutrofilo, miniCelulaB, miniMacrofago;
    [SerializeField] GameObject previewCelulaDendritica, previewNeutrofilo, previewCelulaB, previewMacrofago;

    void Start()
    {
        SetRangeScale(previewCelulaDendritica, "TowerMeleArea");
        SetRangeScale(previewNeutrofilo, "TowerRangeArea");
        SetRangeScale(previewCelulaB, "TowerRangeSolo");
        SetRangeScale(previewMacrofago, "TowerMeleSolo");
    }

    void Update()
    {
        CheckButton(miniCelulaDendritica, previewCelulaDendritica, TowerMode.MeleArea);
        CheckButton(miniNeutrofilo, previewNeutrofilo, TowerMode.RangeArea);
        CheckButton(miniCelulaB, previewCelulaB, TowerMode.RangeSolo);
        CheckButton(miniMacrofago, previewMacrofago, TowerMode.MeleSolo);
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