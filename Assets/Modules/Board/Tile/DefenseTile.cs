using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using TH.Core;

public class DefenseTile : BaseTile
{
    private GameObject _countText;
    public override void OnAction(int num)
    {
        GameManager.Player.Defence(num);
    }

    public override void OnTurnEnd()
    {
        base.OnTurnEnd();
        if (_isCurse)
        {
            _curseTurnCount -= 1;
            UpdateCountText();
            if (_curseTurnCount == 0)
            {
                OffCurse();
                GameObject fireballPrefab = GameManager.Resource.LoadPrefab(ResourceManager.Prefabs.SUMMON_FIREBALL);
                GameObject s=Instantiate(fireballPrefab, transform.position, Quaternion.identity);
                s.GetComponent<Fireball>().Init(index);
                BoardManager.I.AddSummon(s.GetComponent<ISummon>());
            }
        }


    }
    [Button]
    public override void OnCurse(int count)
    {
        Sprite curseSprite = GameManager.Resource.LoadSprite(ResourceManager.Sprites.TILE_CURSE2);
        GetComponent<SpriteRenderer>().sprite = curseSprite;
        _isCurse = true;
        _curseTurnCount = count;
        _countText = Instantiate(GameManager.Resource.LoadPrefab(ResourceManager.Prefabs.UI_FIREBALLCOUNTTEXT));
        _countText.transform.parent = transform;
        _countText.transform.localPosition = new Vector3(0.23f, 0.485f, 0f);
        UpdateCountText();
    }

    public override void OffCurse()
    {
        Destroy(_countText);
        Sprite defenseSprite = GameManager.Resource.LoadSprite(ResourceManager.Sprites.TILE_DEFENSE);
        GetComponent<SpriteRenderer>().sprite = defenseSprite;
        _isCurse = false;
    }

    private void UpdateCountText()
    {
        _countText.GetComponent<TextMeshPro>().text = _curseTurnCount.ToString();
    }
}
