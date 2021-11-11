using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour
{
	[SerializeField]Tilemap map;
	[SerializeField]List<Vector2> starts, indentationStarts;
	[SerializeField]List<TileBase> tileNoone;
	[SerializeField]List<TileBase> tileGround;
	[SerializeField]List<TileBase> tilePath;
	[SerializeField]List<TileBase> tileTowerPositon;
	public List<List<Vector2>> paths = new List<List<Vector2>>();
	Grid grid;

	int time = 10;
	
    void Start()
    {
        grid = new Grid(16, 8, 2f, transform.position);
		UpdateGridToTilemapValue();
		paths.Add(new List<Vector2>());
		GetPath(paths[0]);
		SpawnEnemy(paths[0]);
    }

    void Update()
    {
		time--;
		if(time == 0)
        {
			SpawnEnemy(paths[0]);
			time = 10;
		}
		if (Input.GetMouseButtonDown(1))
		{
			SpawnTower();
		}
    }
	
	void GetPath(List<Vector2> path)
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
		
		GetNextPosition(starts[0], Vector2.zero);
	}

	void SpawnEnemy(List<Vector2> path)
    {
		Vector3 createPosition = starts[0] * 2 + new Vector2(-15f, -8f) + indentationStarts[0] * 2;
		GameObject inimigo = Instantiate((GameObject)Resources.Load("Prefab/Enemy"), createPosition, Quaternion.identity);
		Enemy en = inimigo.GetComponent<Enemy>();

		List<Vector2> arrayVar = new List<Vector2>();

		path.ForEach((item) =>
		{
			arrayVar.Add(item);
		});

		en.path = arrayVar;
	}

	void UpdateGridToTilemapValue()
	{
		for (int x = 0; x < 18; x++)
		{
			for (int y = 0; y < 8; y++)
			{
				TileBase b = map.GetTile(new Vector3Int(x, y, 0));

				if (b == null)
				{
					grid.SetValue(x, y, GridType.outside);
				}
				else if (tileNoone.Contains(b))
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
