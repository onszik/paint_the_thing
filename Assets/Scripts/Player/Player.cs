using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour {

    public AudioSource deadSound;
    private Animation anim;

    //public Animator uianim;

    public GameObject deathEffect, gameoverText;
    
    public bool hasBrush = false;

    private int score;

    public Text scoreText;
    public Text highscoreText;

    void Start()
    {
        //PlayerPrefs.DeleteAll();


        anim = gameObject.GetComponent<Animation>();
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Pixel" && hasBrush == true) {
            if (other.gameObject.GetComponent<Pixel>().full != true) {
                hasBrush = false;

                Pixel scr = other.gameObject.GetComponent<Pixel>();
                scr.full = true;
                scr.Color();

                Transform brush = transform.Find("Brush(Clone)");
                GameObject dropsGO = brush.Find("Drops").gameObject;

                Destroy(brush.gameObject);

                dropsGO.transform.parent = null;

                ParticleSystem.MainModule _main = dropsGO.GetComponent<ParticleSystem>().main;

                _main.loop = false;
                _main.stopAction = ParticleSystemStopAction.Destroy;

                StartCoroutine(DisplayScore(100));

                SoundFX.paintSound.Play();
                SoundFX.paintSound.pitch += 0.05f;
                SoundFX.paintSound.GetComponent<AudioChorusFilter>().depth += 0.05f;
                //   scoreText.GetComponent<Text>().text = "score: " + score;

                if (score > PlayerPrefs.GetInt("Highscore", 0))
                {
                    PlayerPrefs.SetInt("Highscore", score);
                    highscoreText.text = "HIGHSCORE: " + score;

                    //uianim.Play("NewHighScore");
                }
            }
        } else if (other.gameObject.tag == "enemy") {
            gameoverText.SetActive(true);
            deadSound.Play();
            //UIscr.End();
            GameObject fx = Instantiate(deathEffect) as GameObject;
            fx.transform.position = transform.position;

            Shake.camShake();

            int deaths = PlayerPrefs.GetInt("DeathCount", 0);
            deaths++;
            PlayerPrefs.SetInt("DeathCount", deaths);

            int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
            totalScore += score;
            PlayerPrefs.SetInt("TotalScore", totalScore);

            Destroy(gameObject);
        }
    }
    
    IEnumerator DisplayScore(int value)
    {
        int oldScore = score;

        score += value;

        float t = 0;
        //uianim.Play("IncreaseScore");
        while (t < 1)
        {
            t += 0.05f;
            scoreText.text = "SCORE: " + Mathf.Floor(oldScore + (value * BezierBlend(t)));
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    float BezierBlend(float t)
    {
        return t * t * (3.0f - 2.0f * t);
    }
}
