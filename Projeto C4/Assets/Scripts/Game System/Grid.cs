using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
	int widht;
	int height;
	float cellSize;
	Vector3 originPosition;
	int[,] gridArray;
	
	public Grid(int widht, int height, float cellSize, Vector3 originPosition)
	{
		this.widht = widht;
		this.height = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;
		
		gridArray = new int[widht,height];
		
		for(int x = 0; x < gridArray.GetLength(0); x++)
		{
			for(int y = 0; y < gridArray.GetLength(1); y++)
			{
				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
				Debug.DrawLine(GetWorldPosition(x + 1, y +1), GetWorldPosition(x, y + 1), Color.white, 100f);
				Debug.DrawLine(GetWorldPosition(x + 1, y +1), GetWorldPosition(x + 1, y), Color.white, 100f);
			}
		}
	}
	
	Vector3 GetWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * cellSize + originPosition;
	}
	
	void GetXY(Vector3 worldPosition, out int x, out int y)
	{
		x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
		y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
	}
	
	public void SetValue(int x, int y, int value)
	{
		if(x >= 0 && y >= 0 && x < widht && y < height)
		{
			gridArray[x, y] = value;
		}
	}
	
	public void SetValue(Vector3 worldPosition, int value)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		SetValue(x, y, value);
	}
	
	public int GetValue(int x, int y)
	{
		if(x >= 0 && x < widht && y >= 0 && y < height)
		{
			return gridArray[x, y];
		}
		else
		{
			return 0;
		}
	}
	
	public int GetValue(Vector3 worldPosition)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		return GetValue(x, y);
	}
}
