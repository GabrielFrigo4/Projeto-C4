using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine.UI;
using UnityEngine;

public class LanguageButton : MonoBehaviour, ILanguage
{
	[SerializeField] string portugues, ingles;
    [SerializeField] Text text;
	
    void Start()
    {
        (this as ILanguage).SetLanguage();
		if(!LanguageBehaviour.languageBehaviour.Contains(this))
		{
			LanguageBehaviour.languageBehaviour.Add(this);
		}
    }

    void ILanguage.SetLanguage()
    {
		switch(LanguageBehaviour.lingua)
		{
			case Lingua.Portugues:
			text.text = portugues;
				break;
			case Lingua.Ingles:
			text.text = ingles;
				break;
		}
	}
}
