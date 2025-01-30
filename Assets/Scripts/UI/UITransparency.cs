using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransparency : MonoBehaviour
{
    public CanvasGroup group;

    public float transparency = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(Fade(transparency)) ;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Fade(1f));
        }
    }

    IEnumerator Fade(float target)
    {
        float step = 0.07f;
        float start = group.alpha;

        if (start > target)
        {
            for (float i = start; i > target; i -= step)
            {
                group.alpha = i;
                yield return new WaitForSeconds(.01f);
            }
        } else
        {
            for (float i = start; i < target; i += step)
            {
                group.alpha = i;
                yield return new WaitForSeconds(.01f);
            }
        }
    }
}
