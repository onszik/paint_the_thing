using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner1 : MonoBehaviour
{
    public GameObject lazerPrefab;
    private Queue<GameObject> lazerPool = new Queue<GameObject>();

    public AudioSource sound;

    public float delay = 3f;
    public float numOfLazers = 2;
    public float numOfLazersIncrease = 1;

    private Camera cam;

    private float width;

    void Start() {
        width = (cam.orthographicSize * cam.GetComponent<Camera>().aspect) - 2;
        cam = Camera.main;

        InvokeRepeating("SpawnBullets", delay, delay);
    }

    void SpawnLazers() {
        for (int i = 0; i < Mathf.Floor(numOfLazers); i++) {
            GameObject l = GetFromPool();

            l.transform.position = new Vector2(Random.Range(-width, width), 0);
            l.transform.Rotate(new Vector3(0, 0, Random.Range(0, 359)), Space.World);
        }
        numOfLazers += numOfLazersIncrease;

        sound.Play();
    }

    GameObject GetFromPool() {
        if (lazerPool.Count > 0) {
            GameObject b = lazerPool.Dequeue();
            b.SetActive(true);
            return b;
        } else {
            GameObject b = Instantiate(lazerPrefab);
            return b;
        }
    }

    public void PutInPool(GameObject lazer) {
        lazer.SetActive(false);
        lazerPool.Enqueue(lazer);
    }

    /*
    IEnumerator AnimateLazers() {
        float t = 0;

        yield return new WaitForSeconds(1.1f);

        while (t < 1.5f) {
            t += Time.deltaTime;

            
        }
        
        
    }
    */

    public float DamageCheck() {

    }
}

