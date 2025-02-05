using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroty : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
