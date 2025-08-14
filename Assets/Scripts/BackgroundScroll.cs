using UnityEngine;

public class Back : MonoBehaviour
{
    // 스크롤 속도를 제어하는 speed와 mesh renderer 에 대한 권한 만들어줌 
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    
    public float scrollSpeed;

    // MeshRenderer  생성
    [Header("References")]
    public MeshRenderer meshRenderer;

    // Start 는 Update가 최초로 실행되기 전 한번만 실행
    void Start()
    {
        
    }

    // 프레인당 한번씩 실행됨
    void Update() // 초당 10단위를 움직이고 싶고 ||| 개임이 초당 2프레임이 나온다
    {            //Time.deltaTime 이전 프레임에서 지금 프레임까지에 초 단위 간격     
                 // Vector2 는 X,Y 축 Vector3 는 X,Y,Z

        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() /20  * Time.deltaTime, 0);
    }
}


// Sky는 0.1 Building 0.2 Platform 0.8