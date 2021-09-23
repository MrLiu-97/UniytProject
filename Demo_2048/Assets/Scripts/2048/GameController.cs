using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Console_2048;
using MoveDirection = Console_2048.MoveDirection; // 用的 MoveDirection 全都是 此类里面的
/// <summary>
///
/// </summary>
public class GameController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private NumberSprite[,] numberActionArray;
    private GameCore core;
    private void Start()
    {
        core = new GameCore();
        numberActionArray = new NumberSprite[4, 4];

        Init();
        GenerateNewNumber();
        GenerateNewNumber();
    }

    private void Init()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                CreateSprite(i, j);
            }
        }
    }

    /// <summary>
    /// 创建一个精灵
    /// </summary>
    private void CreateSprite(int i, int j)
    {
        GameObject gameObject = new GameObject(i.ToString() + j.ToString());
        gameObject.AddComponent<Image>();

        // 创建脚本对象 附加到当前物体
        NumberSprite numberSprite = gameObject.AddComponent<NumberSprite>();
        // 将当前脚本对象的引用 保存到二维数组当中
        numberActionArray[i, j] = numberSprite;
        // 读取图片 资源 设置到 Image 中
        numberSprite.SetImage(0);

        // 设置父物体 到当前物体 Scale 默认为 1  以前版本 需要加 false  不加 false 创建的 GameObject 会有问题  里面的 Scale 会发生变化
        gameObject.transform.SetParent(this.transform, false);
        // 如果不指定 父物体的话  当前创建的物体 会存放在 Hierarchy 面板根目录

        // 也可以 用预制件去创建
        //Instantiate()
    }

    // 所有的精灵行为放在一个类  
    // 所有要加载的 图片 必须放在 Resources 文件夹里
    // Resources.LoadAll<Sprite>("stringName");  如果里面包含多个精灵 就需要用 LoadAll 方法  单个 就用 Load 方法

    public Text getScoreText;
    public Text getMaxScoreText;
    private void Update()
    {
        if (core.IsChangeMap)
        {
            // 更新界面
            UpdateMap();
            // 产生新的数字
            GenerateNewNumber();
            //判断游戏是否结束
            getScoreText.text = string.Format("分数<color=white>\n" + GameCore.scoreCount + "</color>");
            getMaxScoreText.text = string.Format("最高分<color=white>\n" + GameCore.scoreCount + "</color>");

            core.IsChangeMap = false;
        }
    }

    private void UpdateMap()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                numberActionArray[i, j].SetImage(core.Map[i, j]);
            }
        }
    }
    /// <summary>
    /// 产生新数字
    /// </summary>
    public void GenerateNewNumber()
    {
        Location? loc;
        int? number;
        core.CreatNewRandomNumber(out loc, out number);

        numberActionArray[loc.Value.RowIndex, loc.Value.ColIndex].SetImage(number.Value);

        numberActionArray[loc.Value.RowIndex, loc.Value.ColIndex].CreatEffect();
    }

    // 记录指针的屏幕坐标
    private Vector2 startPoint;
    private bool isDown;
    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
        //throw new System.NotImplementedException();
        isDown = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDown)
        {
            return;
        }
        // 从开始坐标的方向（startPoint） 指向 鼠标指针的方向（eventData.position） 移动
        Vector3 offset = eventData.position - startPoint;
        float x = Mathf.Abs(offset.x);  // 取绝对值
        float y = Mathf.Abs(offset.y);
        MoveDirection? dir = null;
        // 水平移动 并且 X 或 Y 移动到 一定的长度 才执行
        if (x > y && x >= 100)
        {
            dir = offset.x > 0 ? MoveDirection.Right : MoveDirection.Left;
        }
        if (x < y && y >= 100)
        {
            dir = offset.y > 0 ? MoveDirection.Up : MoveDirection.Down;
        }
        if (dir != null)
        {
            // 移动完 设置 为false  避免下一帧继续执行
            core.Move(dir.Value);
            isDown = false;
        }

        //throw new System.NotImplementedException();
    }
}
