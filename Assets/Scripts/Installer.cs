using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
        Container.Bind<Test>().AsSingle().NonLazy();
        Container.Bind<Test2>().AsSingle().NonLazy();
    }
}

public class Greeter
{
    public Greeter(string message)
    {
        Debug.Log(message);
    }
}