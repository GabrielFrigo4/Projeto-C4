using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
	int widht;
	int height;
	float cellSize;
	Vector3 originPosition;
	GridType[,] gridArray;
	
	public Grid(int widht, int height, float cellSize, Vector3 originPosition)
	{
		this.widht = widht;
		this.height = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;
		
		gridArray = new GridType[widht,height];
		
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
	
	public void SetValue(int x, int y, GridType value)
	{
		if(x >= 0 && y >= 0 && x < widht && y < height)
		{
			gridArray[x, y] = value;
		}
	}
	
	public void SetValue(Vector3 worldPosition, GridType value)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		SetValue(x, y, value);
	}
	
	public GridType GetValue(int x, int y)
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
	
	public GridType GetValue(Vector3 worldPosition)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		return GetValue(x, y);
	}
}

public enum GridType : int
{
	Outside = -1,
	Noone = 0,
	Ground = 1,
	Path = 2,
	TowerPosition = 3,
	TowerUsing = 4,
}