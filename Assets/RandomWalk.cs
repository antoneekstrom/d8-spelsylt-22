using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public float range = 5;
    public float frequency = 3;
    public float speed = 2;

    private Rigidbody2D rb;

    private Vector2 target;
    private float nextTargetTimer = 0;

    public void ToggleEnabled()
    {
        enabled = !enabled;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        nextTargetTimer += Time.deltaTime;

        if (nextTargetTimer >= frequency)
        {
            nextTargetTimer = 0;
            target = Random.insideUnitCircle * range;
        }

        rb.velocity = (target - (Vector2)transform.position).normalized * speed;
    }
}
