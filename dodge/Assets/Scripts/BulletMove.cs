using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject aim;
    Vector3 vel = Vector3.zero;
    Vector3 initVec;
    private void Awake() {
        aim = FindObjectOfType<PlayerController>().gameObject;
     
    }  
    private void OnEnable() {
        initVec = transform.position;
        StartCoroutine(Deactivator());
    }
    private void OnTriggerEnter(Collider other) {
        gameObject.transform.position = initVec;   
    }
    private void Update() {
        Movement();
    }
    void Movement(){
        transform.position += vel * Time.deltaTime * 4;
    }
    IEnumerator Deactivator(){
        vel = aim.transform.position - transform.position;
        vel = vel.normalized;
        yield return new WaitForSeconds(15f);
        transform.position = initVec;
        gameObject.SetActive(false);
    }
}
