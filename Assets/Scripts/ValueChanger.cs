using System.Collections;
using UnityEngine;

public class ValueChanger : MonoBehaviour
{
    private static int _currentCardIndex;
    private AnimationChangeValue _animation;
    private int _randomChangeValue;

    public int RandomChangeValue
    {
        get => _randomChangeValue;
        private set => _randomChangeValue = value;
    }

    public void ChangeValue()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No cards in hand");
            return;
        }

        var hand = transform;
        if (hand.childCount <= _currentCardIndex)
        {
            _currentCardIndex = 0;
        }

        var valueType = GetValueType();

        var cardTranform = hand.GetChild(_currentCardIndex);
        _animation.PlayAnimation(valueType, cardTranform);
        StartCoroutine(UpdateStats(cardTranform, valueType));

        _currentCardIndex++;
    }

    private void Start()
    {
        _animation = GetComponent<AnimationChangeValue>();
    }

    private static int GetRandomChangeValue()
    {
        return Random.Range(-2, 10);
    }

    private static ValueType GetValueType()
    {
        return (ValueType)Random.Range(0, 2);
    }

    private IEnumerator UpdateStats(Transform cardTranform, ValueType valueType)
    {
        var card = cardTranform.GetComponent<Card>();
        _randomChangeValue = GetRandomChangeValue();
        Debug.Log($"Type: {valueType}, RandomValue: {_randomChangeValue}");

        yield return new WaitForSeconds(_animation.Length);

        switch (valueType)
        {
            case ValueType.Attack:
                card.Attack += _randomChangeValue;
                break;

            case ValueType.HitPoints:
                card.HitPoints += _randomChangeValue;
                break;
        }
    }
}