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
	
	public void OnUpradesSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(32, 0, 0);
		menuUpgrades.transform.position = new Vector3(0, 0, 0);
	}
	
	public void OnLevelChoiceSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(0, 0, 0);
		menuUpgrades.transform.position = new Vector3(32, 1, 0);
	}
	
	public void OnBack2MenuSelected() 
	{
		SceneScript.GoScene("Menu");
	}
	
	public void OnUpgradePurchased()
	{
		level++;
		for(int i = 0; i < buttons.Length; i++)
		{
			Debug.Log(level + " " + i);
			if (i != level) {
				buttons[i].interactable = false;
			} else {
				buttons[i].interactable = true;
			}
		}

	}
	
	public void OnFase1Selected() 
	{
		SceneScript.GoScene("Game");
	}
	public void OnBestiarySelected() 
	{
		SceneScript.GoScene("Bestiary");
	}
	
}
//Para criar outra fileira de upgrades, duplica o ChainUpgrades, e poem os gameObjects dos botões na ordem, pq o GetComponentsInChildren vai de cima para baixo.