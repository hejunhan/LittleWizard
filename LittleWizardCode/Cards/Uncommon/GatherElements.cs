using LittleWizard.LittleWizardCode.Api;
using LittleWizard.LittleWizardCode.Api.Animation;
using LittleWizard.LittleWizardCode.Api.Cards;
using LittleWizard.LittleWizardCode.Api.DynamicVars;
using LittleWizard.LittleWizardCode.Powers.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace LittleWizard.LittleWizardCode.Cards.Uncommon;

public class GatherElements()
    : LittleWizardCard(2, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new PowerVar<GatherElementsPower>(1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (IsUpgraded)
        {
            await PowerCmd.Apply<GatherElementsUpgradePower>(
                choiceContext,
                Owner.Creature,
                DynamicVarsHelper.GetPowerVar<GatherElementsPower>(DynamicVars).BaseValue,
                Owner.Creature,
                this
            );
        }
        else
        {
            await Utils.GivePower<GatherElementsPower>(this, cardPlay, choiceContext);
        }

        await AnimationHelper.TriggerCastAnimationOwner(this);
    }
}
