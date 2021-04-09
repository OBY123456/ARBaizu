using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ModelControl : MonoBehaviour
{
    private PanelName panelName;
    public static ModelControl Instance;
    public GameObject[] ModelGroup;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HideModel();
    }

    public void ShowModel(int i,PanelName _panelName)
    {
        HideModel();

        ModelGroup[i].gameObject.SetActive(true);

        panelName = _panelName;
        StartCoroutine("TuanToPanle");
    }

    public void HideModel()
    {
        foreach (GameObject item in ModelGroup)
        {
            item.gameObject.SetActive(false);
        }
    }

    private IEnumerator TuanToPanle()
    {
        yield return new WaitForSeconds(5.0f);
        HideModel();
        ARState.SwitchPanel(panelName);
    }
}
