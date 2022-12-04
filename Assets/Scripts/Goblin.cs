using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class Goblin : MonoBehaviour
{
    public float speed = 3;
    public float range = 3;

    private Enclosure target;
    private bool fleeing = false;

    private Rigidbody2D rb;
    private float searchCooldown = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = FindEnclosureTarget();
    }

    private void Update()
    {
        searchCooldown += Time.deltaTime;

        // Remove target if it is empty
        if (!fleeing && target && target.IsEmpty())
        {
            target = null;
        }

        // search for new target if there is
        if (searchCooldown > 0.5 && !fleeing && !target)
        {
            searchCooldown = 0;
            target = FindEnclosureTarget();
        }

        // go towards target if there is any
        if (!fleeing && target && !target.IsEmpty() && Displacement().magnitude <= range)
        {
            target.GetComponent<Enclosure>().DropAlpacka();
            fleeing = true;
        }
        else if (fleeing && transform.position.magnitude > 60)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = Displacement().normalized;

        if (fleeing)
        {
            direction = transform.position.normalized;
        }

        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (TryGetComponent(out Dog _))
        {
            fleeing = true;
        }
    }

    private Enclosure FindEnclosureTarget()
    {
        Enclosure[] enclosures = FindObjectsOfType<Enclosure>().Where(x => !x.IsEmpty()).ToArray();
        
        if (enclosures.Length < 1)
            return null;

        return enclosures[Random.Range(0, enclosures.Length)];
    }

    private Vector2 Displacement()
    {
        if (!target)
            return Vector2.zero;
        return target.transform.position - transform.position;
    }
}
