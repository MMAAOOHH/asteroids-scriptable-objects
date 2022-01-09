using Assignment;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private KeyCode _useAbilityKey;
    
    private float _cooldownTime;
    private float _activeTime;
    
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    private AbilityState _state = AbilityState.ready;
    
    private void Update()
    {
        switch (_state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(_useAbilityKey))
                {
                    _ability.Activate(gameObject);
                    _state = AbilityState.active;
                    _activeTime = _ability.Duration;
                }
                break;
            
            case AbilityState.active:
                if (_activeTime > 0)
                {
                    _activeTime -= Time.deltaTime;
                }
                else
                {
                    _ability.Reset();
                    _state = AbilityState.cooldown;
                    _cooldownTime = _ability.Cooldown;
                }
                break;
            
            case AbilityState.cooldown:
                _state = AbilityState.ready;
                break;
        }
    }
}
