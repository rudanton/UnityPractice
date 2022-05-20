using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesMaker : MonoBehaviour
{
    public List<GameObject> sprites;
    int[,] positions;
    // Start is called before the first frame update
    private void Awake() {
        positions = new int[9, 16];
        for(int i = 0 ; i<9; i++)
        {
            for(int j = 0; j<16; j++){
                int index = Random.Range(0,9);
                GameObject go = Instantiate(sprites[index], gameObject.transform);
                RectTransform  rt = go.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(16+32 + i*64, -16-32 - j*64,0);
            }
        }
    }
}
