using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PointerMethod;

public class SliderScript : MonoBehaviour
{
	public static IntPtr volumeMusic = CreatePointer(0.5f), volumeSound = CreatePointer(0.5f);
	
    public void VolumeMusic(float volume)
	{
		SetPointerValue(volumeMusic, volume);
	}
	
	public void VolumeSound(float volume)
	{
		SetPointerValue(volumeSound, volume);
	}
}
