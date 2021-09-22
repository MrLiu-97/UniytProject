using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class EventDemo : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public void Fun1()
    {
        Debug.Log("Hello：1");
    }

    public void Fun2(string name)
    {
        Debug.Log("Hello：" + name);
    }

    private void Start()
    {
        //Button btn = this.transform.Find("Button").GetComponent<Button>();
        //btn.onClick.AddListener(Fun1);

        //InputField btn1 = this.transform.Find("InputField").GetComponent<InputField>();
        ////btn1.onValueChanged.AddListener(Fun2);
        //btn1.onEndEdit.AddListener(Fun2);
    }

    /// <summary>
    /// 当光标单击时执行
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            print("you 双击了" + eventData.clickCount + "下");
        }
    }
    /// <summary>
    /// 当拖拽时执行
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //eventData.position :光标位置
        // 仅仅 适用于 画布的 Overlay 模式  camera 模式 失效
        //this.transform.position = eventData.position;


        // 通用拖拽
        // 将屏幕坐标转换为物体的世界坐标
        RectTransform rect = this.transform.parent as RectTransform; //父物体的变换组件
        // 此方法 返回世界坐标
        // (父物体的变换组件，屏幕坐标，摄像机，out 世界坐标)
        Vector3 worldPos;  // 回世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect,eventData.position,eventData.pressEventCamera,out worldPos);
        this.transform.position = worldPos;

        //throw new System.NotImplementedException();
    }


}
