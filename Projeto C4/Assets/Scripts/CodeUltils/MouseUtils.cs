using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeUltils
{
	public static class MouseUtils
	{
		public static Vector3 GetWorldPosition()
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Camera.main.nearClipPlane;
			return Camera.main.ScreenToWorldPoint(mousePos);
		}
	}	
}