using System.Collections;
using System.Collections.Generic;

public class LanguageBehaviour
{
	static public List<ILanguage> languageBehaviour = new  List<ILanguage>();
    static public Lingua lingua = Lingua.Portugues;
}

public enum Lingua
{
    Portugues = 0,
    Ingles = 1,
}
