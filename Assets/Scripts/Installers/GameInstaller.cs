using Signals;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] 
    private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPositionController>().AsSingle();

        Container.BindFactory<float, float, GameController, PlayerController, PlayerController.PlayerFabrik>()
            .FromComponentInNewPrefab(_gameConfig.playerPrefab)
            .WithGameObjectName("Player");
        
        Container.BindFactory<float, float, GameController, OpponentController, OpponentController.OpponentFabrik>()
            .FromComponentInNewPrefab(_gameConfig.opponentPrefab)
            .WithGameObjectName("Enemy");
        
        
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<PlayerWanSignal>();
        Container.DeclareSignal<EnemyWanSignal>();
        Container.BindInterfacesTo<PlayerWanSignalInitialize>().AsSingle();
        
    }
}
