using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnclosureManager : MonoBehaviour
{
    public List<Enclosure> enclosures;
    public UnityEvent OnAllFull;

    public void AddEnclosure(Enclosure enclosure)
    {
        enclosures.Add(enclosure);
        enclosure.OnFullCapacity.AddListener(CheckEnclosures);
    }

    public void CheckEnclosures()
    {
        if (AllEnclosuresFull())
            OnAllFull.Invoke();
    }

    public bool AllEnclosuresFull()
    {
        foreach (Enclosure enclosure in enclosures)
        {
            if (!enclosure.IsFull())
                return false;
        }
        return true;
    }
}
