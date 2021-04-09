using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using MTFrame.MTEvent;
using System;

namespace MTFrame
{
    public enum PanelName
    {
        WaitPanel,
        ARPanel,
        HuangdiPanel,
        YandiPanel,
        FuxiPanel,
        FuxiModelPanel,
        huangdiModelPanel,
        yandiModelPanel,
    }

    public enum EventType
    {
        /// <summary>
        /// 切换页面
        /// </summary>
        PanelSwitch,
    }
}


public class ARState : BaseState
{
    //注意state一定要在get里面监听事件，没有的话就写成下面样子
    //这里一般用来监听Panel切换
    private Queue<string> GetVs = new Queue<string>();
    public override string[] ListenerMessageID
    {
        get
        {
            return new string[]
            {
                //事件名string类型
                MTFrame.EventType.PanelSwitch.ToString(),
            };
        }
        set { }
    }

    public override void OnListenerMessage(EventParamete parameteData)
    {

        if (parameteData.EvendName == MTFrame.EventType.PanelSwitch.ToString())
        {
            PanelName panelName = parameteData.GetParameter<PanelName>()[0];
            switch (panelName)
            {
                case PanelName.WaitPanel:
                    CurrentTask.ChangeTask(new WaitTask(this));
                    break;
                case PanelName.ARPanel:
                    CurrentTask.ChangeTask(new ARTask(this));
                    break;
                case PanelName.HuangdiPanel:
                    CurrentTask.ChangeTask(new HuangdiTask(this));
                    break;
                case PanelName.YandiPanel:
                    CurrentTask.ChangeTask(new YandiTask(this));
                    break;
                case PanelName.FuxiPanel:
                    CurrentTask.ChangeTask(new FuxiTask(this));
                    break;
                case PanelName.FuxiModelPanel:
                    CurrentTask.ChangeTask(new FuxiModelTask(this));
                    break;
                case PanelName.huangdiModelPanel:
                    CurrentTask.ChangeTask(new huangdiModelTask(this));
                    break;
                case PanelName.yandiModelPanel:
                    CurrentTask.ChangeTask(new yandiModelTask(this));
                    break;
                default:
                    break;
            }
        }
    }

    public override void Enter()
    {
        base.Enter();
        CurrentTask.ChangeTask(new WaitTask(this));
    }


    /// <summary>
    /// 切换UI Panel
    /// </summary>
    /// <param name="panelName"></param>
    public static void SwitchPanel(PanelName panelName)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(panelName);
        EventManager.TriggerEvent(GenericEventEnumType.Message, MTFrame.EventType.PanelSwitch.ToString(), eventParamete);
    }

}
