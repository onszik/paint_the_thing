using UnityEngine;

public class Lazer : MonoBehaviour
{

    void ToggleDanger()
    {
        if (gameObject.tag == "enemy")
        {
            gameObject.tag = "Default";
        }
        else
        {
            gameObject.tag = "enemy";
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
