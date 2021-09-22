using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
///
/// </summary>
public class ITweenDemo : MonoBehaviour
{
    public Transform imgTF, btnTF;
    public float moveSpeed = 50;
    public iTween.EaseType easeType_IT;

    //public AnimationCurve curve;  没有ITween 要自己设置
    private void MoveDirection()
    {
        //imgTF.position = Vector3.MoveTowards(imgTF.position, btnTF.position, Time.deltaTime * moveSpeed);
        // iTween.MoveTo ( 游戏对象，移动到那里的位置，移动多少秒)
        //iTween.MoveTo(imgTF.gameObject, btnTF.position, 2); // 简单移动

        iTween.MoveTo(imgTF.gameObject, iTween.Hash(
            "position",btnTF.position,
            "speed",moveSpeed,
            "easetype", easeType_IT   // 移动方式 动画
            ));

    }

    private void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(MoveDirection);
    }
}
