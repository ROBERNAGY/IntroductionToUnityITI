using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownGameManager : MonoBehaviour
{
    [SerializeField] TopDownCharacterController topDownCharacterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(topDownCharacterController.health <= 0.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
