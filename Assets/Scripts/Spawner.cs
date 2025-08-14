using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Setting")]
    public float minSpawnDelay;  
    public float maxSpawnDelay;  

    [Header("References")]
    public GameObject[] gameObjects;
    
    void OnEnable()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay , maxSpawnDelay));
    }

    void OnDisable()
    {
        CancelInvoke(); 
    }

    void Spawn() 
    {
        GameObject ramdomObject = gameObjects[Random.Range(0, gameObjects.Length)]; // 무작위 객체 뽑아내기
        Instantiate(ramdomObject, transform.position, Quaternion.identity); // 해당 객체 위치에 넣어주기 
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
