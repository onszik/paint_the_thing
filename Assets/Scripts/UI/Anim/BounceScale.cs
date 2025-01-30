using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BounceScale : MonoBehaviour
{
    private RectTransform rect;
    private Vector2 startSize;

    public Vector2 scale = new Vector3(1.1f, 1.1f);
    public float speed = 0.5f;
    public float delay = 2f;

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        startSize = rect.localScale;

        Sequence s = DOTween.Sequence();

        s.Append(rect.DOScale(startSize * scale, speed))
         .Append(rect.DOScale(startSize, speed))
         .AppendInterval(delay);

        s.SetLoops(-1);
    }
}
