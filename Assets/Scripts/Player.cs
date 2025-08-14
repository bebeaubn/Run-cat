using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;
    public BoxCollider2D PlayerCollider;

    private bool isGrounded = true;
    public bool isInvincible = false;

    // 유저가 스페이스 키를 누르는 걸 감지하는 작업 
    // Player가 점프 및 착지 애니메이션 S
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AkSoundEngine.PostEvent("jump", gameObject);   // 점프 시 사운드
            PlayerRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);
        }
    }
    // 점프시 state 값 2로 변경 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                AkSoundEngine.PostEvent("land", gameObject);   // 착지 사운드
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    // Player가 점프 및 착지 애니메이션 E

    // Player가 사물에 부딫치거나 아이템을 먹었을때 사용할 코드 S 

    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        isInvincible = false;
    }
    // 인덱스 따라서 아이템 사용시 실행될 코드
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            if (!isInvincible)
            {
                AkSoundEngine.PostEvent("hit", gameObject);  // 충돌시 나는 사운드
                Destroy(collider.gameObject);
                Hit();
            }
        }
        else if (collider.gameObject.tag == "food")
        {

            AkSoundEngine.PostEvent("item", gameObject);  // 음식 먹을때 사운드
            Destroy(collider.gameObject);
            Heal();
        }
        else if (collider.gameObject.tag == "golden")
        {

            AkSoundEngine.PostEvent("item", gameObject); // 음식 먹을때 사운드
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}  // Player가 사물에 부딫치거나 아이템을 먹었을때 사용할 코드 E
