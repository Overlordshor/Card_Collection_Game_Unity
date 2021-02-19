using UnityEngine;

public class AnimationChangeValue : MonoBehaviour
{
    [SerializeField] private GameObject _removerHealth, _removerAttack;
    private float _lenght;

    private Animation _animation;

    public float Length { get => _lenght; set => _lenght = value; }

    public void PlayAnimation(ValueType valueType, Transform card)
    {
        GameObject remover = null;
        switch (valueType)
        {
            case ValueType.Attack:
                remover = Instantiate(_removerAttack, card);

                break;

            case ValueType.HitPoints:
                remover = Instantiate(_removerHealth, card);
                break;

            default:
                Debug.Log("No animation for this value type");
                break;
        }

        _animation = remover.GetComponent<Animation>();
        _lenght = _animation.clip.length;

        Destroy(remover, _lenght);
    }
}