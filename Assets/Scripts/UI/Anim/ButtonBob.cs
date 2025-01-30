using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBob : MonoBehaviour
{
    private RectTransform rect;
    private Vector2 startPos;

    public Vector2 movement = new Vector3(0, 10);
    public float speed = 1f;
    public bool smooth;

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;

        if (smooth)
        {
            Sequence s = DOTween.Sequence();

            s.Append(rect.DOAnchorPos(startPos + movement, speed))
             .Append(rect.DOAnchorPos(startPos, speed));

            s.SetLoops(-1);
        }
        else
        {
            rect.DOAnchorPos(startPos + movement, speed).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
