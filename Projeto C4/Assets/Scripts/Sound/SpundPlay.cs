using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SpundPlay : MonoBehaviour
{
	public static GameObject audioObject;
	[SerializeField]AudioClip sound;
	
    // Start is called before the first frame update
    void Start()
    {
        audioObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Play()
	{
		audioObject.AddComponent<AudioSource>();
	}
}
