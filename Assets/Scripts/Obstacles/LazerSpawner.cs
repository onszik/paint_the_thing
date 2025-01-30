using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    public GameObject lazer;

    public AudioSource sound;

    public float amount = 1f;
    public float numOfLazers = 2f;
    public float multiplier = 1.02f;

    private float delay = 0;

    private Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void FixedUpdate() {
        delay += Time.fixedDeltaTime;

        if (delay >= 1 / amount) {
            for (int i = 0; i < Mathf.Floor(numOfLazers); i++) {
                amount *= multiplier;
                numOfLazers *= multiplier;
                delay = 0f;

                GameObject l = Instantiate(lazer);

                float width = (cam.orthographicSize * cam.GetComponent<Camera>().aspect) - 2;

                l.transform.position = new Vector2(Random.Range(-width, width), 0);
                l.transform.Rotate(new Vector3(0, 0, Random.Range(0, 359)), Space.World);
            }
            sound.Play();
        }
    }
}

