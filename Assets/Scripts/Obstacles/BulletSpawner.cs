using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bullet;

    public float amount = 3f;
    public float bulletSpeed = 10f;
    public float multiplier = 1.01f;

    public float flipX = 0;
    public float flipY = 0;

    private float delay = 0;

    void FixedUpdate() {
        delay += Time.fixedDeltaTime;

        if (delay >= 1 / amount)
        {
            amount *= multiplier;
            delay = 0f;

            //transform.Rotate(new Vector3(0, 0, Random.Range(-45f, 45f)), Space.World);

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

            bulletSpeed *= multiplier;
        }
    }
}
