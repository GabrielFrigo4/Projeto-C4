using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanguageBehaviour : MonoBehaviour
{
	static public List<LanguageBehaviour> languageBehaviour = new  List<LanguageBehaviour>();
    public static Lingua lingua = Lingua.Portugues;
    [SerializeField] string portugues, ingles;
    [SerializeField] Text text;

    void Start()
    {
        SetLenguage();
		if(!languageBehaviour.Contains(this))
		{
			languageBehaviour.Add(this);
		}
    }

    public void SetLenguage()
    {
        if (lingua == Lingua.Portugues)
        {
            text.text = portugues;
        }
		
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

public enum Lingua
{
    Portugues = 0,
    Ingles = 1,
}
