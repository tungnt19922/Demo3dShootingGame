using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    private void Start()
    {
        AddHitSurface();
    }
    private void AddHitSurface()
    {
        Collider[] collider = GetComponentsInChildren<Collider>();
        foreach (Collider col in collider)
        {
            if (gameObject.GetComponent<HitSurface>() == null)
            {
                var hitSurface = col.gameObject.AddComponent<HitSurface>();
                hitSurface.surfaceType = HitSurfaceType.Blood;
            }
        }
    }

}
