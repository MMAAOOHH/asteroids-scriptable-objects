using System;
using DefaultNamespace.ScriptableEvents;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [Header("Health:")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEventIntReference _onHealthChangedEvent;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TrackableInt _asteroidsDestroyed;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        
        private void Start()
        {
            SetHealthText($"Health: {_healthVar.Value}");
            _asteroidsDestroyed.CallbackOnValueChanged.AddListener(SetScoreText);
        }

        public void OnHealthChanged(IntReference newValue)
        {
            SetHealthText($"Health: {newValue.GetValue()}");
        }

        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        
        private void SetScoreText(int asteroidsDestroyed)
        {
            _scoreText.text = ($"Asteroids Destroyed: {asteroidsDestroyed.ToString()}");
        }
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
    }
}
