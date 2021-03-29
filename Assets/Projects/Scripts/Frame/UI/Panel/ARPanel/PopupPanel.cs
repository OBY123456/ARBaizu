using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

/// <summary>
/// 弹窗页面
/// </summary>
public class PopupPanel : BasePanel
{
    public Sprite[] sprites;
    public Image image;
    public Button CloseButton;

    public override void InitFind()
    {
        base.InitFind();
        image = FindTool.FindChildComponent<Image>(transform, "Image");
        CloseButton = FindTool.FindChildComponent<Button>(transform, "CloseButton");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        CloseButton.onClick.AddListener(() => {
            Hide();
        });
    }

    public void ShowImage(int num)
    {
        if(num >= sprites.Length)
        {
            LogMsg.Instance.Log("超出数组范围！！！");
        }
        else
        {
            image.sprite = sprites[num];
            Open();
        }
    }
}
