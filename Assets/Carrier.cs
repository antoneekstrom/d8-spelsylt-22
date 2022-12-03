using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    public string[] types;
    public float range = 3;

    public Carriable Carrying { get; private set; }

    private Interact interact;

    private void Awake()
    {
        interact = GetComponent<Interact>();
    }

    public void DepositNearest()
    {
        if (interact.TryGetNearest(out Deposit deposit))
            deposit.Put(this);
    }

    public void PickupNearest()
    {
        if (interact.TryGetNearest(out Carriable carriable))
        {
            if (Carry(carriable))
            {
                carriable.GetComponent<Interactable>().OnInteract.Invoke();
            }
        }
    }

    public bool Carry(Carriable c)
    {
        // Make sure that the carriable is able to be carríed
        if (!c.IsCompatible(types) || Carrying)
            return false;

        // Save a reference to the carriable
        Carrying = c;

        // Set the position of the carriable to that of the carrier
        Carrying.transform.position = transform.position;

        // Set the carrier as parent transform
        Carrying.transform.SetParent(transform);

        // Turn off the collider on the object being carried
        if (Carrying.TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        return true;
    }

    public Carriable Drop()
    {
        if (Carrying)
        {
            Carrying.transform.SetParent(null);

            if (Carrying.TryGetComponent(out Collider2D collider))
                collider.enabled = true;

            Carriable carriable = Carrying;
            Carrying = null;

            return carriable;
        }
        throw new Exception("Cannot drop because carrier is not carrying anything.");
    }
}
