namespace ClassLibrary1.Modules;

public interface IModule
{
    public void CreateMapping<TInterface, TImplementation>();

    public Type GetMapping(Type interfaceType);
    public abstract void Configure();

  
    
    
}