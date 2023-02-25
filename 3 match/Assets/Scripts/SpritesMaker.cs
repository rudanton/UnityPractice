using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum KIND
{
    DEER,
    CAT,
    DOG, MOUSE,
    PIG,
    PANDA,
    RABBIT,
    DUCK,
    BEAR,
    NONE,
}
public class SpritesMaker : MonoBehaviour
{
    public const int width = 9;
    public const int height = 16;
    public const int size = 64;
    public const int padding = 16;

    public List<GameObject> sprites;
    Node[,] positions;
     
    // Start is called before the first frame update
    private void Awake()
    {
        positions = new Node[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = Random.Range(0, 9);
                positions[x, y] = new Node(index, new Point(x, y));
                GameObject go = Instantiate(sprites[index], gameObject.transform);
                RectTransform rt = go.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(
                    padding * 3 + x * size,
                    -padding * 3 - y * size,
                     0);
                go.GetComponent<Match3>().SetMatch3(positions[x, y]);
            }
        }
        
    }
}
[System.Serializable]
public class Node
{
    public int value;
    public Point index;

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }
}

