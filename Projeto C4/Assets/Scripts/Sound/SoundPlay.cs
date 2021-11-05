using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[SerializeField] float volume = 1f;
	[SerializeField] bool isStatic = false;
	static GameObject clipSound;
	static GameObject ClipSound 
	{ 
		get 
		{ 
			if(clipSound == null)
			{
				clipSound = (GameObject)Resources.Load("ClipPlay");
			}
			return clipSound;
		} 
	}
	
    void Start()
    {
        Play();
    }
	
	public void Play()
	{
		PlayClip(clip, volume, isStatic);
	}
	
	public static GameObject PlayClip(AudioClip clip, float volume, bool isStatic)
	{
		GameObject sound = Instantiate(ClipSound);
		ClipPlayScript clipScript = sound.GetComponent<ClipPlayScript>();
		clipScript.volume = volume;
		clipScript.clip = clip;
		clipScript.isStatic = isStatic;
		return sound;
	}
}
