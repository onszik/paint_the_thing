using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner1 : MonoBehaviour
{
    public GameObject lazer;

    public AudioSource sound;

    public float delay = 3f;
    public float numOfLazers = 2;
    public float numOfLazersIncrease = 1;

    private float counter = 0f;

    private Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void FixedUpdate() {
        counter += Time.fixedDeltaTime;

        if (counter >= delay) {
            for (int i = 0; i < Mathf.Floor(numOfLazers); i++) {
                GameObject l = Instantiate(lazer);

                float width = (cam.orthographicSize * cam.GetComponent<Camera>().aspect) - 2; 

                l.transform.position = new Vector2(Random.Range(-width, width), 0);
                l.transform.Rotate(new Vector3(0, 0, Random.Range(0, 359)), Space.World);
            }
            numOfLazers += numOfLazersIncrease;
            counter = 0f;
            sound.Play();
        }
    }
}

