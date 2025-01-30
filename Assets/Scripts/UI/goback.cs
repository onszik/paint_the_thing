using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}

