using System;
using UnityEngine;

public class FinishedPlaceHandler : MonoBehaviour
{
    [SerializeField] private GameObject _endCardsPanel;
    private Action _actionDeck, _actionGameField;

    private void Start()
    {
        _actionDeck = FindObjectOfType<Deck>().OnFinishedPlace += SetActive;
        _actionGameField = FindObjectOfType<DropHandler>().OnFinishedPlace += SetActive;
    }

    private void SetActive()
    {
        _endCardsPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        _actionDeck -= SetActive;
        _actionGameField -= SetActive;
    }
}