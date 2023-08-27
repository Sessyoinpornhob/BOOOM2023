using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class TextManager : MonoBehaviour
    {
        // row 是行数， column是列数
        public int row = 1, col = 0;

        void Start()
        {
            //csvController加载csv文件，单例模式，这个类只有一个对象，这个对象只能加载一个csv文件
            CSVController.instance.loadFile();
            //根据索引读取csvController中的list（csv文件的内容）数据
            //Debug.Log("Reading is " + CSVController.GetInstance().getString(row, col));
        }


        // 搜索CSV文件中的字符串，返回字符串的行和列
        public Vector2Int SearchStringInCSV(string searchString)
        {
            // 获取CSVController实例
            CSVController csvController = CSVController.GetInstance();

            // 遍历CSV文件的行和列
            for (int r = 0; r < csvController.getRowCount(); r++)
            {
                // 当时认为一共就三列，但现在看来其实也差不多够用
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
            //Debug.Log("The string '" + searchString + "' is found at row " + result.x + " and col " + result.y);

            // 获取左边和右边的字符串 用于确认和判定位置
            string searchStringLeft = csvController.getString(result.x, result.y - 1);
            string searchStringRight = csvController.getString(result.x, result.y + 1);

            // 获取插画名 --------> 做一个null检测，以防出现此处不需要插画改变的情况。
            string searchStringOfSprite = csvController.getString(result.x, result.y + 3);

            // 非固定顺序同时满足标识符  --------->  只有Yes和null
            string searchStringDouble = csvController.getString(result.x, result.y + 4);

            string searchStringCardSenderListNum = csvController.getString(result.x, result.y + 5);


            Debug.Log("searchStringLeft= " + searchStringLeft + " and " + "searchStringRight= " + searchStringRight);

            // 取左取右 有点傻 等待重构
            if (needmode == 0)
            {
                return searchStringLeft;
            }
            else if (needmode == 1)
            {
                return searchStringRight;
            }
            else if (needmode == 2)
            {
                return searchStringOfSprite;
            }
            else if (needmode == 3)
            {
                return searchStringDouble;
            }
            else if (needmode == 4)
            {
                return searchStringCardSenderListNum;
            }

            return "-1";
        }

    }
}

