using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Interact))]
public class AlpackaFarmer : MonoBehaviour
{
    private Interact interact;
    private Alpacka carrying;

    private void Awake()
    {
        interact = GetComponent<Interact>();
    }

    private void FixedUpdate()
    {
        if (carrying)
            carrying.transform.position = transform.position;
    }

    public void OnInteract(InputAction.CallbackContext _)
    {
        if (interact.TryGetNearest(out Alpacka alpacka))
        {
            if (!carrying)
                CarryAlpacka(alpacka);
        }
        else if (carrying && interact.TryGetNearest(out Enclosure enclosure))
        {
            print("Deposit alpacka!");
            enclosure.DepositAlpacka(this);
        }
    }

    public bool UncarryAlpacka(out Alpacka alpacka)
    {
        alpacka = carrying;
        carrying = null;

        if (!alpacka)
            return false;

        alpacka.Uncarry();

        return true;
    }

    public void CarryAlpacka(Alpacka alpacka)
    {
        carrying = alpacka;
        alpacka.Carry(this);
    }
}
