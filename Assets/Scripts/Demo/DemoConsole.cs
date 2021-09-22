using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class DemoConsole : MonoBehaviour
{
    // 查找血量最低的敌人

    private void OnGUI()
    {
        if (GUILayout.Button("findEnemy"))
        {
            Enemy[] Enemy = FindObjectsOfType<Enemy>();
            Enemy minEnemy = FindEnemyMinDistance(Enemy);
            minEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
        }
            if (GUILayout.Button("getChild"))
        {
            var childTF = GetChild(this.transform, "Cube (5)");
            childTF.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("play"))
        {
            // 我不知道你在哪 但我就是要找到所有的 Enemy
            // 根据类型查找 对象
            Enemy[] games = Object.FindObjectsOfType<Enemy>();
            // 找到之后将材质设置为 红色
            GetEnemyByMinHP(games).GetComponent<MeshRenderer>().material.color = Color.red;
            //print(GetEnemyByMinHP(games));


            foreach (Enemy item in games)
            {
                if (item.HP < 80)
                {
                    print(item.name);
                }
            }

            Enemy[] enemies = this.GetComponents<Enemy>();
            foreach (Enemy item in enemies)
            {
                if (item.HP < 80)
                {
                    print(item.name);
                }
            }


        }
    }

    public Enemy GetEnemyByMinHP(Enemy[] enemies)
    {
        Enemy enemy = enemies[0];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemy.HP > enemies[i].HP)
            {
                enemy = enemies[i];
            }
        }
        return enemy;
    }
    // 练习  在层级未知情况下 查找子物体
    // 递归
    public static Transform GetChild(Transform parentTF, string childName)
    {
        Transform transform = parentTF.Find(childName);

        if (transform != null)
        {
            return transform;
        }
        int count = parentTF.childCount;
        print(count);
        for (int i = 0; i < count; i++)
        {
            // 将问题交给子物体
            transform = GetChild(parentTF.GetChild(i), childName);
            if (transform != null)
            {
                return transform;
            }
        }

        return null;
    }

    // 查找距离最近的敌人
    public Enemy FindEnemyMinDistance(Enemy[] allEnemy)
    {
        // 假设第一个元素就是距离最近的
        Enemy min = allEnemy[0];
        // minDistance 中存储假设距离最近的敌人
        float minDistance = Vector3.Distance(this.transform.position, min.transform.position);
        for (int i = 1; i < allEnemy.Length; i++)
        {
            // 每次产生新的距离
            float newDistance = Vector3.Distance(this.transform.position, allEnemy[i].transform.position);
            // 新的距离 和最小距离作比较
            if (minDistance> newDistance)
            {
                min = allEnemy[i];
                // 因为最小距离和新距离要进行比较  所以每次比较完 要替换最小距离
                minDistance = newDistance;
            }
        }
        return min;
    }
}
