using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Collider2D interactionArea;

    public Interactable Nearest { get; set; }

    public bool TryGetNearest<T>(out T nearest)
    {
        nearest = default;

        if (!Nearest)
            return false;

        return Nearest.TryGetComponent(out nearest);
    }

    private float DistanceToSqr(Transform other)
    {
        return (transform.position - other.position).sqrMagnitude;
    }

    private void UpdateNearestWith(Collider2D collider)
    {
        if (collider.TryGetComponent(out Interactable interactable) && interactable.enabled
            && (!Nearest || DistanceToSqr(collider.transform) < DistanceToSqr(Nearest.transform)))
        {
            Nearest = interactable;
            print(Nearest);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        UpdateNearestWith(collider);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        UpdateNearestWith(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (Nearest && collider.gameObject.Equals(Nearest.gameObject))
            Nearest = null;
    }
}