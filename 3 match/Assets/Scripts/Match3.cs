using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Match3 : MonoBehaviour
{
    #region Variable
    private EventTrigger eventTrigger;
    private Toggle toggle;

    public Node position { get; private set; }
    public GameObject myGameObject => gameObject;

    private WaitForSeconds _deltaT = new WaitForSeconds(0.02f);
    private RectTransform _rect;

    #endregion

    #region UnityMethod
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

        _rect = GetComponent<RectTransform>();
    }
    #endregion

    #region PublicMethod
    public void SetMatch3(Node node)
    {
        //생성시 데이터 초기화.
        position = node;
    }
    public void SetPoint(Point point)
    {
        var goal = point;
        goal.Sub(position.index);

        var goalVec = _rect.anchoredPosition + new Vector2(goal.x, -goal.y)*Vaiable.size;
       
        StartCoroutine(MoveCoroutine(goalVec));
        position.index = point;

    }
    #endregion

    #region PrivateMethod
    private void CheckClick(PointerEventData data)
    {
        GameManager.Instance.SetNode(position, this);
    }
    #endregion
    #region Coroutine

    private IEnumerator MoveCoroutine(Vector2 goal)
    {
        float time = 0;
        var start = _rect.anchoredPosition;
        while (time < 1)
        {
            _rect.anchoredPosition = Vector2.Lerp(start, goal, time);
            time += 0.02f;
            yield return _deltaT;
        }
        _rect.anchoredPosition = goal;

    }
    #endregion
}
