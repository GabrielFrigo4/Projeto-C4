using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[Range(0, 1)] [SerializeField] float volume =  1f;
	[SerializeField] bool isStatic = false, playOnStart = true, loop = false;
	[SerializeField] SoundVolumeType typeSound;
	[SerializeField] SoundCreateBehaviour createBehaviour;
	[SerializeField] string soundTag;

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
        if (playOnStart)
        {
            switch (createBehaviour)
            {
				case SoundCreateBehaviour.Ever:
					Play();
					break;
				case SoundCreateBehaviour.OnlyOne:
					List<ClipPlayScript> clipPlayScripts = new List<ClipPlayScript>(FindObjectsOfType<ClipPlayScript>());
					bool onlyOne = true;

					foreach (ClipPlayScript clip in clipPlayScripts)
					{
						if (clip.soundTag != soundTag) continue;
						onlyOne = false;
						break;
					}

                    if (onlyOne)
                    {
						Play();
					}
					break;
			}
        }
    }

    public void Play()
	{
        switch (typeSound)
        {
			case SoundVolumeType.Normal:
				PlayClip(clip, new Address<float>(in volume), isStatic, loop, soundTag);
				break;
			case SoundVolumeType.Music:
				PlayClip(clip, new Address<float>(in SliderScript.volumeMusic), isStatic, loop, soundTag);
				break;
			case SoundVolumeType.Sound:
				PlayClip(clip, new Address<float>(in SliderScript.volumeSound), isStatic, loop, soundTag);
				break;
		}
	}
	
	public static GameObject PlayClip(AudioClip clip, Address<float> volume, bool isStatic = false, bool loop = false, string soundTag = "")
	{
		GameObject sound = Instantiate(ClipSound);
		ClipPlayScript clipScript = sound.GetComponent<ClipPlayScript>();
		clipScript.volume = volume;
		clipScript.clip = clip;
		clipScript.isStatic = isStatic;
		clipScript.loop = loop;
		clipScript.soundTag = soundTag;
		return sound;
	}

	public enum SoundVolumeType
	{
		Normal,
		Music,
		Sound,
    }

	public enum SoundCreateBehaviour
    {
		Ever,
		OnlyOne,
    }
}