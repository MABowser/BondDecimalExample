using Bond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BondExampleB.Global
{
  public class Helpers
  {
    public static T SetBondedObjectOnBaseProperty<T, D>(T objectWithBaseProperty, string nameOfPropertyToSet, D derivedObject)
    {
      objectWithBaseProperty.GetType().InvokeMember(nameOfPropertyToSet,
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
        Type.DefaultBinder, objectWithBaseProperty, new object[] { new Bonded<D>(derivedObject) });

      return objectWithBaseProperty;
    }
  }
}
