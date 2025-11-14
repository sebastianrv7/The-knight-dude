using System.Collections;
using UnityEngine;

public class KnightActions : MonoBehaviour
{

    [Header("Hitbox")]
    [SerializeField] private Collider2D burstCollider;
    [SerializeField] private Transform hitboxLeftPos;
    [SerializeField] private Transform hitboxRightPos;

    [Header("Visual")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private KnightController knight;

    private void Awake()
    {
        knight = GetComponent<KnightController>();
    }
    private void OnEnable()
    {
        GameEvents.OnPlayerAttackDirection += HandleAttack;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerAttackDirection -= HandleAttack;
    }

    private void HandleAttack(Vector2 direction)
    {
        spriteRenderer.flipX = (direction.x < 0);

        animator.SetTrigger("Attack");
        knight.SetState(CharacterState.Attack);
        if(direction == Vector2.left)
        {
            burstCollider.transform.position = hitboxLeftPos.position;
            
        } else
        {
            burstCollider.transform.position = hitboxRightPos.position;
        }

        Invoke(nameof(EndAttack), 0.5f);    

    }

    public void EnableHitbox()
    {
        burstCollider.enabled = true;
    }

    public void PlayIdle()
    {
        animator.SetTrigger("Idle");
        burstCollider.enabled = false;
    }

    public void PlayDeath()
    {
        animator.SetTrigger("Death");
        burstCollider.enabled = false;
        
    }
    private void EndAttack()
    {
        
        knight.SetState(CharacterState.Idle);
    }

    
}
