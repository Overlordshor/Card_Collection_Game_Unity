using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public Action OnFinishedPlace;

    [SerializeField] private Transform _hand;
    [SerializeField] private GameObject _cardPref;
    [SerializeField] private bool _contains—opies;
    private List<CardData> _cardsData;

    public void TryGetCard()
    {
        if (_hand.childCount >= Configuration.MaxCountCardsOnField)
        {
            OnFinishedPlace();
            return;
        }

        var card = Instantiate(_cardPref, _hand);

        var randomIndexCard = Random.Range(0, _cardsData.Count);
        var cardData = _cardsData[randomIndexCard];
        card.GetComponent<Card>().SetData(cardData);

        if (!_contains—opies)
        {
            _cardsData.Remove(cardData);
            if (_cardsData.Count == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _cardsData = new List<CardData>();
        _cardsData.AddRange(Resources.LoadAll<CardData>("Data/CardsData"));
    }
}