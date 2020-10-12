
using System.Collections.Generic;
using Zenject;

public class PlayerWonSignal : SignalBus
 {
     public PlayerWonSignal(List<SignalDeclaration> signalDeclarations, SignalBus parentBus, ZenjectSettings zenjectSettings, SignalSubscription.Pool subscriptionPool, SignalDeclaration.Factory signalDeclarationFactory, DiContainer container) : base(signalDeclarations, parentBus, zenjectSettings, subscriptionPool, signalDeclarationFactory, container)
     {
     }
 }

public class OpponentWonSignal : SignalBus
{
    public OpponentWonSignal(List<SignalDeclaration> signalDeclarations, SignalBus parentBus, ZenjectSettings zenjectSettings, SignalSubscription.Pool subscriptionPool, SignalDeclaration.Factory signalDeclarationFactory, DiContainer container) : base(signalDeclarations, parentBus, zenjectSettings, subscriptionPool, signalDeclarationFactory, container)
    {
    }
}
