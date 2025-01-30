using UnityEngine;

public class Pixel : MonoBehaviour {
    public bool full = false;

    public Color c;

    private SpriteRenderer spr;

    void Start() {
        spr = GetComponent<SpriteRenderer>();
    }

    public void Color() {
        spr.color = c;

        transform.parent.rotation = Quaternion.identity;
        //transform.parent.localScale = new Vector3(1, 1, 1);

        Shake.tilt(transform.parent);

        transform.parent.GetComponent<Shape>().CheckDone();
        transform.parent.GetComponent<Shape>().SpawnBrush();
    }
}
