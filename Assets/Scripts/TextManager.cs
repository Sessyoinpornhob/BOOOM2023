using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public int row = 1, col = 0;

    //public string filename;
    // row 是行数， column是列数



    void Start()
    {
        //csvController加载csv文件，单例模式，这个类只有一个对象，这个对象只能加载一个csv文件
        CSVController.instance.loadFile();
        //根据索引读取csvController中的list（csv文件的内容）数据
        Debug.Log("Reading is " + CSVController.GetInstance().getString(row, col));
        Debug.LogError("给你解决了，还不到隔壁叫爹");
    }


    // 搜索CSV文件中的字符串，返回字符串的行和列
    public Vector2Int SearchStringInCSV(string searchString)
    {
        // 获取CSVController实例
        CSVController csvController = CSVController.GetInstance();

        // 遍历CSV文件的行和列
        for (int r = 0; r < csvController.getRowCount(); r++)
        {
            for (int c = 0; c < 3; c++)
            {
                // 如果找到匹配的字符串，返回行和列
                if (csvController.getString(r, c) == searchString)
                {
                    return new Vector2Int(r, c);
                }
            }
        }

        // 如果没有找到匹配的字符串，返回-1，-1
        return new Vector2Int(-1, -1);
    }

    // 示例：搜索CSV文件中的字符串，获取对应字符串。
    public string TextSearch(string searchString, int needmode)
    {
        // 获取CSVController实例
        CSVController csvController = CSVController.GetInstance();

        // 搜索对应的坐标
        Vector2Int result = SearchStringInCSV(searchString);
        Debug.Log("The string '" + searchString + "' is found at row " + result.x + " and col " + result.y);

        // 获取左边和右边的字符串 用于确认和判定位置
        string searchStringLeft = csvController.getString(result.x, result.y - 1);
        string searchStringRight = csvController.getString(result.x, result.y + 1);
        Debug.Log("searchStringLeft= " + searchStringLeft + " and " + "searchStringRight= " + searchStringRight);

        // 取左取右 有点傻 等待重构
        if (needmode == 1)
        {
            return searchStringLeft;
        }
        else if (needmode == 0)
        {
            return searchStringRight;
        }
        return "-1";
    }
    
    
}
