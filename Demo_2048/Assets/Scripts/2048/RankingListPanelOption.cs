using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 排行榜面板操作
/// </summary>
public class RankingListPanelOption : MonoBehaviour
{
    //PanelManager PanelManager;
    private void Start()
    {
        //PanelManager = new PanelManager();
        var backTF = this.transform.Find("Back");
        if (backTF != null)
        {
            Button btnBack = backTF.GetComponent<Button>();
            btnBack.onClick.AddListener(BackFunc);
        }

    }

    public iTween.EaseType easeType;
    private void BackFunc()
    {
        var rankingListTF = PanelManager.GetPanelPostionByName("RankingListPanel");
        if (rankingListTF != null)
        {
            iTween.MoveTo(gameObject, iTween.Hash(
           "position", rankingListTF,
           "time", 0.5f,
           "easeType", easeType
           ));
        }
    }
}
