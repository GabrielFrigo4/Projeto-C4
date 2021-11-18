using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using static PointerMethod;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[Range(0, 1)] [SerializeField] float volume = 1f;
	[SerializeField] bool isStatic = false;
	[SerializeField] SoundVolumeType typeSound;

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
        switch (typeSound)
        {
			case SoundVolumeType.Normal:
				PlayClip(clip, GetPointerPtr(ref volume), isStatic);
				break;
			case SoundVolumeType.Music:
				PlayClip(clip, GetPointerPtr(ref SliderScript.volumeMusic), isStatic);
				break;
			case SoundVolumeType.Sound:
				PlayClip(clip, GetPointerPtr(ref SliderScript.volumeSound), isStatic);
				break;
		}
	}
	
	public static GameObject PlayClip(AudioClip clip, IntPtr volume, bool isStatic)
	{
		GameObject sound = Instantiate(ClipSound);
		ClipPlayScript clipScript = sound.GetComponent<ClipPlayScript>();
		clipScript.volume = volume;
		clipScript.clip = clip;
		clipScript.isStatic = isStatic;
		return sound;
	}

	public enum SoundVolumeType
	{
		Normal,
		Music,
		Sound,
    }
}