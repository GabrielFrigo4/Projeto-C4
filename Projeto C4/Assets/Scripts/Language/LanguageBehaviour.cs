using System.Collections;
using System.Collections.Generic;

public class LanguageBehaviour
{
	static public List<ILanguage> languageBehaviour = new  List<ILanguage>();
    static public Language language = Language.Portugues;
}

public enum Language
{
    Portugues = 0,
    English = 1,
}
