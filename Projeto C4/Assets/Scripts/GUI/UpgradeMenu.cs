using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades, ChainUpgrades;
	Animator animator;
	public Button[] buttons;
	public int level;
	
	
	void Start()
	{
		animator = GetComponent<Animator>();
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
			if (i > level) {
				buttons[i].interactable = false;
			} else if (i == level) {
				buttons[i].interactable = true;
			} else if (i < level) {
				if (buttons[i].animator != null) { 
					buttons[i].interactable = false;
					buttons[i].animator.SetBool("Purchased", true);
				}
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