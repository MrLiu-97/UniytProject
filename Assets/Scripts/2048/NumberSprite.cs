using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class NumberSprite : MonoBehaviour
{
    private UnityEngine.UI.Image img;

    // 目测给了组件不会启用,调用方法 的时候 直接执行 方法 然后 才start
    private void Awake()  // Start()  由于 先执行了 SetImage 方法 后 才 Start() 所以 为空 要改为 Awake
    {
        img = GetComponent<UnityEngine.UI.Image>();
        print(img);
    }

    // 设置图片形状 根据 数字
    public void SetImage(int number)
    {
        print(number);
        img.sprite = ResourceManager.LoadSprite(number);
    }

    /// <summary>
    /// 生成效果
    /// </summary>
    public void CreatEffect()
    {
        //this.transform.localScale = Vector3.zero;
        // 由 （小） Vector3.zero ===》 Vector3.one （大） 
        iTween.ScaleFrom(gameObject, Vector3.zero, 0.3f);
    }
}
