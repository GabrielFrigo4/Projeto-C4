using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanguageBehaviour : MonoBehaviour
{
    public static Lingua lingua = Lingua.Portugues;
    [SerializeField] string portugues, ingles;
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        SetLenguage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLenguage()
    {
        if (lingua == Lingua.Portugues)
        {
            text.text = portugues;
        }
    }
}

public enum Lingua
{
    Portugues = 0,
    Ingles = 1,
}
