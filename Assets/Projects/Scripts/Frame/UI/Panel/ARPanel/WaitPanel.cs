using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;

public class WaitPanel : BasePanel
{

    Button button;

    public override void InitFind()
    {
        base.InitFind();
        button = FindTool.FindChildComponent<Button>(transform, "Button");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        button.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.ARPanel);
        });
    }

    public override void Open()
    {
        base.Open();
    }



    public override void Hide()
    {
        base.Hide();

    }

}
