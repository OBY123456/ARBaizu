using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ModelControl : MonoBehaviour
{
    public static ModelControl Instance;
    public GameObject[] ModelGroupRoot;
    //顺序是炎帝、黄帝、伏羲
    public GameObject[] ModelGroup;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    public GameObject CurrentModel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HideModel();
    }


    public void ShowModelRoot(int i,PanelName _panelName)
    {
        HideModel();

        ModelGroupRoot[i].gameObject.SetActive(true);

        PlayBgm(_panelName);
        //StartCoroutine("TuanToPanle");
    }



    private void PlayBgm(PanelName _panelName)
    {
        switch (_panelName)
        {

            case PanelName.YandiPanel:
                audioSource.clip = audioClips[1];
                audioSource.Play();
                StartCoroutine("AudioPlay_Yandi");
                break;

            case PanelName.HuangdiPanel:
                audioSource.clip = audioClips[0];
                audioSource.Play();
                StartCoroutine("AudioPlay_Huangdi");
                break;

            case PanelName.FuxiPanel:
                audioSource.clip = audioClips[2];
                audioSource.Play();
                StartCoroutine("AudioPlay_FuXi");
                break;

            default:
                break;
        }
    }

    private IEnumerator AudioPlay_Yandi()
    {
        ShowModel(ModelGroup[0], 0);
        yield return new WaitForSeconds(6);
        ShowModel(ModelGroup[0], 1);
        yield return new WaitForSeconds(7);
        ShowModel(ModelGroup[0], 2);

        yield return new WaitForSeconds(4);

        ShowModel(ModelGroup[0], 3);
        yield return new WaitForSeconds(4);

        HideModel();
        ARState.SwitchPanel(PanelName.YandiPanel);

    }

    private IEnumerator AudioPlay_Huangdi()
    {
        ShowModel(ModelGroup[1], 0);
        yield return new WaitForSeconds(4);

        ShowModel(ModelGroup[1], 1);

        yield return new WaitForSeconds(3);

        ShowModel(ModelGroup[1], 2);

        yield return new WaitForSeconds(2);

        ShowModel(ModelGroup[1], 3);

        yield return new WaitForSeconds(6);

        ShowModel(ModelGroup[1], 4);

        yield return new WaitForSeconds(6);

        HideModel();
        ARState.SwitchPanel(PanelName.HuangdiPanel);

    }

    private IEnumerator AudioPlay_FuXi()
    {
        ShowModel(ModelGroup[2], 0);
        yield return new WaitForSeconds(6);

        ShowModel(ModelGroup[2], 1);

        yield return new WaitForSeconds(7);

        ShowModel(ModelGroup[2], 2);

        yield return new WaitForSeconds(6);

        ShowModel(ModelGroup[2], 3);

        yield return new WaitForSeconds(3);

        ShowModel(ModelGroup[2], 4);

        yield return new WaitForSeconds(3);


        HideModel();
        ARState.SwitchPanel(PanelName.FuxiPanel);
    }

    public void HideModel()
    {
        foreach (GameObject item in ModelGroupRoot)
        {
            item.gameObject.SetActive(false);
        }

        if(CurrentModel!=null)
        {
            CurrentModel.transform.localEulerAngles = new Vector3(-90, -90, -90);
            CurrentModel.SetActive(false);
            CurrentModel = null;
            audioSource.Stop();
            StopAllCoroutines();
        }

        
    }

    private void ShowModel(GameObject obj,int number)
    {
        if(number >= obj.transform.childCount)
        {
            return;
        }

        if(number == 0)
        {
            obj.transform.GetChild(0).gameObject.SetActive(true);
            CurrentModel = obj.transform.GetChild(0).gameObject;
            return;
        }

        if(number > 0)
        {
            obj.transform.GetChild(number - 1).gameObject.SetActive(false);
            obj.transform.GetChild(number - 1).localEulerAngles = new Vector3(-90, -90, -90);
            obj.transform.GetChild(number).gameObject.SetActive(true);
            CurrentModel = obj.transform.GetChild(number).gameObject;
            
        }
    }

    private void Update()
    {
        if(CurrentModel!=null)
        {
            CurrentModel.transform.Rotate(Vector3.down*0.1f);
        }
    }
}
