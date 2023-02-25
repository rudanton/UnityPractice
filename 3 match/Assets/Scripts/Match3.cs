using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Match3 : MonoBehaviour
{
    GameObject clicking;
    Node position;
    EventTrigger eventTrigger;
    Toggle toggle;
    
    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((ed) => { CheckClick((PointerEventData)ed); });
        eventTrigger.triggers.Add(entry);

        toggle = GetComponent<Toggle>();
        toggle.group = GetComponentInParent<ToggleGroup>();
        toggle.graphic = transform.GetChild(0).GetComponent<Image>();
    }

    public void SetMatch3(Node node){
        //생성시 데이터 초기화.
        position = node;
    }
    void CheckClick(PointerEventData data){
        GameManager.Instance.SetNode(position);
    }
}
