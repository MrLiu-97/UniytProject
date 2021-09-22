using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class RectTransformDemo : MonoBehaviour
{
    public Vector2 vct2;
    private void Start()
    {
        // 世界坐标
        // 当画布 为 overlay 时，世界坐标（单位：米）等同于屏幕坐标（单位：像素）
        //this.transform.transform;

        // 当前轴心点 相对于 父UI的轴心点 位置（单位：像素） 米 和 像素 是一样的
        //this.transform.localPosition

        //RectTransform rect = GetComponent<RectTransform>();
        RectTransform rect1 = this.transform as RectTransform;

        // 自身轴心点相对于 锚点 的 位置（编译器中显示的 Pos 属性设置）
        //rect1.anchoredPosition3D
        // 获取 / 设置锚点
        //rect1.anchorMin/rect1.anchorMax
        // 获取 UI 宽度(只读的)
        //rect1.rect.width
        // 高度
        //rect1.rect.height

        // 设置物体的宽高 Horizontal 水平的   Vertical垂直的
        rect1.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 250);  // 设置宽度
        rect1.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250);  // 设置度高度

        // 当四个锚点 不分开时，数值可以理解为 UI的宽高
        vct2 = rect1.sizeDelta; // 实际是物体大小 - 锚点间距

        //RectTransformUtility
        // 继承
        //rect1.position
        //rect1.localPosition;
    }

}
