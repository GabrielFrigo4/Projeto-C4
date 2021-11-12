using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void onUpradesSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(51,1,0);
		menuUpgrades.transform.position = new Vector3(0,1,0);
	}
	public void onBack2MenuSelected() 
	{
		SceneScript.GoScene("Menu");
	}
}
