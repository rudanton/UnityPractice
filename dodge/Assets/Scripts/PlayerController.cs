using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rg;
    public float vConst;
    Material myMaterial;
    WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        myMaterial = GetComponent<MeshRenderer>().materials[0];
        wait = new WaitForSeconds(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rg.velocity = new Vector3(h, 0, v)  * vConst;
    }
    private void OnTriggerEnter(Collider other) {
        // if(other.gameObject.GetComponent<BulletMove>()  !=null){
        //     other.gameObject.SetActive(false);
        //     StartCoroutine(flash());
        // }
        if(other.gameObject.CompareTag("bullet")){
            other.gameObject.SetActive(false);
            StartCoroutine(flash());
        }
    }
    IEnumerator flash(){
        for(int i = 0 ; i<8 ; i++)
        {
            // if (myMaterial.color == Color.white) myMaterial.color = Color.red;
            // else myMaterial.color = Color.white;
            myMaterial.color = myMaterial.color == Color.white ? Color.red : Color.white ; 
            yield return wait;
        }
    }
}
