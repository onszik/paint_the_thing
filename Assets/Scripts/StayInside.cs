using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f),
            Mathf.Clamp(transform.position.y, -6.5f, 6.5f), transform.position.z);
    }
}
