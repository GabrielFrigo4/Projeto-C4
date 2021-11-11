using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class Enemy : MonoBehaviour
{
    public List<Vector2> path = new List<Vector2>();
	Vector2 randomPos;
	float destroySelfDistance = 0.5f;

	// Start is called before the first frame update
	void Start()
    {
		randomPos = new Vector2(Random.Range(-0.35f, 0.35f), Random.Range(-0.35f, 0.35f));
		destroySelfDistance = Random.Range(0.35f, 0.65f);
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 targetPosition = path[0] * 2 + new Vector2(-15f, -8f) + randomPos;
		Vector2 moveDir = (targetPosition - (Vector2)transform.position).normalized;

		float moveSpeed = 6f;

		transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;

		float angle = GetAngleFromVector(moveDir);
		transform.eulerAngles = new Vector3(0, 0, angle);

		if (Vector2.Distance(transform.position, targetPosition) < destroySelfDistance)
		{
			if (path.Count > 1)
				path.RemoveAt(0);
			else
				PassedOn();
		}
	}

	public void PassedOn()
    {
		Destroy(gameObject);
    }
}
