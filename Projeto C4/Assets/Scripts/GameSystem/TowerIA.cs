using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIA : MonoBehaviour
{
	Grid grid;
	
    void Start()
    {
        grid = new Grid(16,8,2f, transform.position);
    }

    void Update()
    {
        
    }
}
