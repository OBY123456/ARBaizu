using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class HuangdiTask : BaseTask
{
    public HuangdiTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<HuangdiPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<HuangdiPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
