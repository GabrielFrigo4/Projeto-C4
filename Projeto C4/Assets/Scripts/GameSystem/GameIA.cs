using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour
{
	public Tilemap map;
	[SerializeField]List<TileBase> tileNoone;
	[SerializeField]List<TileBase> tileGround;
	[SerializeField]List<TileBase> tilePath;
	[SerializeField]List<TileBase> tileTowerPositon;
	Grid grid;
	
    void Start()
    {
        grid = new Grid(16, 8, 2f, transform.position);
		UpdateGridToTilemapValue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
		{
			SpawnTower();
		}
    }
	
	void UpdateGridToTilemapValue()
	{
		for(int x = 0; x < 18; x++)
		{
			for(int y = 0; y < 8; y++)
			{
				TileBase b = map.GetTile(new Vector3Int(x,y,0));
				
				if(b == null)
				{
					grid.SetValue(x, y, GridType.outside);
				}
				else if(tileNoone.Contains(b))
				{
					grid.SetValue(x, y, GridType.noone);
				}
				else if(tileGround.Contains(b))
				{
					grid.SetValue(x, y, GridType.ground);
				}
				else if(tilePath.Contains(b))
				{
					grid.SetValue(x, y, GridType.path);
				}
				else if(tileTowerPositon.Contains(b))
				{
					grid.SetValue(x, y, GridType.towerPosition);
				}
			}
		}
	}
	
	void SpawnTower()
	{
		Vector3 spawnPosition = GetMouseWorldPosition();
		
		if(ValidatePosition(ref spawnPosition))
		{
			Instantiate((GameObject)Resources.Load("Prefab/Tower"), spawnPosition, Quaternion.identity);
		}
	}
	
	bool ValidatePosition(ref Vector3 position)
	{
		int x, y;
		grid.GetXY(position, out x, out y);
		
		if(grid.GetValue(x,y) == GridType.towerPosition)
		{
			position = new Vector3(x*2 - 15f, y*2 - 8f, 0);
			grid.SetValue(x,y,GridType.towerUsing);
			return true;
		}
		else
		{
			return false;
		}
	}
}
