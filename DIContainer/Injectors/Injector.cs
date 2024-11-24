using System.Reflection;
using ClassLibrary1.Attributes;
using ClassLibrary1.Modules;

namespace ClassLibrary1.Injectors;

public class Injector
{
    private IModule _module;
    
    
    public Injector(IModule module)
    {
        this._module = module;
    }

    public TClass Inject<TClass>()
    {
        Type classType = typeof(TClass);

        ConstructorInfo[] constructors = classType.GetConstructors();

        foreach (var constructor in constructors)
        {
            if (constructor.GetCustomAttributes(typeof(Inject)) == null)
            {
                continue;
            }

           
            ParameterInfo[] constructorParams = constructor.GetParameters();

            object[] implementationsParams = new object[constructorParams.Length];

            int i = 0;
            
            foreach (var constructorParam in constructorParams)
            {
                Type implementationType = _module.GetMapping(constructorParam.ParameterType);

                implementationsParams[i++] = Activator.CreateInstance(implementationType);
            }

            return (TClass)Activator.CreateInstance(classType, implementationsParams);
        }
        
        return default(TClass);
    }
}