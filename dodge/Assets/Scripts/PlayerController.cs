using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rg;
    public float vConst;
    Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        myMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rg.velocity = new Vector3(h, 0, v)  * vConst;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<BulletMove>()  !=null){
            other.gameObject.SetActive(false);
            StartCoroutine(flash());
        }
    }
    IEnumerator flash(){
        myMaterial.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMaterial.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        myMaterial.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMaterial.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        
    }
}
