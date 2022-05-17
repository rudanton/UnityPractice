using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bullet;
    float coolTime = 3f;
    Queue<GameObject> magazine;
    // Start is called before the first frame update
    void Start()
    {
        magazine = new Queue<GameObject>();
        for(int i = 0 ; i<15 ; i++)
        {
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position + Vector3.up;
            magazine.Enqueue(go);
            go.SetActive(false);

        }
            StartCoroutine(shoot());
    }
    IEnumerator shoot(){
       while(true){ 
           yield return new WaitForSeconds(coolTime);
        GameObject b = magazine.Dequeue();
        b.SetActive(true);
        magazine.Enqueue(b);
        coolTime = Random.Range(0.5f, 1.9f);}
    }
}
