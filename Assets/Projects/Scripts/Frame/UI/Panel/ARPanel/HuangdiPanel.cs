using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using System;

public class HuangdiPanel : BasePanel
{
    public Button[] buttons;
    public Button BackButton;
    public PopupPanel popupPanel;
    public CanvasGroup ButtonsCanvasGroup,MediaCanvasGroup;
    public MediaPlayer mediaPlayer;
    public string VideoPath;

    protected override void Start()
    {
        base.Start();
        mediaPlayer.Events.AddListener(OnConplete);
    }

    private void OnConplete(MediaPlayer arg0, MediaPlayerEvent.EventType arg1, ErrorCode arg2)
    {
        switch (arg1)
        {
            case MediaPlayerEvent.EventType.FinishedPlaying:
                MediaCanvasGroup.Hide();
                ButtonsCanvasGroup.Open(0.5f);            
                break;
            default:
                break;
        }
    }

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "buttons").GetComponentsInChildren<Button>();
        BackButton = FindTool.FindChildComponent<Button>(transform, "backButton");
        popupPanel = FindTool.FindChildComponent<PopupPanel>(transform, "PopupPanel");
        ButtonsCanvasGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "buttons");
        MediaCanvasGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "VideoGroup");
        mediaPlayer = FindTool.FindChildComponent<MediaPlayer>(transform, "VideoGroup/VideoPlayer");
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
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, VideoPath, true);
        Reset();
    }

    public override void Hide()
    {
        base.Hide();
        mediaPlayer.Stop();
    }

    private void Reset()
    {
        ButtonsCanvasGroup.Hide();
        MediaCanvasGroup.Open();
    }
}
