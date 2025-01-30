using UnityEngine;

public class BulletSpawner1 : MonoBehaviour {
    public GameObject bullet;

    public float delay = 3f;
    public float bulletSpeed = 10f;

    public float numOfBullets = 4;
    public float numOfBulletsIncrease = 0.5f;

    public float flipX = 0;
    public float flipY = 0;

    private void Start() {
        InvokeRepeating("SpawnBullets", delay, delay);
    }

    void SpawnBullets() {
        for (int i = 0; i < Mathf.Floor(numOfBullets); i++) {

            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = transform.position;
            var rb = b.GetComponent<Rigidbody2D>();

            float xspd = Random.Range(1, bulletSpeed + 1);
            float yspd = Mathf.Clamp(bulletSpeed / xspd, 0, bulletSpeed);

            if (flipX > 0) {
                if (Random.value <= flipX) {
                    xspd *= -1;
                }
            }
            if (flipY > 0) {
                if (Random.value <= flipY) {
                    yspd *= -1;
                }
            }

            rb.velocity = new Vector2(xspd - 1, yspd);
            Destroy(b, 7f);
        }

        counter = 0f;
        numOfBullets += numOfBulletsIncrease;
    }
}
