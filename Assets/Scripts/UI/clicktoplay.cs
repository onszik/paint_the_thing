using UnityEngine;
using UnityEngine.SceneManagement;

public class clicktoplay : MonoBehaviour
{
 
    
    void Start()
    {
        gameObject.SetActive(false);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            text.scoreValue = 0;

        }
    }
}
