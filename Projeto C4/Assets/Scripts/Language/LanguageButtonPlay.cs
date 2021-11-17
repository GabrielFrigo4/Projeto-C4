using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanguageButtonPlay : MonoBehaviour, ILanguage
{
	[SerializeField] Animator animatorPlayer;
	[SerializeField] RuntimeAnimatorController playEN, jogarPT;
	
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
			animatorPlayer.runtimeAnimatorController = jogarPT;
				break;
			case Language.English:
			animatorPlayer.runtimeAnimatorController = playEN;
				break;
		}
	}
}
