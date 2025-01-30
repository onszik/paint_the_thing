using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    public static Transform cam;

    private void Start()
    {
        cam = Camera.main.transform.parent;
    }

    public static void camShake(float strength = 0.5f, float duration = 0.6f, int vibrato = 30)
    {
        cam.DOShakePosition(strength, duration, vibrato);
    }

    public static void tilt(Transform t)
    {
        t.DOPunchRotation(new Vector3(0, 0, Random.Range(-5, 5)), 0.15f, 2, 1);

        float sR = Random.Range(-0.2f, 0.2f);

        t.DOPunchScale(new Vector3(sR, sR, 1), 0.2f, 2, 0);

        //t.DOShakeRotation(0.15f, 3f, 1);
        //t.DOShakeScale(0.15f, 0.1f, 1);
    }
}
