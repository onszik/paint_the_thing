using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    //public Text clickToPlay, score, newBest;
    public GameObject shadow, clickToPlay, score, newBest;

    void Start()
    {
        newBest.SetActive(false);
        shadow.SetActive(false);
    }

    public void HighScore()
    {
        newBest.SetActive(true);
        shadow.SetActive(true);
    }

    public void End()
    {
        clickToPlay.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
    }
}
