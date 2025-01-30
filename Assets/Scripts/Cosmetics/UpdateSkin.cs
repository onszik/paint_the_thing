using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSkin : MonoBehaviour
{
    public SkinDatabase skins;
    public SpriteRenderer sprite;

    void Start()
    {
        int selected = PlayerPrefs.GetInt("Skin", 0);

        sprite.sprite = skins.getSkin(selected).sprite;
    }
}
