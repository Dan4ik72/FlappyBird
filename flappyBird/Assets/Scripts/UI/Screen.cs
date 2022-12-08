using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected Button _button;

    protected CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public virtual void Open()
    {
        _canvasGroup.alpha = 1;
        _button.interactable = true;
    }

    public virtual void Close()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
    }
}
