using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour
{
	[SerializeField]Tilemap mainMap;
	[SerializeField]List<Tilemap> maps;
	[SerializeField]List<Vector2> starts, indentationStarts;
	[SerializeField]List<TileBase> tileNoone;
	[SerializeField]List<TileBase> tileGround;
	[SerializeField]List<TileBase> tilePath;
	[SerializeField]List<TileBase> tileTowerPositon;
	List<List<Vector2>> paths = new List<List<Vector2>>();
	List<Grid> pathGrid = new List<Grid>(); 
	Grid mainGrid;
	
	const int maxTime = 20;
	int time = maxTime;
	
    void Start()
    {
        mainGrid = new Grid(16, 8, 2f, transform.position);
		UpdateGridToTilemapValue(mainGrid, mainMap);
		for(int i = 0; i < maps.Count; i++)
		{
			pathGrid.Add(new Grid(16, 8, 2f, transform.position));
			paths.Add(new List<Vector2>());
		}
		
		for(int i = 0; i < maps.Count; i++)
		{
			UpdateGridToTilemapValue(mainGrid, maps[i]);
			UpdateGridToTilemapValue(pathGrid[i], maps[i]);
			GetPath(paths[i], starts[i], pathGrid[i]);
		}
    }

    void Update()
    {
		time--;
		if(time == 0)
        {
			for(int i = 0; i < maps.Count; i++)
			{
				SpawnEnemy(paths[i], starts[i], indentationStarts[i]);
			}
			time = maxTime;
		}
		if (Input.GetMouseButtonDown(1))
		{
			SpawnTower();
		}
    }
	
	void GetPath(List<Vector2> path, Vector2 start, Grid grid)
	{	
		void GetNextPosition(Vector2 position, Vector2 direction)
		{
			path.Add(position);
			Vector2 up, down, left, right;
			up = position + Vector2.up;
			down = position + Vector2.down;
			left = position + Vector2.left;
			right = position + Vector2.right;
			
			if(grid.GetValue((int)up.x, (int)up.y) == GridType.path && !path.Contains(up))
			{
				GetNextPosition(up, Vector2.up);
			}
			else if(grid.GetValue((int)down.x, (int)down.y) == GridType.path && !path.Contains(down))
			{
				GetNextPosition(down, Vector2.down);
			}
			else if(grid.GetValue((int)left.x, (int)left.y) == GridType.path && !path.Contains(left))
			{
				GetNextPosition(left, Vector2.left);
			}
			else if(grid.GetValue((int)right.x, (int)right.y) == GridType.path && !path.Contains(right))
			{
				GetNextPosition(right, Vector2.right);
			}
            else
            {
				path.Add(position + direction);
			}
		}
		
		GetNextPosition(start, Vector2.zero);
	}

	void SpawnEnemy(List<Vector2> path, Vector2 start, Vector2 indentationStart)
    {
		Vector3 createPosition = start * 2 + new Vector2(-15f, -8f) + indentationStart * 2;
		GameObject inimigo = Instantiate((GameObject)Resources.Load("Enemy"), createPosition, Quaternion.identity);
		Enemy en = inimigo.GetComponent<Enemy>();

		List<Vector2> arrayVar = new List<Vector2>();

		path.ForEach((item) =>
		{
			arrayVar.Add(item);
		});

		en.path = arrayVar;
	}

	void UpdateGridToTilemapValue(Grid grid, Tilemap map)
	{
		for (int x = 0; x < 18; x++)
		{
			for (int y = 0; y < 8; y++)
			{
				TileBase b = map.GetTile(new Vector3Int(x, y, 0));

				if (tileNoone.Contains(b))
				{
					grid.SetValue(x, y, GridType.noone);
				}
				else if (tileGround.Contains(b))
				{
					grid.SetValue(x, y, GridType.ground);
				}
				else if (tilePath.Contains(b))
				{
					grid.SetValue(x, y, GridType.path);
				}
				else if (tileTowerPositon.Contains(b))
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
			Instantiate((GameObject)Resources.Load("Tower"), spawnPosition, Quaternion.identity);
		}
	}
	
	bool ValidatePosition(ref Vector3 position)
	{
		int x, y;
		mainGrid.GetXY(position, out x, out y);
		
		if(mainGrid.GetValue(x,y) == GridType.towerPosition)
		{
			position = new Vector3(x*2 - 15f, y*2 - 8f, 0);
			mainGrid.SetValue(x,y,GridType.towerUsing);
			return true;
		}
		else
		{
			return false;
		}
	}
}
