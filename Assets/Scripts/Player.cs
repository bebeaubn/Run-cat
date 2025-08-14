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

    // ������ �����̽� Ű�� ������ �� �����ϴ� �۾� 
    // Player�� ���� �� ���� �ִϸ��̼� S
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AkSoundEngine.PostEvent("jump", gameObject);   // ���� �� ����
            PlayerRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);
        }
    }
    // ������ state �� 2�� ���� 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                AkSoundEngine.PostEvent("land", gameObject);   // ���� ����
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    // Player�� ���� �� ���� �ִϸ��̼� E

    // Player�� �繰�� �΋Hġ�ų� �������� �Ծ����� ����� �ڵ� S 

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
    // �ε��� ���� ������ ���� ����� �ڵ�
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            if (!isInvincible)
            {
                AkSoundEngine.PostEvent("hit", gameObject);  // �浹�� ���� ����
                Destroy(collider.gameObject);
                Hit();
            }
        }
        else if (collider.gameObject.tag == "food")
        {

            AkSoundEngine.PostEvent("item", gameObject);  // ���� ������ ����
            Destroy(collider.gameObject);
            Heal();
        }
        else if (collider.gameObject.tag == "golden")
        {

            AkSoundEngine.PostEvent("item", gameObject); // ���� ������ ����
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}  // Player�� �繰�� �΋Hġ�ų� �������� �Ծ����� ����� �ڵ� E
