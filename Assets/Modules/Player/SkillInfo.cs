using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class SkillInfo : Singleton<SkillInfo>
{
    private int _maxCastingCount = 5;

    public int MaxCastingCount
    {
        get => _maxCastingCount;
        set
        {
            _maxCastingCount = value;
            UIManager.I.UIPlayerInfo.UIPlayerSkill.UpdateMaxCastingCount(_maxCastingCount);
        }
    }
    
    private int _castingGauge;
    public int CastingGauge
    {
        get => _castingGauge;
        set
        {
            _castingGauge = value;

            if (_castingGauge >= MaxCastingCount)
            {
                MagicCircleCount += _castingGauge / MaxCastingCount;
                CastingGauge = _castingGauge % MaxCastingCount;
            }   
            
            UIManager.I.UIPlayerInfo.UIPlayerSkill.UpdateCastingGauge(_castingGauge, _maxCastingCount);
        }
    }

    private int _magicCircleCount;

    public int MagicCircleCount
    {
        get => _magicCircleCount;
        set
        {
            _magicCircleCount = value;
            UIManager.I.UIPlayerInfo.UIPlayerSkill.UpdateMagicCircleCount(_magicCircleCount);
        }
    }

    [Button]
    public void AddCastingGauge(int value)
    {
        CastingGauge += value;
    }

    private List<SkillData> _learnedSkills;
    public void LearnSkill(SkillData learningSkill)
    {
        _learnedSkills ??= new();

        var skill = _learnedSkills.FirstOrDefault(x => x.SkillType == learningSkill.SkillType);
        if (skill == null)
        {
            _learnedSkills.Add(learningSkill);
        }
        else
        {
            skill.Inner.LevelUp();
        }
        
        UIManager.I.UIPlayerInfo.UIPlayerSkill.LearnSkill(learningSkill);
    }
}