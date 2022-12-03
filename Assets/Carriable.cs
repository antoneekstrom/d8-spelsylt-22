using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : MonoBehaviour
{
    public string type;
    public bool IsCompatible(string[] types)
    {
        return new ArrayList(types).Contains(type);
    }
}
