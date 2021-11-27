using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanguageButton : MonoBehaviour, ILanguage
{
	[TextArea(3, 10)]
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
		switch(LanguageBehaviour.language)
		{
			case Language.Portugues:
			text.text = portugues;
				break;
			case Language.English:
			text.text = ingles;
				break;
		}
	}
}
