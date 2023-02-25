using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SIngleton<GameManager>
{
    private Node seletedNode;
    private Point[] aroundPoint = new Point[4];
    public void SetNode(Node node)
    {
        if (seletedNode == node)
        {
            seletedNode = null;
            return;
        }
        seletedNode = node;
        for (int i = 0; i < 4; i++)
        {
            aroundPoint[i] = seletedNode.index;
        }
        aroundPoint[0].Add(Point.left);
        aroundPoint[1].Add(Point.right);
        aroundPoint[2].Add(Point.up);
        aroundPoint[3].Add(Point.down);
        
            Debug.Log($"select x : {seletedNode.index.x}\ty : {seletedNode.index.y}");
        for(int i = 0; i < 4;i++)
        {
            Debug.Log($"around x : {aroundPoint[i].x}\ty : {aroundPoint[i].y}");
        }
    }
    private bool CheckAround()
    {
        return false;
    }
}
