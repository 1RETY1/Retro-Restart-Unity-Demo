using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce;

    [Header("Platform Check")]
    [SerializeField] private ContactFilter2D _platform;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip _jumpSound;   // <-- сюда вставляешь звук прыжка
    [SerializeField] private float _jumpVolume = 1f; // громкость от 0 до 1

    private Rigidbody2D _rigidbody;
    private bool _isOnPlatform => _rigidbody.IsTouching(_platform);
    private bool isDead = false;  // флаг смерти

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Прыжок на пробел
        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (isDead) return; // нельзя прыгать после смерти

        if (_isOnPlatform)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            // Воспроизводим звук прыжка через AudioSource.PlayClipAtPoint
            if (_jumpSound != null)
            {
                AudioSource.PlayClipAtPoint(_jumpSound, transform.position, _jumpVolume);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.transform.parent != null)
        {
            if (collisionObject.transform.parent.TryGetComponent(out Platform platform))
                platform.StopMovement();
        }

        if (collisionObject.CompareTag("PlatformWall"))
        {
            Die();  // вызываем смерть
        }
        else if (collisionObject.CompareTag("Platform"))
        {
            collisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }

    private void Die()
    {
        isDead = true; // ставим флаг смерти

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.bodyType = RigidbodyType2D.Static;

        Dead?.Invoke();
    }
}







