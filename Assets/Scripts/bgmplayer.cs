using UnityEngine;

public class bgmplayer : MonoBehaviour
{
    private static bool isPlaying = false;   // �̹� ��� ������ ����
    private static uint bgmPlayingID;        // ���� ��� ���� BGM ID ����

    void Awake()
    {
        // �ߺ� ������Ʈ ����
        if (FindObjectsOfType<bgmplayer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // ���� ���� �� �� ���� BGM ���
        if (!isPlaying)
        {
            bgmPlayingID = AkSoundEngine.PostEvent("bgm", gameObject);
            isPlaying = true;
        }
    }
}
