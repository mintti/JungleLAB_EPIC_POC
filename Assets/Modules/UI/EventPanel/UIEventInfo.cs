using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class UIEventInfo : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TextMeshProUGUI eventInfoTMP;
    [SerializeField] private Button eventDrawBtn;

    public void Init()
    {
        eventInfoTMP.text = "랜덤 이벤트를 실행합니다.";
        eventDrawBtn.gameObject.SetActive(true);
    }

    public void B_Execute() => StartCoroutine(EventExecutor());
    
    [Header("Event")]
    [SerializeField] private List<Event> _events;

    List<Event> Events
    {
        get
        {
            _events ??= new()
            {
                new("꽝", Blank),
                new("시작 지점으로 걸어서 이동합니다.", WalkToStartTile),
                new("숫자 카드를 2장 드로우 합니다.", Draw2Card),
                new("적에게 취약과 약화를 2턴동안 겁니다.", Week3ToEnemy),
                new("앞으로 3칸 이동합니다.", Move3),
                new("패에 있는 숫자 카드 하나의 숫자를 2배 해줍니다.", Multiple2),
                new("패에 있는 숫자 카드 하나를 복제해줍니다.", Copy),
                new("마법진을 1개 획득합니다.", GetMagicCircle1),
                new("원하는 지점으로 순간이동 합니다. (이벤트 제외)", MoveToWantedTile),
                new("숫자 카드를 원하는 만큼 버리고, 버린만큼 뽑습니다.", DropNDrawN),
            };

            return _events;
        }   
    }
    
    class Event
    {
        public string Name { get; }
        public Func<IEnumerator> Action { get; }

        public Event(string name, Func<IEnumerator> action)
        {
            Name = name;
            Action = action;
        }
    }

    IEnumerator EventExecutor()
    {
        // 랜덤 이벤트 설정
        var idx = Random.Range(0, Events.Count);
        var evt = Events[idx];
        
        eventInfoTMP.text = evt.Name;

        // 수행
        yield return evt.Action;
        
        // 1초 후 액션 종료
        yield return new WaitForSeconds(1f);
    }
    
    IEnumerator Blank()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator WalkToStartTile()
    {
        yield return null;
    }

    IEnumerator Draw2Card()
    {
        // GameManager.Card.DrawCards(2);
        yield return null;
    }

    IEnumerator Week3ToEnemy()
    {
        yield return null;
    }

    IEnumerator Move3()
    {
        yield return null;
    }

    IEnumerator Multiple2()
    {
        yield return null;
    }

    IEnumerator Copy()
    {
        yield return null;
    }

    IEnumerator GetMagicCircle1()
    {
        yield return null;
    }

    IEnumerator MoveToWantedTile()
    {
        yield return null;
    }
    
    IEnumerator DropNDrawN()
    {
        yield return null;
    }


}