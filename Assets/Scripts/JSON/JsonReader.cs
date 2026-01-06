using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public class JsonReader : MonoBehaviour
{
    public TextAsset jsonTextAsset;
    public PlayerDataList data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = JsonUtility.FromJson<PlayerDataList>(jsonTextAsset.text);
        Debug.Log(jsonTextAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
