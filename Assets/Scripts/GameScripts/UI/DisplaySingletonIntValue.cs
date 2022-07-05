using System;
using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DisplaySingletonIntValue : MonoBehaviour{
    [SerializeField] private SOSingleInt _singletonToDisplay;
    [SerializeField] private SOGameEvent _event;
    private TextMeshProUGUI _text;

    private void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
    }
    

    private void OnEnable() {
        _event.Subscribe(UpdateText);
        UpdateText();
    }

    private void OnDisable() {
        _event.Unsubscribe(UpdateText);
    }

    private void UpdateText() {
        _text.text = _singletonToDisplay.Value.ToString();
    }
    
}
