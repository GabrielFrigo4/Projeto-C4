using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SliderScript : MonoBehaviour
{
	public static float volumeMusic = 0.5f, volumeSound = 0.5f;
	
    public void VolumeMusic(float volume)
	{
		volumeMusic = volume;
	}
	
	public void VolumeSound(float volume)
	{
		volumeSound = volume;
	}
}
