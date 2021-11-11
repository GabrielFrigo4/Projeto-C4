using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour
{
	[SerializeField]Tilemap map;
	[SerializeField]List<Vector3> starts, ends;
	[SerializeField]List<TileBase> tileNoone;
	[SerializeField]List<TileBase> tileGround;
	[SerializeField]List<TileBase> tilePath;
	[SerializeField]List<TileBase> tileTowerPositon;
	public List<Vector3> paths = new List<Vector3>();
	Grid grid;
	
    void Start()
    {
        grid = new Grid(16, 8, 2f, transform.position);
		UpdateGridToTilemapValue();
		GetPath(paths);
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
	
	void GetPath(List<Vector3> path)
	{	
		void GetNextPosition(Vector3 position)
		{
			path.Add(position);
			Vector3 up, down, left, right;
			up = position + Vector3.up;
			down = position + Vector3.down;
			left = position + Vector3.left;
			right = position + Vector3.right;
			
			if(grid.GetValue((int)up.x, (int)up.y) == GridType.path && !path.Contains(up))
			{
				GetNextPosition(up);
			}
			else if(grid.GetValue((int)down.x, (int)down.y) == GridType.path && !path.Contains(down))
			{
				GetNextPosition(down);
			}
			else if(grid.GetValue((int)left.x, (int)left.y) == GridType.path && !path.Contains(left))
			{
				GetNextPosition(left);
			}
			else if(grid.GetValue((int)right.x, (int)right.y) == GridType.path && !path.Contains(right))
			{
				GetNextPosition(right);
			}			
		}
		
		GetNextPosition(starts[0]);
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
