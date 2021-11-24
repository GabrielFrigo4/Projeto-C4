using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades, ChainUpgrades, parallelUpgrades;
	Animator animator;
	public Button[] buttons;
	public Button[] button_parallel;
	public int level;
	
	
	void Start()
	{
		animator = GetComponent<Animator>();
		level = 0;
		buttons = ChainUpgrades.GetComponentsInChildren<Button>();
		button_parallel = parallelUpgrades.GetComponentsInChildren<Button>();

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
				buttons[i].animator.SetBool("Interactable", false);
				Debug.Log(i +" not available");
			} else if (i == level) {
				buttons[i].interactable = true;
				buttons[i].animator.SetBool("Interactable", true);
				Debug.Log(i +" available");
			} else if (i < level) {
				Debug.Log(i +" purchased true");
				buttons[i].animator.SetBool("Purchased", true);
				buttons[i].animator.SetBool("Interactable", true);
				buttons[i].interactable = false;
				
			}
		}
		
	}
	public void VaccinePurchased()
	{
		GameIA.vaccine = true;
		button_parallel[2].animator.SetBool("Purchased", true);
		//Debug.Log(GameIA.vaccine);
	}
	public void AntiviralPurchased()
	{
		GameIA.antiviral = true;
		button_parallel[1].animator.SetBool("Purchased", true);
		//Debug.Log(GameIA.antiviral);
		
	}
	public void AntibioticsPurchased()
	{
		GameIA.antibiotics = true;
		button_parallel[0].animator.SetBool("Purchased", true);
		//Debug.Log(GameIA.antibiotics);
	}
	
	public void OnFase1Selected() 
	{
		SceneScript.GoScene("Game");
	}
	public void OnBestiarySelected() 
	{
		SceneScript.GoScene("Bestiary");
	}
	public void OnTowerManualSelected() 
	{
		SceneScript.GoScene("TowerManual");
	}
	
}
//Para criar outra fileira de upgrades, duplica o ChainUpgrades, e poem os gameObjects dos botões na ordem, pq o GetComponentsInChildren vai de cima para baixo.