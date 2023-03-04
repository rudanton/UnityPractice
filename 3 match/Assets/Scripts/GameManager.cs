using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Node seletedNode;
    private Match3 selectedMatch;
    private Point[] aroundPoint = new Point[4];
    private readonly Point[] points = new Point[]{ Point.left, Point.right, Point.up, Point.down };

    #region UnityMehtod

    #endregion

    #region PrivateMethod

    private void SetAround(Point point)
    {
        for (int i = 0; i < 4; i++)
        {
            aroundPoint[i] = point;
            aroundPoint[i].Add(points[i]);
        }
    }
    private bool CheckAround(Point point)
    {
        for (int i = 0; i < 4; i++)
        {
            if (aroundPoint[i].IsEqual(point))
            {
                return true;
            }
        }
        return false;
    }
    #endregion
    #region PublicMethod
    public bool SetNode(Node node, Match3 match)
    {
        if (seletedNode == node)
        {
            seletedNode = null;
            return false;
        }
        if (seletedNode != null && CheckAround(node.index))
        {
            SwapPosition(match, selectedMatch);
            seletedNode = null;
            return true;
        }

        seletedNode = node;
        selectedMatch = match;

        SetAround(seletedNode.index);

        Debug.Log($"select x : {seletedNode.index.x}\ty : {seletedNode.index.y}");
        //for (int i = 0; i < 4; i++)
        //{
        //    Debug.Log($"around x : {aroundPoint[i].x}\ty : {aroundPoint[i].y}");
        //}
        return false;
    }
    public void SwapPosition(Match3 a, Match3 b)
    {
        //var temp = a.transform.position;
        //a.transform.position = b.transform.position;
        //b.transform.position = temp;

        var tmp = a.position.index;
        a.SetPoint(b.position.index);
        b.SetPoint(tmp);
    }
    #endregion
}
