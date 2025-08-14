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
        GameObject ramdomObject = gameObjects[Random.Range(0, gameObjects.Length)]; // ������ ��ü �̾Ƴ���
        Instantiate(ramdomObject, transform.position, Quaternion.identity); // �ش� ��ü ��ġ�� �־��ֱ� 
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
