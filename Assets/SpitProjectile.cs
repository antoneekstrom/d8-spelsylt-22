using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitProjectile : MonoBehaviour
{
    public float speed = 3;

    Rigidbody2D rb;

    public void Initialize(SpitController c)
    {
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }
}
