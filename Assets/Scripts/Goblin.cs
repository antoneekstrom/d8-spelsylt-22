using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class Goblin : MonoBehaviour
{
    public float speed = 3;
    public float range = 3;

    private Transform target;
    private bool hasStolen = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Enclosure[] enclosures = FindObjectsOfType<Enclosure>().Where(x => !x.IsEmpty()).ToArray();
        target = enclosures[Random.Range(0, enclosures.Length)].transform;
    }

    private void Update()
    {
        if (!hasStolen && target && Displacement().magnitude <= range)
        {
            target.GetComponent<Enclosure>().DropAlpacka();
            hasStolen = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = Displacement().normalized;

        if (hasStolen)
            direction = -direction;

        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }

    private Vector2 Displacement()
    {
        if (!target)
            return Vector2.zero;
        return target.transform.position - transform.position;
    }
}
