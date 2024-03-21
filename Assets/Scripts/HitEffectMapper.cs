using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1,
}

[System.Serializable]
public class HitEffectMapper 
{
    public HitSurfaceType surface;
    public GameObject effectPrefab;
}