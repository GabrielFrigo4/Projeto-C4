using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeUltils;

public class TeseCode : MonoBehaviour
{
	Grid grid;
    void Start()
    {
		grid = new Grid(16,8,2f, transform.position);
    }
	
	void Update()
	{
		if(!ButtonPauseScript.isPaused)
		{
			int x, y;
			grid.GetXY(MouseUtils.GetWorldPosition(), out x, out y);
			
			if(y < 8)
			{
				if(Input.GetMouseButtonDown(0))
				{
					grid.SetValue(x, y, grid.GetValue(x, y) + 1);
					Debug.Log($"[{x}, {y}] {grid.GetValue(x, y)}");
				}
				
				if(Input.GetMouseButtonDown(1))
				{
					Debug.Log($"[{x}, {y}] {grid.GetValue(x, y)}");
				}	
			}
		}
	}
}
