using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction OnClickGameOverButton;

    protected override void OnButtonClick()
    {
        OnClickGameOverButton?.Invoke();
    }
}
