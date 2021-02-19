using UnityEngine;
using UnityEngine.EventSystems;

public partial class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera _mainCamera;
    private Vector3 _offset;
    private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _temporaryCardPref;
    private GameObject _temporaryCard;
    private bool _isDraggable;
    public Transform DefaultParent { get; set; }
    public Transform DefaultTempCardParent { get; set; }

    private void Start()
    {
        _mainCamera = Camera.main;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private int GetNewIndex()
    {
        int newIndex = DefaultTempCardParent.childCount;
        foreach (Transform card in DefaultTempCardParent)
        {
            if (transform.position.x < card.position.x)
            {
                newIndex = card.GetSiblingIndex();

                if (_temporaryCard.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }

                return newIndex;
            }
        }

        return newIndex;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = DefaultTempCardParent = transform.parent;

        _isDraggable = DefaultParent.GetComponent<Field>().Type == FieldType.Hand;
        if (!_isDraggable)
        {
            return;
        }

        _temporaryCard = Instantiate(_temporaryCardPref, DefaultParent);
        _temporaryCard.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(DefaultParent.parent);

        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDraggable)
        {
            return;
        }
        var newPosition = _mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPosition + _offset;

        if (_temporaryCard.transform.parent != DefaultTempCardParent)
        {
            _temporaryCard.transform.SetParent(DefaultTempCardParent);
        }

        _temporaryCard.transform.SetSiblingIndex(GetNewIndex());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDraggable)
        {
            return;
        }
        transform.SetParent(DefaultParent);
        transform.SetSiblingIndex(_temporaryCard.transform.GetSiblingIndex());

        _canvasGroup.blocksRaycasts = true;

        Destroy(_temporaryCard);
    }
}