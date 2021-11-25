using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CodeUtils;

public class MenuTorresBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2Int gridPosition;
	[SerializeField] float size = 0.6f;
    [SerializeField] int costCelulaDendritica, costNeutrofilo, costCelulaB, costMacrofago;
    [SerializeField] GameObject miniCelulaDendritica, miniNeutrofilo, miniCelulaB, miniMacrofago;
    [SerializeField] GameObject previewCelulaDendritica, previewNeutrofilo, previewCelulaB, previewMacrofago;

    private Text textCelulaDendritica, textNeutrofilo, textCelulaB, textMacrofago;

    void Start()
    {
        SetRangeScale(previewCelulaDendritica, "TowerMeleArea");
        SetRangeScale(previewNeutrofilo, "TowerRangeArea");
        SetRangeScale(previewCelulaB, "TowerRangeSolo");
        SetRangeScale(previewMacrofago, "TowerMeleSolo");

        textCelulaDendritica = previewCelulaDendritica.transform.Find("Canvas").Find("Text").GetComponent<Text>();
        textNeutrofilo = previewNeutrofilo.transform.Find("Canvas").Find("Text").GetComponent<Text>();
        textCelulaB = previewCelulaB.transform.Find("Canvas").Find("Text").GetComponent<Text>();
        textMacrofago = previewMacrofago.transform.Find("Canvas").Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        CheckButton(miniCelulaDendritica, previewCelulaDendritica, TowerMode.MeleArea);
        CheckButton(miniNeutrofilo, previewNeutrofilo, TowerMode.RangeArea);
        CheckButton(miniCelulaB, previewCelulaB, TowerMode.RangeSolo);
        CheckButton(miniMacrofago, previewMacrofago, TowerMode.MeleSolo);

        if (GameIA.Money < costMacrofago)
        {
            textMacrofago.color = Color.red;
            textCelulaB.color = Color.red;
            textCelulaDendritica.color = Color.red;
            textNeutrofilo.color = Color.red;
        }
        else if (GameIA.Money < costCelulaB)
        {
            textMacrofago.color = Color.yellow;
            textCelulaB.color = Color.red;
            textCelulaDendritica.color = Color.red;
            textNeutrofilo.color = Color.red;
        }
        else if (GameIA.Money < costCelulaDendritica)
        {
            textMacrofago.color = Color.yellow;
            textCelulaB.color = Color.yellow;
            textCelulaDendritica.color = Color.red;
            textNeutrofilo.color = Color.red;
        }
        else if (GameIA.Money < costNeutrofilo)
        {
            textMacrofago.color = Color.yellow;
            textCelulaB.color = Color.yellow;
            textCelulaDendritica.color = Color.yellow;
            textNeutrofilo.color = Color.red;
        }
        else
        {
            textMacrofago.color = Color.yellow;
            textCelulaB.color = Color.yellow;
            textCelulaDendritica.color = Color.yellow;
            textNeutrofilo.color = Color.yellow;
        }
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
						if(GameIA.Money >= costCelulaDendritica)
						{
							GameIA.SpawnTower("TowerMeleArea", transform.position, gridPosition);
							Destroy(gameObject);
							GameIA.Money -= costCelulaDendritica;
						}
                        break;
                    case TowerMode.MeleSolo:
						if(GameIA.Money >= costMacrofago)
						{
							GameIA.SpawnTower("TowerMeleSolo", transform.position, gridPosition);
							Destroy(gameObject);
							GameIA.Money -= costMacrofago;
						}
                        break;
                    case TowerMode.RangeArea:
						if(GameIA.Money >= costNeutrofilo)
						{
							GameIA.SpawnTower("TowerRangeArea", transform.position, gridPosition);
							Destroy(gameObject);
							GameIA.Money -= costNeutrofilo;
						}
                        break;
                    case TowerMode.RangeSolo:
						if(GameIA.Money >= costCelulaB)
						{
							GameIA.SpawnTower("TowerRangeSolo", transform.position, gridPosition);
							Destroy(gameObject);
							GameIA.Money -= costCelulaB;
						}
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