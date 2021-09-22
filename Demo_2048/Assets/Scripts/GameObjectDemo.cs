using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class GameObjectDemo : MonoBehaviour
{
    private void OnGUI()
    {

        // 在场景中物体激活状态（物体实际激活状态）
        //this.gameObject.activeInHierarchy

        // 物体自身激活状态（物体在 Inspector 面板中的状态)
        //this.gameObject.activeSelf

        // 设置物体启用/禁用
        //this.gameObject.SetActive();

        if (GUILayout.Button("添加光源"))
        {
            // 创建物体
            GameObject gameObject = new GameObject();
            // 添加组件
            Light light = gameObject.AddComponent<Light>();
            light.color = Color.red;
            light.type = LightType.Spot;

            // 在场景中根据名称查找物体(慎用)
            GameObject.Find("游戏对象名称");

            // 获取所有使用该标签的物体
            GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");

            // 获取使用该标签的物体(单个)
            GameObject playerGo = GameObject.FindWithTag("Player");


            // 根据类型查找 对象
            Object.FindObjectOfType<MeshRenderer>();
            FindObjectsOfType<MeshRenderer>();

            // 销毁对象
            //Object.Destroy(playerGo);
        }

    }

}
