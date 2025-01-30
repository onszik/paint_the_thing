using UnityEngine;

public class Shape : MonoBehaviour {
    public GameObject brush;
    private SpawnShaped spawner;

    public GameObject effect;

    public bool done;

    public Pixel[] pixels;

    private Camera cam;

    void Start() {
        spawner = transform.parent.gameObject.GetComponent<SpawnShaped>();
        pixels = GetComponentsInChildren<Pixel>();
        cam = Camera.main;

        if (GameObject.Find("Brush(Clone)") == null) {
            SpawnBrush();
        }
    }

    /*
    Color[] colors = new Color[pixels.Length];

    void Start() {
        int i = 0;
        foreach (Pixel[] pixels = GetComponentsInChildren<Pixel>() pxl in pixels) {
            colors[i] = pixels[i].c;
            i++;
        }
    }
    */

    public void CheckDone() {
        foreach(Pixel pxl in pixels) {
            if (pxl.full == true) {
                done = true;
            } else {
                done = false;
                break;
            }
        }

        if (done) {
            spawner.SpawnShape();
            spawner.PlaySound();
            StartEffect();

            Shake.camShake();

            int shapes = PlayerPrefs.GetInt("CompletedShapes", 0);
            shapes++;
            PlayerPrefs.SetInt("CompletedShapes", shapes);

            Destroy(gameObject);
        }
    }

    public void SpawnBrush() {
        GameObject b = Instantiate(brush);

        float height = cam.orthographicSize - 1f;
        float width = cam.orthographicSize * cam.GetComponent<Camera>().aspect - 1f;

        b.transform.position = new Vector2(Random.Range(-width, width), Random.Range(-height, height - 2));
    }

    public void StartEffect()
    {
        //this.transform.parent.gameObject.GetComponent<Animator>().Play("ShapeDisapear");
        foreach (Pixel pxl in pixels)
        {

            GameObject e = Instantiate(effect);

            ParticleSystem.MainModule p = e.GetComponent<ParticleSystem>().main;
            p.startColor = new ParticleSystem.MinMaxGradient(pxl.c);

            e.transform.position = pxl.transform.position;
        }
    }
}
