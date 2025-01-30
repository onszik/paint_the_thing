using UnityEngine;

public class pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject text;

    public RectTransform bar;

    public Movement mvt;

    private bool holding = false;
    public float holdDuration = 1.5f;
    private float timer = 0;

    public void pauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            text.SetActive(true);

            mvt.enabled = false;
        }
    }

    private void Update()
    {
        if (!isPaused)
            return;

        if (holding == false && Input.GetMouseButtonDown(0))
        {
            print("holding");

            holding = true;

            bar.gameObject.SetActive(true);
        } else if (holding == true && Input.GetMouseButtonUp(0))
        {
            holding = false;

            print("stopped holding after " + timer);

            timer = 0;

            bar.gameObject.SetActive(false);
        }

        if (holding)
        {
            timer += Time.unscaledDeltaTime;

            bar.localScale = new Vector2(((holdDuration - timer) / holdDuration) * 5, bar.localScale.y);

            if (timer >= holdDuration)
            {
                print("restumed");

                Time.timeScale = 1;
                isPaused = false;
                text.SetActive(false);

                mvt.enabled = true;
            }
        }
    }
}
