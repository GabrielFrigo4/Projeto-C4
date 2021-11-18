using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using static SafePointerMethod;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[Range(0, 1)] [SerializeField] float volume = 1f;
	[SerializeField] bool isStatic = false;
	[SerializeField] SoundVolumeType typeSound;
	private IntPtr volumePtr;

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
		volumePtr = CreatePointer(volume);
		Play();
    }

    void Update()
    {
		if(GetPointerValue<float>(volumePtr) != volume)
        {
			SetPointerValue(volumePtr, volume);
		}
	}

    void OnDestroy()
    {
		FreePointer(volumePtr);
    }

    public void Play()
	{
        switch (typeSound)
        {
			case SoundVolumeType.Normal:
				PlayClip(clip, volumePtr, isStatic);
				break;
			case SoundVolumeType.Music:
				PlayClip(clip, SliderScript.volumeMusic, isStatic);
				break;
			case SoundVolumeType.Sound:
				PlayClip(clip, SliderScript.volumeSound, isStatic);
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