using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public static int scoreValue = 0;
    private Text score; 

    void Start()
    {
        score = GetComponent<Text>();
    }


    public void FixedUpdate()
    {
        score.text = "Score: " + scoreValue;
    }
}
