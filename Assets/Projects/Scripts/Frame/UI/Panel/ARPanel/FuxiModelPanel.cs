using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using System;
using UnityEngine.Video;

public class FuxiModelPanel : BasePanel
{
    public Button SkipButton;
    //public MediaPlayer mediaPlayer;
    public PanelName panel;
    //public string VideoPath;
    public VideoPlayer videoPlayer;
    public Sprite sprite;

    public override void InitFind()
    {
        base.InitFind();
        SkipButton = FindTool.FindChildComponent<Button>(transform, "SkipButton");
        //mediaPlayer = FindTool.FindChildComponent<MediaPlayer>(transform, "Video");
        videoPlayer = FindTool.FindChildComponent<VideoPlayer>(transform, "Video");

        sprite = Resources.Load<Sprite>("Sprite/FUXI_1");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        SkipButton.onClick.AddListener(() => {

            ARState.SwitchPanel(panel);
        });

        //mediaPlayer.Events.AddListener(Complete);
        videoPlayer.loopPointReached += Complete;
    }

    private void Complete(VideoPlayer source)
    {
        ARState.SwitchPanel(panel);
    }

    //private void Complete(MediaPlayer arg0, MediaPlayerEvent.EventType arg1, ErrorCode arg2)
    //{
    //    switch (arg1)
    //    {

    //        case MediaPlayerEvent.EventType.FinishedPlaying:
    //            ARState.SwitchPanel(panel);
    //            break;

    //        default:
    //            break;
    //    }
    //}

    public override void Open()
    {
        base.Open();
        //mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, VideoPath);
        Graphics.Blit((Texture2D)sprite.texture, videoPlayer.targetTexture);
        videoPlayer.Play();
    }

    public override void Hide()
    {
        base.Hide();
        //mediaPlayer.Stop();
        videoPlayer.Stop();
        Graphics.Blit((Texture2D)sprite.texture, videoPlayer.targetTexture);
        ModelControl.Instance.HideModel();
    }
}
