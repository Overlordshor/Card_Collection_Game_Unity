using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private FieldType _type;

    public FieldType Type { get => _type; private set => _type = value; }
}

public enum FieldType
{
    Hand,
    Game
}