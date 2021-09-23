using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 菜单面板操作 
/// </summary>
public class MenuPanelOption : MonoBehaviour
{
    private Button backGameBtn, restartBtn, rankingListBtn;

    //private PanelManager panelManager;
    /// <summary>
    /// 原位置坐标
    /// </summary>
    private Vector3 mainPanelTF;
    private void Start()
    {
        //panelManager = new PanelManager();
        mainPanelTF = PanelManager.GetPanelPostionByName("PanelMenu");
        // 获取子物体transform
        var backGameTF = this.transform.Find("BackGame");
        var restartTF = this.transform.Find("Restart");
        var rankingListTF = this.transform.Find("Ranking List");
        if (backGameTF != null)
        {
            // button 事件
            backGameBtn = backGameTF.GetComponent<Button>();
            backGameBtn.onClick.AddListener(BackGameFunc);
        }
        if (restartTF != null)
        {
            restartBtn = restartTF.GetComponent<Button>();
            restartBtn.onClick.AddListener(RestartFunc);
        }
        if (rankingListTF != null)
        {
            rankingListBtn = rankingListTF.GetComponent<Button>();
            rankingListBtn.onClick.AddListener(RankingListFunc);
        }
    }

  
    /// <summary>
    /// 返回游戏主界面
    /// </summary>
    private void BackGameFunc()
    {
  
        if (mainPanelTF != null)
        {
            iTween.MoveTo(this.gameObject, mainPanelTF, 1f);
        }

    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    private void RestartFunc()
    {

        if (mainPanelTF != null)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash(
                "position", mainPanelTF,
                "time", 1f,
                "oncomplete", "RestartLoadScene"  // 动画完成时  启用的函数方法
                ));
        }
        
    }
    /// <summary>
    /// 重新加载场景
    /// </summary>
    private void RestartLoadScene()
    {
        SceneManager.LoadScene("Demo_2048");
    }
    public iTween.EaseType easeType;
    /// <summary>
    /// 排行榜面板
    /// </summary>
    private void RankingListFunc()
    {
        var rankingListTF = PanelManager.GetTransformByName("RankingListPanel");
        if (rankingListTF != null)
        {
            iTween.MoveTo(rankingListTF.gameObject, iTween.Hash(
           "position", this.transform.position,
           "time", 1f,
           "easeType", easeType
           ));
        }
    }
}
