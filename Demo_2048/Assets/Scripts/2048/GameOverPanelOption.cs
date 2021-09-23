using Console_2048;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// GameOver面板操作
/// </summary>
public class GameOverPanelOption : MonoBehaviour
{


    private void Start()
    {

        var restartTF = transform.Find("Restart");
        if (restartTF != null)
        {
            restartTF.GetComponent<Button>().onClick.AddListener(RestartGame);
        }
    }

    public float moveSpeed = 800;
    public iTween.EaseType easeType;
    /// <summary>
    /// 重新开始游戏
    /// </summary>
    private void RestartGame()
    {
        var gameOverTF = PanelManager.GetPanelPostionByName("GameOverPanel");
        if (gameOverTF != null)
        {
            iTween.MoveTo(gameObject, iTween.Hash(
           "position", gameOverTF,
           "speed", moveSpeed,
           "easeType", easeType,
           "oncomplete", "RestartLoadScene"
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

}
