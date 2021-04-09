using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;

public class WaitPanel : BasePanel
{
    public CanvasGroup canvasGroup;
    Button button;
    string data1 = "2021/5/13 00:00:00";

    protected override void Awake()
    {
        base.Awake();
        canvasGroup.Hide();
    }

    protected override void Start()
    {
        base.Start();
        CompanyDate(System.DateTime.Now.ToString(), data1);
    }

    public override void InitFind()
    {
        base.InitFind();
        button = FindTool.FindChildComponent<Button>(transform, "Button");
        canvasGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "ClosePanel");
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

    public void CompanyDate(string dateStr1, string dateStr2)
    {
        //将日期字符串转换为日期对象
        DateTime t1 = Convert.ToDateTime(dateStr1);
        DateTime t2 = Convert.ToDateTime(dateStr2);
        //通过DateTIme.Compare()进行比较（）
        int num = DateTime.Compare(t1, t2);

        //t1> t2
        if (num > 0)
        {
            canvasGroup.Open();
            Debug.Log("t1:(" + dateStr1 + ")大于" + "t2(" + dateStr2 + ")");
        }

        //t1< t2
        if (num < 0)
        {
            Debug.Log("t1:(" + dateStr1 + ")小于" + "t2(" + dateStr2 + ")");
        }
    }

}
