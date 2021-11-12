using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[Range(0, 1)][SerializeField] float volume = 1f;
	[SerializeField] bool isStatic = false;
	[SerializeField] TipoVolumeSound typeSound;

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
			case TipoVolumeSound.Normal:
				PlayClip(clip, ref volume, isStatic);
				break;
			case TipoVolumeSound.Musica:
				PlayClip(clip, ref SliderScript.volumeMusic, isStatic);
				break;
			case TipoVolumeSound.Som:
				PlayClip(clip, ref SliderScript.volumeSound, isStatic);
				break;
		}
	}
	
	public unsafe static GameObject PlayClip(AudioClip clip, ref float volume, bool isStatic)
	{
		GameObject sound = Instantiate(ClipSound);
		ClipPlayScript clipScript = sound.GetComponent<ClipPlayScript>();
		fixed(float* ptr = &volume)
		{
			clipScript.volume = ptr;
		}
		clipScript.clip = clip;
		clipScript.isStatic = isStatic;
		return sound;
	}

	public enum TipoVolumeSound
    {
		Normal,
		Musica,
		Som,
    }
}