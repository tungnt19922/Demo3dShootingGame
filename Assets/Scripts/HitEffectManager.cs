using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class HitEffectManager : MonoBehaviourSingleton<HitEffectManager>
{
    public HitEffectMapper[] effectMaps;

    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        HitEffectMapper mapper = System.Array.Find(effectMaps, x => x.surface == surfaceType);
        Debug.Log($"{surfaceType}");
        return mapper?.effectPrefab;
        
    }

}

