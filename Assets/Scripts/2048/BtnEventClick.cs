using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class BtnEventClick : MonoBehaviour
{
    public RectTransform menuPanel, mainPanel;
    //RectTransform rect1 = menuPanel as RectTransform;
    //RectTransform rect2 = mainPanel as RectTransform;
    private void Start()
    {
        pos = menuPanel.position;

        Button btnMenu = this.GetComponent<Button>();

        switch (btnMenu.name)
        {
            case "Menu": btnMenu.onClick.AddListener(MenuFunc); break;
            case "QuitGame": break;
            case "GameOver": break;
            case "BackGame": btnMenu.onClick.AddListener(BackGameFunc); break;
            case "Restart": break;
            case "Ranking List": break;
            default:
                break;
        }

    }
    public Vector3 pos;
    private void MenuFunc()
    {
        iTween.MoveTo(menuPanel.gameObject, mainPanel.position, 1f);
    }

    private void BackGameFunc()
    {

        iTween.MoveTo(menuPanel.gameObject, pos, 1f);
    }
}
