using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
	[SerializeField] float time;
	private IEnumerator coroutine;
	
    // Start is called before the first frame update
    void Start()
    {
        coroutine = DeadTime(time);
        StartCoroutine(coroutine);
    }
	
	private IEnumerator DeadTime(float time)
    {
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
    }
}
