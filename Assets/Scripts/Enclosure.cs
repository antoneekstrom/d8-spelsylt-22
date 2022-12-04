using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class Enclosure : MonoBehaviour
{
    public int capacity = 3;

    public UnityEvent OnFullCapacity;

    private List<Alpacka> alpackas;

    private void Awake()
    {
        alpackas = new List<Alpacka>();
    }

    public bool IsFull()
    {
        return alpackas.Count >= capacity;
    }

    public void DepositAlpacka(AlpackaFarmer farmer)
    {
        if (IsFull())
        {
            OnFullCapacity.Invoke();
            return;
        }

        if (farmer.UncarryAlpacka(out Alpacka alpacka))
        {
            alpackas.Add(alpacka);
            alpacka.transform.position = transform.position;
            alpacka.transform.SetParent(transform);
        }
    }
}
