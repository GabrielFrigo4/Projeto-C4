using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeColl : MonoBehaviour
{
	CircleCollider2D coll;
	public List<Enemy> enemys = new List<Enemy>();
	
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
    {
		Enemy obj = other.gameObject.GetComponent<Enemy>();
		if(obj != null)
		{
	        enemys.Add(obj);
		}
    }
	
		private void OnTriggerExit(Collider other)
    {
		Enemy obj = other.gameObject.GetComponent<Enemy>();
		if(obj != null)
		{
	        enemys.Remove(obj);
		}
    }
}
