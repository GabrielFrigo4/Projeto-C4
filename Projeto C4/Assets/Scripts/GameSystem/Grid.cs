using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
	int widht;
	int height;
	float cellSize;
	Vector3 originPosition;
	GridData[,] gridArray;
	
	public Grid(int widht, int height, float cellSize, Vector3 originPosition)
	{
		this.widht = widht;
		this.height = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;
		
		gridArray = new GridData[widht,height];
		
		for(int x = 0; x < gridArray.GetLength(0); x++)
		{
			for(int y = 0; y < gridArray.GetLength(1); y++)
			{
				gridArray[x, y] = GridType.Noone;
			}
		}
	}
	
	public Vector3 GetWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * cellSize + originPosition;
	}
	
	public void GetXY(Vector3 worldPosition, out int x, out int y)
	{
		x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
		y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
	}
	
	public void SetValue(int x, int y, GridData value)
	{
		if(x >= 0 && y >= 0 && x < widht && y < height)
		{
			gridArray[x, y] = value;
		}
	}
	
	public void SetValue(Vector3 worldPosition, GridData value)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		SetValue(x, y, value);
	}
	
	public GridData GetValue(int x, int y)
	{
		if(x >= 0 && x < widht && y >= 0 && y < height)
		{
			return gridArray[x, y];
		}
		else
		{
			return GridType.Outside;
		}
	}
	
	public GridData GetValue(Vector3 worldPosition)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		return GetValue(x, y);
	}
}

public struct GridData
{
	public GridType type;
	public TowerAbstratc tower;

	public GridData(GridType type, TowerAbstratc tower)
    {
		this.type = type;
		this.tower = tower;
	}

	public static implicit operator GridType(GridData data) => data.type;

	public static implicit operator TowerAbstratc(GridData data) => data.tower;

	public static implicit operator GridData(GridType type)
    {
		GridData data = new GridData();
		data.type = type;
		data.tower = null;
		return data;
    }

	public static implicit operator GridData(TowerAbstratc tower)
	{
		GridData data = new GridData();
		data.type = GridType.TowerPosition;
		data.tower = tower;
		return data;
	}
}

public enum GridType : int
{
	Outside = -1,
	Noone = 0,
	Ground = 1,
	Path = 2,
	TowerPosition = 3,
}