namespace ClassLibrary1.Modules;

public class AbstractModule : IModule
{
    private Dictionary<Type, Type> mappings;
    private Dictionary<Type, object> instances;


    public AbstractModule()
    {
        mappings = new Dictionary<Type, Type>();
        Configure();
    }
    
    public void CreateMapping<TInterface, TImplementation>()
    {
        if (!mappings.ContainsKey(typeof(TInterface)))
        {
            mappings.Add(typeof(TInterface), typeof(TImplementation));
        }
        
        
    }

    public Type GetMapping(Type interfaceType)
    {
        return mappings[interfaceType];
    }


    public virtual void Configure()
    {
        
    }

   
}