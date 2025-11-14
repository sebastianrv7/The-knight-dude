using Unity.VisualScripting;
using UnityEngine;

public enum CharacterState
{
    Idle,
    Attack,
    Death
}
public class KnightController : MonoBehaviour
{

    public CharacterState currentState = CharacterState.Idle;
    private KnightActions actions;
    private KnightInputRouter inputRouter;

    private void Awake()
    {
        actions = GetComponent<KnightActions>();
        inputRouter = GetComponent<KnightInputRouter>();
    }

    

    public void SetState(CharacterState newState, Vector2 dir = default)
    {
        currentState = newState;

        switch(currentState)
        {
            case CharacterState.Idle:
                EnableInputs(true);
                actions.PlayIdle();
                break;
            case CharacterState.Attack:
                EnableInputs(false);
                actions.EnableHitbox();
                break;
            case CharacterState.Death:
                EnableInputs(false);
                actions.PlayDeath();
                break;
        }
    }


    private void EnableInputs(bool enable)
    {
        inputRouter.enabled = enable;
    }

    


}
