using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
	public static float volumeMusic, volumeSound;
	
    public void VolumeMusic(float volume)
	{
		volumeMusic = volume;
	}
	
	public void VolumeSound(float volume)
	{
		volumeSound = volume;
	}
}
