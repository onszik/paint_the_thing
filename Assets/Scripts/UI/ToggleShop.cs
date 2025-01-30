using UnityEngine;
using DG.Tweening;

public class ToggleShop : MonoBehaviour
{

    public RectTransform shop, main;
    public float speed = 1f;
    public void OpenShop()
    {
        shop.DOAnchorPos(new Vector2(0, 0), speed);
        main.DOAnchorPos(new Vector2(1080, 0), speed);
    }
    public void CloseShop()
    {
        main.DOAnchorPos(new Vector2(0, 0), speed);
        shop.DOAnchorPos(new Vector2(-1080, 0), speed);
    }
}
