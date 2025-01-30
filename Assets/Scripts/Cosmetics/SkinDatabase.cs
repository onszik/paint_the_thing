using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkinDatabase : ScriptableObject
{
    public Skin[] skins;

    public int skinCount
    {
        get
        {
            return skins.Length;
        }
    }

    public Skin getSkin(int index)
    {
        return skins[index];
    }
}
