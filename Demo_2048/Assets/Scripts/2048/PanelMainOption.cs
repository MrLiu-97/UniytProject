using Console_2048;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class PanelMainOption : MonoBehaviour
{
    private Button menuBtn, quitGameBtn, gameOverBtn;

    //private PanelManager panelManager;
    private void Start()
    {
        //core = new GameCore();

        //panelManager = new PanelManager();
        // 保存初始位置
        //gameOverPanelPostion = gameOverPanelTF.position;
        //menuPanelPostion = menuPanelTF.position;

        // 获取子物体transform
        var menuTF = this.transform.Find("Menu");
        var quitGameTF = this.transform.Find("QuitGame");
        var gameOverTF = this.transform.Find("GameOver");
        if (menuTF != null)
        {
            // button 事件
            menuBtn = menuTF.GetComponent<Button>();
            menuBtn.onClick.AddListener(MenuFunc);
        }
        if (quitGameTF != null)
        {
            quitGameBtn = quitGameTF.GetComponent<Button>();
            quitGameBtn.onClick.AddListener(QuitGameFunc);
        }
        if (gameOverTF != null)
        {
            gameOverBtn = gameOverTF.GetComponent<Button>();
            gameOverBtn.onClick.AddListener(GameOverFunc);
        }

    }

    private void MenuFunc()
    {
        var menuTf = PanelManager.GetTransformByName("PanelMenu");
       
        if (menuTf != null)
        {
            iTween.MoveTo(menuTf.gameObject, this.transform.position, 1f);
        }

    }

    //private GameCore core;
    public Text score;
    public iTween.EaseType easeType;
    public float moveSpeed = 800;
    private void GameOverFunc()
    {
        score.text = string.Format("分数\n<b><color=white>" + GameCore.scoreCount + "</color></b>");
        var gameOverTF = PanelManager.GetTransformByName("GameOverPanel");
        if (gameOverTF != null)
        {
            iTween.MoveTo(gameOverTF.gameObject, iTween.Hash(
           "position", this.transform.position,
           "speed", moveSpeed,
           "easeType", easeType
           ));
        }
        
        //StartCoroutine(BackSeconds());
        //print("GameOverFunc");
    }
    //private IEnumerator BackSeconds()
    //{
    //    yield return new WaitForSeconds(10);
    //    gameOverPanelTF.position = gameOverPanelPostion;
    //    print(111);
    //}
    private void QuitGameFunc()
    {
        //iTween.MoveTo(gameOverPanelTF.gameObject, iTween.Hash(
        //    "position", this.transform.position,
        //    "speed", moveSpeed,
        //    "easeType", easeType
        //    ));
        //print("QuitGameFunc");
    }
}
