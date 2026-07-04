using BaseLib.Utils;
using LittleWizard.LittleWizardCode.Api.Cards;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace LittleWizard.LittleWizardCode.Cards.Uncommon;

public class FlatTumble()
    : LittleWizardCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(7, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
    }

    protected override (PileType, CardPilePosition) GetResultPileTypeAndPositionForCardPlay()
    {
        var result = base.GetResultPileTypeAndPositionForCardPlay();
        return result.Item1 != PileType.Discard ? result : (PileType.Hand, result.Item2);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(3);
    }
}
