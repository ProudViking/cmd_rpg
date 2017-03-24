using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg.Actions
{
    static class ActionParser
    {
        public static bool Parse(string pInput)
        {
            Type[] vActions = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "cmd_rpg.Actions");

            foreach(Type vActionType in vActions)
            {
                if(vActionType.IsSubclassOf(typeof(Actions.Action)))
                {
                    //string vValidCalls = vActionType.GetProperty("ValidCalls").GetValue().ToString();
                }
            }

            return true;
        }

        private static Type[] GetTypesInNamespace(Assembly pAssembly, string pNameSpace)
        {
            return pAssembly.GetTypes().Where(
                t =>
                String.Equals(t.Namespace, pNameSpace, StringComparison.Ordinal)
                && t.IsSubclassOf(typeof(Action))
                ).ToArray();
        }
    }
}
