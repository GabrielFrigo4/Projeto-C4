using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class ButtonBehaviour : MonoBehaviour
{
	//[SerializeField] Sprite Normal, Highlighted, Pressed;
	[SerializeField] float size;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		/*
        if(size < GetDistance2D(tranform.position, GetMouseWorldPosition()))
		{
			transform.localSize = new Vector3(1.1f, 1.1f, 1f);
		}
		else
		{
			transform.localSize = new Vector3(1f, 1f, 1f);
		}
		*/
    }
}
