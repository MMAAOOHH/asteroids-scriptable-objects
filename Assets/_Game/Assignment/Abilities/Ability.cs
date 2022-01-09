using UnityEngine;

namespace Assignment
{
    [CreateAssetMenu]
    public class Ability : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _duration;
        [SerializeField] private float _cooldown;
        
        public float Duration => _duration;
        public float Cooldown => _cooldown;

        public virtual void Activate(GameObject parent){}
        public virtual void Reset(){}
    }
}
