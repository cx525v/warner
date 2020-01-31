
using MyApp.Extensions;
using System;

namespace MyApp.Utils
{
    internal static class ObjHelper
    {
        public static object GetPropertyValue(object obj, string property)
        {           
            try
            {
               return obj.GetType().GetProperty(property.ToTitleCase()).GetValue(obj, null);
            }
            catch (Exception e)
            {
                Console.WriteLine("error while retrieving value");
                return null;
            }
           
        }
    }
}
