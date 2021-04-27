using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MTFrame;

public class PlaySprite : BasePanel {

    private Image ImageSource;
    private int mCurFrame = 0;
    private float mDelta = 0;
    [Header("帧率")]
    public float FPS = 30;
    Sprite[] SpriteFrames;
    [Header("是否播放")]
    public bool IsPlaying = false;
    [Header("序列帧路径")]
    public string Path;
    [Header("循环帧节点")]
    public int LoopIndex;
    
    public int FrameCount
    {
        get
        {
            return SpriteFrames.Length;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        ImageSource = GetComponent<Image>();
        SpriteFrames = Resources.LoadAll<Sprite>(Path);
        SetSprite(0);
    }

    public override void Open()
    {
        //base.Open();
        IsPlaying = true;
    }

    public override void Hide()
    {
        //base.Hide();
        //初始化序列帧初始图片
        IsPlaying = false;
        SetSprite(0);
        mDelta = 0;
        mCurFrame = 0;
        
    }

    private void SetSprite(int idx)
    {
        ImageSource.sprite = SpriteFrames[idx];
    }
    
    void Update()
    {
        if (!IsPlaying || 0 == FrameCount)
        {
            return;
        }
        else
        {
            mDelta += Time.deltaTime;
            if (mDelta > 1 / FPS)
            {
                mDelta = 0;

                mCurFrame++;
                //循环播放部分
                if (mCurFrame >= FrameCount)
                {
                    mCurFrame = LoopIndex;
                }

                SetSprite(mCurFrame);

            }
        }
    }
}