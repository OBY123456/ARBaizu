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
    public VideoPlayer videoPlayer, videoPlayer_loop;
    public CanvasGroup videoCanvas, videoloopCanvas;

    protected override void Start()
    {
        base.Start();
        Reset();
    }



    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "buttons").GetComponentsInChildren<Button>();
        BackButton = FindTool.FindChildComponent<Button>(transform, "backButton");
        popupPanel = FindTool.FindChildComponent<PopupPanel>(transform, "PopupPanel");
        videoPlayer = FindTool.FindChildComponent<VideoPlayer>(transform, "Video/RawImage");
        videoPlayer_loop = FindTool.FindChildComponent<VideoPlayer>(transform, "Video (1)/RawImage");
        videoCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "Video");
        videoloopCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "Video (1)");


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
        videoPlayer.targetTexture.Release();
        videoCanvas.alpha = 0;
        videoloopCanvas.alpha = 1;
        videoPlayer_loop.Play();
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
        videoPlayer.targetTexture.Release();
        videoPlayer.Play();
    }

    public override void Hide()
    {
        base.Hide();
        videoPlayer.Stop();
        videoPlayer_loop.Stop();

        Reset();
    }

    private void Reset()
    {
        VideoRelease();

        videoCanvas.alpha = 1;
        videoloopCanvas.alpha = 0;
    }

    private void VideoRelease()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer_loop.targetTexture.Release();
    }
}
