using UnityEngine;
using System.Collections.Generic;

public class BulletSpawner1 : MonoBehaviour {

    public GameObject bulletPrefab;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private List<GameObject> activeBullets = new List<GameObject>();

    #region bullet stats

    public float delay = 3f;
    public float numOfBullets = 4;
    public float numOfBulletsIncrease = 0.5f;
    public float bulletSpeed = 10f;

    public float spreadAngle = 70f;
    #endregion

    public float previewDrawRange = 2f;

    private void Start() {
        InvokeRepeating("SpawnBullets", delay, delay);
    }

    private void FixedUpdate() {
        MoveBullets();
    }

    void SpawnBullets() {
        for (int i = 0; i < Mathf.Floor(numOfBullets); i++) {

            GameObject b = GetFromPool();
            b.transform.position = transform.position;
            b.transform.right = transform.right;
            b.transform.Rotate(0f, 0f, Random.Range(-spreadAngle, spreadAngle));
            b.SetActive(true);
        }

        numOfBullets += numOfBulletsIncrease;
    }

    GameObject GetFromPool() {
        if (bulletPool.Count > 0) {
            GameObject b = bulletPool.Dequeue();
            //b.SetActive(true);
            activeBullets.Add(b);
            return b;
        } else {
            GameObject b = Instantiate(bulletPrefab);
            b.transform.parent = transform;
            activeBullets.Add(b);
            return b;
        }
    }

    public void PutInPool(GameObject bullet) {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    private void MoveBullets() {
        for (int i = activeBullets.Count - 1; i >= 0; i --) {
            GameObject b = activeBullets[i];

            b.transform.position += (Vector3)b.transform.right * bulletSpeed * Time.deltaTime;

            if (b.transform.position.magnitude > 10f) // adjust for screen size
            {
                activeBullets.RemoveAt(i);
                PutInPool(b);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Vector3 forward = transform.right * previewDrawRange;

        Vector3 leftDir = Quaternion.Euler(0, 0, -spreadAngle) * forward;
        Vector3 rightDir = Quaternion.Euler(0, 0, spreadAngle) * forward;

        Gizmos.DrawLine(transform.position, transform.position + leftDir);
        Gizmos.DrawLine(transform.position, transform.position + rightDir);
    }
}
