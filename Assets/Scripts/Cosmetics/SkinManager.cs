using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public SkinDatabase db;

    public Text name;
    public Image currentImg, prevImg, nextImg;

    private int selected = 0;

    public Sprite unknown;

    void Start()
    {
        Display();
    }

    public void Next()
    {
        if (selected < db.skinCount - 1)
        {
            selected++;
        }

        Display();
    }
    public void Previous()
    {
        if (selected > 0)
        {
            selected--;
        }

        Display();
    }

    void Display()
    {
        currentImg.sprite = db.getSkin(selected).sprite;
        name.text = db.getSkin(selected).name;

        PlayerPrefs.SetInt("Skin", selected);

        if (selected - 1 >= 0)
        {
            prevImg.enabled = true;
            prevImg.sprite = db.getSkin(selected - 1).sprite;
        }
        else
        {
            prevImg.enabled = false;
        }

        if (selected + 1 < db.skinCount)
        {
            nextImg.sprite = db.getSkin(selected + 1).sprite;
        }
        else
        {
            nextImg.sprite = unknown;
        }
    }
}
