using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float scareRadius = 2;
    public Collider2D scareCollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Alpacka alpacka))
        {
            alpacka.Scare(transform.position);
            print("scared an alpacka");
        }
        else if (collider.TryGetComponent(out Goblin goblin))
        {
            goblin.Fleeing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Alpacka alpacka))
        {
            alpacka.Scare(transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, scareRadius);
    }
}
