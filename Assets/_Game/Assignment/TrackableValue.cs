using UnityEngine;
using UnityEngine.Events;

public abstract class TrackableValue<T> : ScriptableObject
{
    [SerializeField] protected T _baseValue;
    private T _currentValue;
    
    [HideInInspector] public UnityEvent<T> CallbackOnValueChanged;
    
    public T Value
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                CallbackOnValueChanged.Invoke(_currentValue); 
            }
        }
    
    private void OnEnable()
    {
        _currentValue = _baseValue;
    }
}
