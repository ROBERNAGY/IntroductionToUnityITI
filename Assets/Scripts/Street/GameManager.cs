using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> carsList;
    [SerializeField] private Transform rightStartPoint;
    [SerializeField] private Transform leftStartPoint;

    private int selectedCarIndex;
    private float direction = 1;

    private float spawnTimer = 0.0f;
    [SerializeField] private float spawnCooldown = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnCooldown)
        {
            SpawnCar();
            spawnTimer =0.0f;
        }
    }
    private void SpawnCar()
    {
        SelectCar();
        SetCarDirection();
        SetCarPosition();
        ActiveCar();
        ReverseDirection();
    }
    private void SelectCar()
    {
        for (int i = 0; i < carsList.Count; i++)
        {
            if (!carsList[i].activeSelf)
            {
                selectedCarIndex = i;
                break;
            }
        }
    }
    private void SetCarDirection()
    {
        carsList[selectedCarIndex].GetComponent<CarManager>().direction = new Vector3(0, 0, direction);
    }
    private void SetCarPosition()
    {
        if(direction == 1)
        {
            carsList[selectedCarIndex].GetComponent<CarManager>().carTransform = rightStartPoint;
        }
        else if(direction == -1)
        {
            carsList[selectedCarIndex].GetComponent<CarManager>().carTransform = leftStartPoint;
        }
    }
    private void ActiveCar()
    {
        carsList[selectedCarIndex].SetActive(true);
    }

    private void ReverseDirection()
    {
        direction = -direction;
    }
}
