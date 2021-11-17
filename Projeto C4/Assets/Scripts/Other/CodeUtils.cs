using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CodeUtils
{
	public static Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.nearClipPlane;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}
	
	public static float GetAngleFromVector(Vector3 dir)
	{
		dir = dir.normalized;
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if(n < 0) n += 360;
		return n;
	}

	public static float GetDistance2D(Vector2 pos1, Vector2 pos2)
    {
		return Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
    }
}