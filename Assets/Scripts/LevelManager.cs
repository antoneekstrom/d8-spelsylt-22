using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public FieldRandomizer firstLevel;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        ClearAll();
        firstLevel.Generate();
    }

    public void ClearAll()
    {
        foreach (FieldRandomizer field in FindObjectsOfType<FieldRandomizer>())
        {
            field.Clear();
        }
    }
}
