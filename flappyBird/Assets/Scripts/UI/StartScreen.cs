using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    public event UnityAction OnClickPlayButton;

    protected override void OnButtonClick()
    {
        OnClickPlayButton?.Invoke();
    }
}
