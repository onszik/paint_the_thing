using UnityEngine;

public class SpawnShaped : MonoBehaviour {

    public GameObject[] shapes;

    public AudioSource sound;

    void Start()
    {
        SpawnShape();
    }

    public void SpawnShape()
    {
        int rand = Random.Range(0, shapes.Length );
        GameObject s = Instantiate(shapes[rand]) as GameObject;

        s.transform.parent = transform;
        s.transform.position = new Vector2(0, 0);

        SoundFX.paintSound.pitch = 1f;
        SoundFX.paintSound.GetComponent<AudioChorusFilter>().depth = 0;
    }

    public void PlaySound()
    {
        sound.Play();
    }

    public void DestroyShape() {
    }
}
