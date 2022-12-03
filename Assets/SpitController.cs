using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpitController : MonoBehaviour
{
    public SpitProjectile SpitProjectilePrefab;

    public void OnSpit(InputAction.CallbackContext ctx)
    {
        CreateProjectile();
    }

    SpitProjectile CreateProjectile()
    {
        SpitProjectile instance = Instantiate(SpitProjectilePrefab);
        instance.Initialize(this);
        return instance;
    }
}
