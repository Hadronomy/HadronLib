using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HadronLib.Reflection
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Returns all the classes that have a custom attribute of type <typeparamref name="TAttribute"/>
        /// within the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly from where to get the classes from</param>
        /// <typeparam name="TAttribute">The type of the attribute to search for</typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> GetClassesWithAttribute<TAttribute> (Assembly assembly) 
            where TAttribute : Attribute
        {
            var assemblyTypes = assembly.GetTypes();
            var filteredTypes = assemblyTypes.Where(type =>
            {
                var typeAttributes = type.GetCustomAttributes<TAttribute>();
                return typeAttributes.Any();
            });

            return filteredTypes;
        }

        /// <summary>
        /// Checks if the passed <typeparamref name="TClass"/> has a custom attribute of type <typeparamref name="TAttribute"/>
        /// </summary>
        /// <typeparam name="TClass">Type of the class to search in</typeparam>
        /// <typeparam name="TAttribute">Type of the attribute to search for</typeparam>
        /// <returns></returns>
        public static bool HasAttribute<TClass ,TAttribute>()
            where TAttribute : Attribute
        {
            return typeof(TClass).GetCustomAttributes<TAttribute>().Any();
        }
        
        public static bool HasAttribute<TClass, TAttribute>(TClass @object)
            where TAttribute : Attribute
        {
            return @object.GetType().GetCustomAttributes<TAttribute>().Any();
        }

        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TAttribute>(Type objectType, Func<FieldInfo, bool> filter)
            where TAttribute : Attribute
        {
            var objFields = objectType.GetFields();
            var fieldsWithAttribute = objFields.Where(field => 
                field.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(field) ?? true)
            );
            
            return fieldsWithAttribute;
        }
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TClass, TAttribute>(TClass @object, Func<FieldInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objType = @object.GetType();
            return GetFieldsWithAttribute<TAttribute>(objType, filter);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttribute>(Type objectType,
            Func<PropertyInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objProperties = objectType.GetProperties();
            var propertiesWithAttribute = objProperties.Where(prop =>
                prop.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(prop) ?? true)
            );

            return propertiesWithAttribute;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TClass, TAttribute>(TClass @object,
            Func<PropertyInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objType = @object.GetType();
            return GetPropertiesWithAttribute<Attribute>(objType, filter);
        }

        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TAttribute>(Type objectType,
            Func<MethodInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objMethods = objectType.GetMethods();
            var methodsWithAttribute = objMethods.Where(method =>
                method.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(method) ?? true)
                );

            return methodsWithAttribute;
        }

        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TClass, TAttribute>(TClass @object,
            Func<MethodInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objectType = @object.GetType();
            return GetMethodsWithAttribute<TAttribute>(objectType, filter);
        }
    }
}