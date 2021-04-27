using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class ARPanel : BasePanel
{
    public Button button_yandi, button_huangdi, button_fuxi;

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
            ARState.SwitchPanel(PanelName.yandiModelPanel);
            ModelControl.Instance.ShowModelRoot(0, PanelName.YandiPanel);
        });

        button_huangdi.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.huangdiModelPanel);
            ModelControl.Instance.ShowModelRoot(1, PanelName.HuangdiPanel);
        });

        button_fuxi.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.FuxiModelPanel);
            ModelControl.Instance.ShowModelRoot(2, PanelName.FuxiPanel);
        });
    }

    public override void Open()
    {
        base.Open();

    }




}
