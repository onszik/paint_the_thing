using UnityEngine;

public class Brush : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            transform.parent = other.transform;
            transform.position = other.transform.position;
            other.gameObject.GetComponent<Player>().hasBrush = true;
        }
    }
}
