namespace Modules.Skill.Skills
{
    public class Draw : SkillInner
    {
        public override bool Execute()
        {
            int value = Level switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
            };

            GameManager.Log.Log($"{value} 만큼의 카드를 드로우할 것임");
            GameManager.Card.CardDeck.DrawCard(value);
            return true;
        }
    }
}