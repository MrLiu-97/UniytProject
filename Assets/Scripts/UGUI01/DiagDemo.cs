using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///
/// </summary>
public class DiagDemo : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    // 2D 场景
    RectTransform rect;
    private void Start()
    {
        rect = this.transform.parent as RectTransform;  // 拿到父物体的变换组件
    }

    private Vector3 offest;
    // 记录按下当前物体时执行
    public void OnPointerDown(PointerEventData eventData)
    {
        // 点的时候 记录鼠标按下点 到 中心的 的偏移量（坐标）
        Vector3 worldPoint;
        
        // 屏幕坐标转世界坐标  eventData.position 屏幕坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out worldPoint);
        //throw new System.NotImplementedException();
        offest = this.transform.position - worldPoint;

        print("转世界："+worldPoint);   // 当前指针的位置 世界坐标   
        print("自身：" + this.transform.position);     // 自身轴心点的坐标位置 中间的小圆圈的位置
        print("offset：" + offest);  // 计算的偏移量
    }

    /// <summary>
    /// 当拖拽时执行
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        // 屏幕坐标转世界坐标  eventData.position 屏幕坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out worldPoint);
        //throw new System.NotImplementedException();
        // 根据偏移量移动 当前 UI；
        this.transform.position = worldPoint + offest;
    }
}
