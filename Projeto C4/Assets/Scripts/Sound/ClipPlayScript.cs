using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClipPlayScript : MonoBehaviour
{
	Transform transformCamera;
	[HideInInspector] public AudioSource source;
	[HideInInspector] public AudioClip clip;
	[HideInInspector] public Address<float> volume;
	[HideInInspector] public bool isStatic, loop, pause = false;
	[HideInInspector] public string soundTag;

	// Start is called before the first frame update
	void Start()
    {
		if(isStatic)
		{
			DontDestroyOnLoad(gameObject);
		}
		
		transformCamera = ((Camera)FindObjectOfType(typeof(Camera))).transform;
		source = GetComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume.Value;
		source.loop = loop;
		source.Play();
    }

    // Update is called once per frame
    void Update()
    {
		if(transformCamera != null)
		{
			transform.position = transformCamera.position;
		}
		else
		{
			transformCamera = ((Camera)FindObjectOfType(typeof(Camera))).transform;
			if(transformCamera != null)
			{
				transform.position = transformCamera.position;
			}
		}

		if (!volume.IsNull)
        {
			float momentVolume = volume.Value;
			if (momentVolume != source.volume)
			{
				source.volume = momentVolume;
			}
		}

		if(!source.isPlaying && !pause)
        {
			Destroy(gameObject);
        }
    }
}