using TMPro;
using UnityEngine;

public class Remover : MonoBehaviour
{
    private void Start()
    {
        var value = FindObjectOfType<ValueChanger>().RandomChangeValue;
        GetComponentInChildren<TextMeshProUGUI>().text = value.ToString();
    }
}