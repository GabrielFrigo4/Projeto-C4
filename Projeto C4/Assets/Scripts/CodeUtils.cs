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
}