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
		switch(LanguageBehaviour.lingua)
		{
			case Lingua.Portugues:
			animatorPlayer.runtimeAnimatorController = jogarPT;
				break;
			case Lingua.Ingles:
			animatorPlayer.runtimeAnimatorController = playEN;
				break;
		}
	}
}
