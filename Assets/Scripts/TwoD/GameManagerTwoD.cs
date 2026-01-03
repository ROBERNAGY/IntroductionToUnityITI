using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTwoD : MonoBehaviour
{
    [SerializeField] private CharacterController2D player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.alive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
