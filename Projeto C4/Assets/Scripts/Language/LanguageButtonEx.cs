using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanguageButtonEx : MonoBehaviour, ILanguage
{
	[TextArea(3, 10)]
	[SerializeField] string portuguesPc, inglesPc, portuguesMobile, inglesMobile;
	[SerializeField] Text text;

	void Start()
	{
		(this as ILanguage).SetLanguage();
		if (!LanguageBehaviour.languageBehaviour.Contains(this))
		{
			LanguageBehaviour.languageBehaviour.Add(this);
		}
	}

	void ILanguage.SetLanguage()
	{
		switch (LanguageBehaviour.language)
		{
			case Language.Portugues:
#if UNITY_IOS
				text.text = portuguesMobile;
#else
				text.text = portuguesPc;
#endif
				break;
			case Language.English:
#if UNITY_IOS
				text.text = inglesMobile;
#else
				text.text = inglesPc;
#endif
				break;
		}
	}
}
