using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public float range = 5;
    public float frequency = 3;
    public float speed = 2;
    public RectTransform area;

    private Rigidbody2D rb;

    private Vector2 target;
    private float nextTargetTimer = 0;

    public void ToggleEnabled()
    {
        enabled = !enabled;
        PickTargetLocation();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = PickTargetLocation();
    }

    private Vector2 PickTargetLocation()
    {
        if (area)
        {
            Rect rect = area.rect;
            return new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
        }
        else
        {
            return Random.insideUnitCircle * range;
        }
    }

    private void Update()
    {
        nextTargetTimer += Time.deltaTime;

        if (nextTargetTimer >= frequency)
        {
            nextTargetTimer = 0;
            target = PickTargetLocation();
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }
}
