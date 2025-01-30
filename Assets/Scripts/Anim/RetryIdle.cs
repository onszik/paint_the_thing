using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RetryIdle : MonoBehaviour
{
    public float speed = 1f;

    private Sequence rotation;

    void Start()
    {
        rotation = DOTween.Sequence();

        transform.DORotate(new Vector3(0, 0, 5), 0.45f * speed);

        //rotation.Append(transform.DORotate(new Vector3(0, 0, 5), 0.9f * speed));
        //rotation.Append(transform.DORotate(new Vector3(0, 0, -5), 0.9f * speed));

        //rotation.SetLoops(-1);
        //rotation.SetEase(Ease.InOutElastic, 5, 0);
    }
}
