using UnityEngine;

public class bgmplayer : MonoBehaviour
{
    private static bool isPlaying = false;   // 이미 재생 중인지 여부
    private static uint bgmPlayingID;        // 현재 재생 중인 BGM ID 저장

    void Awake()
    {
        // 중복 오브젝트 방지
        if (FindObjectsOfType<bgmplayer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // 게임 시작 시 한 번만 BGM 재생
        if (!isPlaying)
        {
            bgmPlayingID = AkSoundEngine.PostEvent("bgm", gameObject);
            isPlaying = true;
        }
    }
}
