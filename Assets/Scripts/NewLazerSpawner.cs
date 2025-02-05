using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewLazerSpawner : MonoBehaviour {
    public GameObject lazerPrefab;
    private Queue<GameObject> lazerPool = new Queue<GameObject>();
    private List<LineRenderer> activeLazers = new List<LineRenderer>();

    public AudioSource sound;

    public float delay = 3f;
    public float numOfLazers = 2;
    public float numOfLazersIncrease = 1;

    private LineRenderer templateLaser;

    public LayerMask playerLayer;
    private int layerMask;

    void Start() {
        InvokeRepeating("SpawnLazers", delay, delay);

        templateLaser = Instantiate(lazerPrefab).GetComponent<LineRenderer>();
        templateLaser.SetPosition(0, new Vector2(-99, -99));
        templateLaser.SetPosition(1, new Vector2(-99, -99));

        if (playerLayer.value == 0) {
            playerLayer = LayerMask.NameToLayer("Player");
        }
        layerMask = 1 << playerLayer; // Only check collisions with the "Player" layer
    }

    void SpawnLazers() {
        for (int i = 0; i < Mathf.Floor(numOfLazers); i++) {
            GameObject l = PoolingManager.instance.GetObject("lazer");
            l.transform.SetParent(transform, true);
            activeLazers.Add(l.GetComponent<LineRenderer>());

            (Vector2 position1, Vector2 position2) = Utility.GetRandomPointsOnOppositeBounds();
            LineRenderer line = l.GetComponent<LineRenderer>();
            line.SetPosition(0, position1);
            line.SetPosition(1, position2);
        }
        numOfLazers += numOfLazersIncrease;

        AnimateTemplateLaser();
        sound.Play();
    }
    void AnimateTemplateLaser() {
        // Set initial values for the template
        templateLaser.startWidth = 0.55f;
        templateLaser.endWidth = 0.55f;
        Color startColor = templateLaser.startColor;
        startColor.a = 0;
        templateLaser.startColor = startColor;
        templateLaser.endColor = startColor;

        // Create the animation sequence for the template
        Sequence sequence = DOTween.Sequence();

        // Width and opacity animations
        sequence.Append(DOTween.To(() => templateLaser.startWidth, x => {
            templateLaser.startWidth = x;
            templateLaser.endWidth = x;
            UpdateAllLasers(); // Update all lasers when width changes
        }, 0.45f, 1f).SetEase(Ease.Linear)); // Width to 0.45f at 1s

        sequence.Join(DOTween.To(() => templateLaser.startColor.a, x => {
            startColor.a = x;
            templateLaser.startColor = startColor;
            templateLaser.endColor = startColor;
            UpdateAllLasers(); // Update all lasers when opacity changes
        }, 0.62f, 1f).SetEase(Ease.Linear)); // Opacity to 0.62f at 1s

        sequence.Append(DOTween.To(() => templateLaser.startWidth, x => {
            templateLaser.startWidth = x;
            templateLaser.endWidth = x;
            UpdateAllLasers(); // Update all lasers when width changes
        }, 0.2f, 0.12f).SetEase(Ease.Linear)); // Width to 0.2f at 1.12s

        sequence.Join(DOTween.To(() => templateLaser.startColor.a, x => {
            startColor.a = x;
            templateLaser.startColor = startColor;
            templateLaser.endColor = startColor;
            UpdateAllLasers(); // Update all lasers when opacity changes
        }, 1f, 0.12f).SetEase(Ease.Linear)); // Opacity to 1f at 1.12s

        sequence.Append(DOTween.To(() => templateLaser.startWidth, x => {
            templateLaser.startWidth = x;
            templateLaser.endWidth = x;
            UpdateAllLasers(); // Update all lasers when width changes
        }, 0.05f, 0.12f).SetEase(Ease.Linear)); // Width to 0.05f at 1.24s


        sequence.InsertCallback(1.24f, () => {
            StartCoroutine(CheckCollisionDuringInterval(0.26f));
        });

        sequence.AppendInterval(0.26f); // Hold until 1.5s


        sequence.Append(DOTween.To(() => templateLaser.startWidth, x => {
            templateLaser.startWidth = x;
            templateLaser.endWidth = x;
            UpdateAllLasers(); // Update all lasers when width changes
        }, 0.5f, 0.25f).SetEase(Ease.Linear)); // Width to 0.5f at 1.75s

        sequence.Join(DOTween.To(() => templateLaser.startColor.a, x => {
            startColor.a = x;
            templateLaser.startColor = startColor;
            templateLaser.endColor = startColor;
            UpdateAllLasers(); // Update all lasers when opacity changes
        }, 0f, 0.25f).SetEase(Ease.Linear)); // Opacity to 0f at 1.75s

        sequence.OnComplete(() => PutInPool());
        // Play the sequence
        sequence.Play();
    }

    void UpdateAllLasers() {
        foreach (var laser in activeLazers) {
            laser.startWidth = templateLaser.startWidth;
            laser.endWidth = templateLaser.endWidth;
            laser.startColor = templateLaser.startColor;
            laser.endColor = templateLaser.endColor;
        }
    }

    IEnumerator CheckCollisionDuringInterval(float duration = 0.26f) {
        float elapsed = 0f;

        while (elapsed < duration) {
            CheckCollision(); // Call every frame
                              // For every other frame, use: if (Time.frameCount % 2 == 0) CheckCollision();

            elapsed += Time.deltaTime;
            yield return null; // Wait for next frame
        }
    }

    void CheckCollision() {
        foreach (var l in activeLazers) {
            Vector2 startPoint = l.GetPosition(0);
            Vector2 endPoint = l.GetPosition(1);

            Vector2 direction = (endPoint - startPoint).normalized;
            float distance = Vector2.Distance(startPoint, endPoint);

            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, distance, layerMask);

            if (hit.collider != null) {
                // Since we're only checking the "Player" layer, no need to check the tag
                Debug.Log("Player hit by laser!");
                break;
            }
        }
    }

    /*
    GameObject GetFromPool() {
        if (lazerPool.Count > 0) {
            GameObject b = lazerPool.Dequeue();
            b.SetActive(true);
            activeLazers.Add(b.GetComponent<LineRenderer>());
            return b;
        } else {
            GameObject b = Instantiate(lazerPrefab);
            b.transform.parent = transform;
            activeLazers.Add(b.GetComponent<LineRenderer>());
            return b;
        }
    }
    */ 

    public void PutInPool(GameObject lazer = null) {
        if (lazer == null) {
            // Pool all active lasers
            foreach (var l in activeLazers) {
                PoolingManager.instance.DiscardObject("lazer", l.gameObject);
            }
            activeLazers.Clear(); // Clear the list after pooling all lasers
        } else {
            // Pool a specific laser
            LineRenderer line = lazer.GetComponent<LineRenderer>();
            if (line != null) {
                PoolingManager.instance.DiscardObject("lazer", line.gameObject);
            }
        }
    }
}
