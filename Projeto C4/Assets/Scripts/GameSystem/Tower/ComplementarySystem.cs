using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementarySystem : MonoBehaviour
{
    [SerializeField] int damage, total;
    [SerializeField] float time;
    private Animator animator;
    private IEnumerator corroutine;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        corroutine = StartDamage(time);
        StartCoroutine(corroutine);
    }

    IEnumerator StartDamage(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
