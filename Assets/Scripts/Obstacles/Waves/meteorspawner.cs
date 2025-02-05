using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorspawner : MonoBehaviour
{
    public GameObject meteor;

    public float amount = 3f;
    public float multiplier = 1.01f;

    private float delay = 0;

    private Camera cam;
    void Start()
    {

        cam = Camera.main;
    }

    void FixedUpdate()
    {
        delay += Time.fixedDeltaTime;

        if (delay >= 1 / amount)
        {
            amount *= multiplier;
            delay = 0f;

            //GameObject m = PoolingManager.instance.GetObject("meteor");
            GameObject m = Instantiate(meteor);

            float height = cam.orthographicSize - 1;
            float width = cam.orthographicSize * cam.GetComponent<Camera>().aspect - 1;

            m.transform.position = new Vector2(Random.Range(-width, width), Random.Range(-height, height));
        }
    }
}
