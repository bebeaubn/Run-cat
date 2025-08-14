using UnityEngine;

public class Back : MonoBehaviour
{
    // ��ũ�� �ӵ��� �����ϴ� speed�� mesh renderer �� ���� ���� ������� 
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    
    public float scrollSpeed;

    // MeshRenderer  ����
    [Header("References")]
    public MeshRenderer meshRenderer;

    // Start �� Update�� ���ʷ� ����Ǳ� �� �ѹ��� ����
    void Start()
    {
        
    }

    // �����δ� �ѹ��� �����
    void Update() // �ʴ� 10������ �����̰� �Ͱ� ||| ������ �ʴ� 2�������� ���´�
    {            //Time.deltaTime ���� �����ӿ��� ���� �����ӱ����� �� ���� ����     
                 // Vector2 �� X,Y �� Vector3 �� X,Y,Z

        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() /20  * Time.deltaTime, 0);
    }
}


// Sky�� 0.1 Building 0.2 Platform 0.8