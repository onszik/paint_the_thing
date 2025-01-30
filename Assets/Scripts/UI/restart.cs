using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    void OnMouseDown()
    {

        SceneManager.LoadScene("Game");
    }
}
