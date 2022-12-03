using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{

    public string[] types;
    public int capacity = 2;

    private List<Carriable> carriables;

    private void Start()
    {
        carriables = new List<Carriable>();
    }

    private bool CanBeDeposited(Carriable c)
    {
        return c.IsCompatible(types) && carriables.Count < capacity;
    }

    public void Put(Carrier c)
    {
        if (c.Carrying && CanBeDeposited(c.Carrying))
        {
            Carriable carriable = c.Drop();

            carriables.Add(carriable);
        }
    }

}
