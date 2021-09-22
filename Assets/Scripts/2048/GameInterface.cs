using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class GameInterface : MonoBehaviour
{
    public GameObject obj;
    private void Start()
    {
        Button btnMenu = this.GetComponent<Button>();
        btnMenu.onClick.AddListener(MenuFunc);
    }

    private void MenuFunc()
    {
        print(1);
        iTween.MoveTo(this.gameObject, obj.transform.position, 1f);
    }

}
