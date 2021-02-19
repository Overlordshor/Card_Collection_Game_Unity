using UnityEngine;

[CreateAssetMenu(fileName = "NameCardData", menuName = "CardData", order = 51)]
public class CardData : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private int _attack, _hp, _mana;

    public string Name { get => _name; private set => _name = value; }
    public int Attack { get => _attack; private set => _attack = value; }
    public int HitPoints { get => _hp; private set => _hp = value; }
    public int Mana { get => _mana; private set => _mana = value; }
}