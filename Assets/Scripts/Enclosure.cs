using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Enclosure : MonoBehaviour
{
    public int capacity = 3;

    private List<Alpacka> alpackas;

    private void Awake()
    {
        alpackas = new List<Alpacka>();
    }

    public void DepositAlpacka(AlpackaFarmer farmer)
    {
        if (alpackas.Count >= capacity)
            return;

        if (farmer.UncarryAlpacka(out Alpacka alpacka))
        {
            alpackas.Add(alpacka);
            alpacka.transform.position = transform.position;
            alpacka.transform.SetParent(transform);
        }
    }
}
