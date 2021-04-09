using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;
using UnityEngine.Video;

public class HuangdiPanel : BasePanel
{
    public Button[] buttons;
    public Button BackButton;
    public PopupPanel popupPanel;
    //public CanvasGroup ButtonsCanvasGroup;
    public VideoPlayer videoPlayer;

    protected override void Start()
    {
        base.Start();
       
    }



    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "buttons").GetComponentsInChildren<Button>();
        BackButton = FindTool.FindChildComponent<Button>(transform, "backButton");
        popupPanel = FindTool.FindChildComponent<PopupPanel>(transform, "PopupPanel");
        videoPlayer = FindTool.FindChildComponent<VideoPlayer>(transform, "Video/RawImage");
        //ButtonsCanvasGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "buttons");


    }

    public override void InitEvent()
    {
        base.InitEvent();
        for (int i = 0; i < buttons.Length; i++)
        {
            InitButton(buttons[i], i);
        }

        BackButton.onClick.AddListener(() => {
            ARState.SwitchPanel(PanelName.WaitPanel);
        });

        videoPlayer.loopPointReached += VideoComplete;
    }

    private void VideoComplete(VideoPlayer source)
    {
        Debug.Log("播放完成");
        videoPlayer.frame = 121;
        videoPlayer.Play();
    }

    private void InitButton(Button button,int num)
    {
        button.onClick.AddListener(() => {
            popupPanel.ShowImage(num);
        });
    }

    public override void Open()
    {
        base.Open();
        videoPlayer.Play();
        //Reset();
    }

    public override void Hide()
    {
        base.Hide();
        videoPlayer.Stop();
        videoPlayer.targetTexture.Release();
    }

    private void Reset()
    {
        //ButtonsCanvasGroup.Hide();
    }
}
