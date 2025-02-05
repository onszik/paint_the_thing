using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewLazer : MonoBehaviour {
    private LineRenderer lineRenderer;

    public float minWidth = 0.05f;
    public float maxWidth = 0.2f;
    public float pulseSpeed = 2f;

    private float time;

    void Update() {
        time += Time.deltaTime * pulseSpeed;
        float width = Mathf.Lerp(minWidth, maxWidth, (Mathf.Sin(time) + 1) / 2);

        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
