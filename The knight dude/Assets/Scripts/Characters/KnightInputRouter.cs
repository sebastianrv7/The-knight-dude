
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class KnightInputRouter : MonoBehaviour
{
    private ActionMap input;

    private void Awake()
    {
        input = new ActionMap();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Knight.AttackLeft.performed += OnAttackLeft;
        input.Knight.AttackRight.performed += OnAttackRight;
    }

    private void OnDisable()
    {
        input.Knight.AttackLeft.performed -= OnAttackLeft;
        input.Knight.AttackRight.performed -= OnAttackRight;
        input.Disable();
    }

    private void OnAttackLeft(InputAction.CallbackContext ctx)
    {
        GameEvents.OnPlayerAttackDirection?.Invoke(Vector2.left); ;
    }

    private void OnAttackRight(InputAction.CallbackContext ctx)
    {
        GameEvents.OnPlayerAttackDirection?.Invoke(Vector2.right);
        
    }
}
