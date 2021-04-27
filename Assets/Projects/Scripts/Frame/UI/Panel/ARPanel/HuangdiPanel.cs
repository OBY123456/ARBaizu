using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using DG.Tweening;

public class HuangdiPanel : BasePanel
{
    public Button[] buttons;
    public Button BackButton;
    public PopupPanel popupPanel;

    public VideoPlayer videoPlayerIn, videoPlayerLoop;
    public CanvasGroup canvasGroupIn, canvasGroupLoop;
    public Sprite sprite;


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

        videoPlayerIn = FindTool.FindChildComponent<VideoPlayer>(transform, "Anima");
        videoPlayerLoop = FindTool.FindChildComponent<VideoPlayer>(transform, "Anima (1)");
        canvasGroupIn = FindTool.FindChildComponent<CanvasGroup>(transform, "Anima");
        canvasGroupLoop = FindTool.FindChildComponent<CanvasGroup>(transform, "Anima (1)");

        sprite = Resources.Load<Sprite>("Sprite/FUXI_1");

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

        videoPlayerIn.loopPointReached += Complete;
    }

    private void Complete(VideoPlayer source)
    {
        canvasGroupIn.alpha = 0;
        videoPlayerLoop.Play();
        canvasGroupLoop.alpha = 1;
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
        videoPlayerIn.Play();
        videoPlayerLoop.Play();
        videoPlayerLoop.Pause();
        canvasGroupIn.DOFade(1, 0.5f);
    }

    public override void Hide()
    {
        base.Hide();

        
        videoPlayerIn.Stop();
        videoPlayerLoop.Stop();
        Reset();
    }

    private void Reset()
    {
        canvasGroupIn.alpha = 0;
        canvasGroupLoop.alpha = 0;


        Graphics.Blit((Texture2D)sprite.texture, videoPlayerIn.targetTexture);
        Graphics.Blit((Texture2D)sprite.texture, videoPlayerLoop.targetTexture);
    }

}
