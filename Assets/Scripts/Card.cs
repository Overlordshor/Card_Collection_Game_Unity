using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private RawImage _logo;
    [SerializeField] private TextMeshProUGUI _name, _attack, _hp, _mana;

    private CardData _cardData;

    public int HitPoints
    {
        get
        {
            return Convert.ToInt32(_hp.text);
        }
        set
        {
            var hp = value;
            _hp.text = hp.ToString();
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public int Attack
    {
        get
        {
            return Convert.ToInt32(_attack.text);
        }
        set
        {
            _attack.text = value.ToString();
        }
    }

    public void SetData(CardData cardData)

    {
        _cardData = cardData;
    }

    private void Start()
    {
        _name = GetComponentInChildren<TextMeshProUGUI>();

        ShowInfoName();
        ShowInfoAttack();
        ShowInfoMana();
        ShowInfoHitPoints();
    }

    private void ShowInfoHitPoints()
    {
        _hp.text = _cardData.HitPoints.ToString();
    }

    private void ShowInfoMana()
    {
        _mana.text = _cardData.Mana.ToString();
    }

    private void ShowInfoAttack()
    {
        _attack.text = _cardData.Attack.ToString();
    }

    private void ShowInfoName()
    {
        if (string.IsNullOrEmpty(_cardData.Name))
        {
            _name.text = transform.GetSiblingIndex().ToString();
        }
        else
        {
            _name.text = _cardData.Name;
        }
    }
}