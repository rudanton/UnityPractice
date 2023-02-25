using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SIngleton<GameManager>
{
    private Node seletedNode;
    private GameObject selectedObject;
    private Point[] aroundPoint = new Point[4];

    public bool SetNode(Node node, GameObject go)
    {
        if (seletedNode == node)
        {
            seletedNode = null;
            return false;
        }
        if (CheckAround(node.index))
        {
            seletedNode = null;
            var temp = go.transform.position;
            go.transform.position = selectedObject.transform.position;
            selectedObject.transform.position = temp;
            return true;
        }
        seletedNode = node;
        selectedObject = go;
        for (int i = 0; i < 4; i++)
        {
            aroundPoint[i] = seletedNode.index;
        }
        aroundPoint[0].Add(Point.left);
        aroundPoint[1].Add(Point.right);
        aroundPoint[2].Add(Point.up);
        aroundPoint[3].Add(Point.down);

        Debug.Log($"select x : {seletedNode.index.x}\ty : {seletedNode.index.y}");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log($"around x : {aroundPoint[i].x}\ty : {aroundPoint[i].y}");
        }
        return false;
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
}
