using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class ARPanel : BasePanel
{
    public Button button_yandi, button_huangdi, button_fuxi;

    private float BackTime = 5;
    private float Back_Time;
    private bool IsBack;

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
            ARState.SwitchPanel(PanelName.YandiPanel);
        });

        button_huangdi.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.HuangdiPanel);
        });

        button_fuxi.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.FuxiPanel);
        });
    }

    public override void Open()
    {
        base.Open();
        IsBack = true;
        Back_Time = BackTime;
    }

    private void Update()
    {
        if (Back_Time > 0 && IsBack)
        {
            Back_Time -= Time.deltaTime;
            //LogMsg.Instance.Log(Back_Time.ToString());
            if (Back_Time <= 0)
            {
                IsBack = false;
                ARState.SwitchPanel(PanelName.WaitPanel);
            }

            if (Input.GetMouseButton(0))
            {
                Back_Time = BackTime;
            }
        }
    }


}
