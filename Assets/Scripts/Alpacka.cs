using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomWalk), typeof(Collider2D))]
public class Alpacka : MonoBehaviour
{
    private RandomWalk randomWalk;
    private Interactable interactable;
    private new Collider2D collider;

    private void Awake()
    {
        randomWalk = GetComponent<RandomWalk>();
        collider = GetComponent<Collider2D>();
        interactable = GetComponent<Interactable>();
    }

    public void Carry(AlpackaFarmer farmer)
    {
        transform.position = farmer.transform.position;
        transform.SetParent(farmer.transform);
        collider.enabled = false;
        randomWalk.enabled = false;
        Destroy(interactable);
    }

    public void Uncarry()
    {
        transform.SetParent(null);
        collider.enabled = true;
        randomWalk.enabled = true;
    }
}
