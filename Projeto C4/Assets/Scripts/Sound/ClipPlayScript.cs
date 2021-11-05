using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlayScript : MonoBehaviour
{
	Transform camera;
	AudioSource source;
	[HideInInspector] public AudioClip clip;
	[HideInInspector] public float volume;
	[HideInInspector] public bool isStatic;
	
    // Start is called before the first frame update
    void Start()
    {
		if(isStatic)
		{
			DontDestroyOnLoad(gameObject);
		}
		
        camera = ((Camera)FindObjectOfType(typeof(Camera))).transform;
		source = GetComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.Play();
    }

    // Update is called once per frame
    void Update()
    {
		if(camera != null)
		{
			transform.position = camera.position;
		}
		else
		{
			camera = ((Camera)FindObjectOfType(typeof(Camera))).transform;
			if(camera != null)
			{
				transform.position = camera.position;
			}
		}
    }
}
