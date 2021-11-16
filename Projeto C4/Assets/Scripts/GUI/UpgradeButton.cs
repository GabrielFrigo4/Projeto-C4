using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades, ChainUpgrades;
	public Button[] buttons;
	public int level;
	void Start()
	{
		level = 0;
		buttons = ChainUpgrades.GetComponentsInChildren<Button>();
	}
	public void onUpradesSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(51,1,0);
		menuUpgrades.transform.position = new Vector3(0,1,0);
	}
	public void onLevelChoiceSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(0,1,0);
		menuUpgrades.transform.position = new Vector3(51,1,0);
	}
	public void onBack2MenuSelected() 
	{
		SceneScript.GoScene("Menu");
	}
	public void onUpgradePurchased()
	{
		level++;
		for(int i = 0; i < buttons.Length; i++)
		{
			Debug.Log(level + " " + i);
			if (i != level) {
				buttons[i].enabled = false;
			} else {
				buttons[i].enabled = true;
			}
		}

	}
}
//Para criar outra fileira de upgrades, duplica o ChainUpgrades, e poem os gameObjects dos botões na ordem, pq o GetComponentsInChildren vai de cima para baixo.