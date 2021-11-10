using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class TowerIA : MonoBehaviour
{
	Grid grid;
	
    void Start()
    {
        grid = new Grid(16,8,2f, transform.position);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
		{
			SpawnTower();
		}
    }
	
	void SpawnTower()
	{
		Vector3 spawnPosition = GetMouseWorldPosition();
		spawnPosition = ValidatePosition(spawnPosition);
		
		Instantiate((GameObject)Resources.Load("Tower"),spawnPosition,Quaternion.identity);
	}
	
	Vector3 ValidatePosition(Vector3 position)
	{
		int x, y;
		grid.GetXY(position, out x, out y);
		
		return new Vector3(x*2 - 15f, y*2 - 8f, position.z);
	}
}
