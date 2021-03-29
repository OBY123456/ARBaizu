using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class ARPanel : BasePanel
{
    Button button_yandi, button_huangdi, button_fuxi;
    public override void InitFind()
    {
        base.InitFind();
        button_yandi = FindTool.FindChildComponent<Button>(transform, "yandi/Button");
        button_huangdi = FindTool.FindChildComponent<Button>(transform, "huangdi/Button");
        button_fuxi = FindTool.FindChildComponent<Button>(transform, "fuxi/Button");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        button_yandi.onClick.AddListener(() => {
            LogMsg.Instance.Log("111");
        });

        button_huangdi.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.HuangdiPanel);
        });

        button_fuxi.onClick.AddListener(() => {
            LogMsg.Instance.Log("333");
        });
    }

}
