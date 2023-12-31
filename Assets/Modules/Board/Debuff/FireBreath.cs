using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TH.Core;

public class FireBreath : Debuff {

    private int _damage;
    public override GameObject Effect => GameManager.Resource.LoadPrefab(ResourceManager.Prefabs.CURSE_FIREBREATH);
    public FireBreath(int damage, int count)
    {
        _debuffCount =count;
        _damage = damage;

    }

    [Button]
    public void testSetCount(int count)
    {
        _debuffCount = count;
    }
    
    public override void OnDebuff()
    {
        GameManager.Player.Hit(_damage);

    }

    public override void OffDebuff()
    {
        
    }

}
