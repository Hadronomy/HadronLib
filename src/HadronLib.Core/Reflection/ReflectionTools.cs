using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
<<<<<<< HEAD
=======
using HadronLib.Registry;
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878

namespace HadronLib.Reflection
{
    /// <summary>
    /// Collection of reflection related helper functions
    /// </summary>
    public static class ReflectionTools
    {
        /// <summary>
        /// Returns all the classes that have a custom attribute of type <typeparamref name="TAttribute"/>
        /// within the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly from where to get the classes from</param>
        /// <typeparam name="TAttribute">The type of the attribute to search for</typeparam>
        /// <returns></returns>
<<<<<<< HEAD
        public static IEnumerable<Type> GetClassesWithAttribute<TAttribute> (Assembly assembly) 
=======
        public static IEnumerable<Type> GetClassesWithAttribute<TAttribute> (this Assembly assembly) 
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
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
        
        /// <summary>
        /// Checks if the passed <paramref name="object"/> has a custom attribute of type <typeparamref name="TAttribute"/>
        /// </summary>
        /// <param name="object">The object from where to search</param>
        /// <typeparam name="TClass">The type of the <paramref name="object"/></typeparam>
        /// <typeparam name="TAttribute">The type of the attribute</typeparam>
        /// <returns>True if the class contains the specified attribute</returns>
<<<<<<< HEAD
        public static bool HasAttribute<TClass, TAttribute>(TClass @object)
=======
        public static bool HasAttribute<TClass, TAttribute>(this TClass @object)
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            where TAttribute : Attribute
        {
            return @object.GetType().GetCustomAttributes<TAttribute>().Any();
        }

<<<<<<< HEAD
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TAttribute>(Type objectType, Func<FieldInfo, bool> filter)
=======
        /// <summary>
        /// Returns an enumeration with all the fields that have a custom attribute within the specified
        /// <paramref name="objectType"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TAttribute>(this Type objectType, 
            Func<FieldInfo, bool> filter = null)
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            where TAttribute : Attribute
        {
            var objFields = objectType.GetFields();
            var fieldsWithAttribute = objFields.Where(field => 
                field.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(field) ?? true)
            );
            
            return fieldsWithAttribute;
        }
<<<<<<< HEAD
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TClass, TAttribute>(TClass @object, Func<FieldInfo, bool> filter = null)
=======
        
        /// <summary>
        /// Returns an enumeration with all the fields that have a custom attribute within the specified
        /// <paramref name="object"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<TClass, TAttribute>(this TClass @object, 
            Func<FieldInfo, bool> filter = null)
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            where TAttribute : Attribute
        {
            var objType = @object.GetType();
            return GetFieldsWithAttribute<TAttribute>(objType, filter);
        }

<<<<<<< HEAD
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttribute>(Type objectType,
=======
        /// <summary>
        /// Returns an enumeration with all the properties that have a custom attribute within the specified <paramref name="objectType"/>
        /// </summary>
        /// <param name="objectType">The type of the object from where to get the properties</param>
        /// <param name="filter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttribute>(this Type objectType,
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            Func<PropertyInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objProperties = objectType.GetProperties();
            var propertiesWithAttribute = objProperties.Where(prop =>
                prop.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(prop) ?? true)
            );

            return propertiesWithAttribute;
        }

<<<<<<< HEAD
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TClass, TAttribute>(TClass @object,
=======
        /// <summary>
        /// Returns an enumeration with all the properties that have a custom attribute within the specified <paramref name="object"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TClass, TAttribute>(this TClass @object,
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            Func<PropertyInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objType = @object.GetType();
<<<<<<< HEAD
            return GetPropertiesWithAttribute<Attribute>(objType, filter);
        }

        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TAttribute>(Type objectType,
=======
            return GetPropertiesWithAttribute<TAttribute>(objType, filter);
        }

        /// <summary>
        /// Returns an enumeration with all the methods that have a custom attribute within the specified <paramref name="objectType"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TAttribute>(this Type objectType,
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            Func<MethodInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objMethods = objectType.GetMethods();
            var methodsWithAttribute = objMethods.Where(method =>
                method.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(method) ?? true)
                );

            return methodsWithAttribute;
        }

<<<<<<< HEAD
        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TClass, TAttribute>(TClass @object,
=======
        /// <summary>
        /// Returns an enumeration with all the methods that have a custom attribute within the specified <paramref name="object"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<TClass, TAttribute>(this TClass @object,
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
            Func<MethodInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objectType = @object.GetType();
            return GetMethodsWithAttribute<TAttribute>(objectType, filter);
        }
<<<<<<< HEAD
=======

        /// <summary>
        /// Returns an enumeration with all the constructors that have a custom attribute within the specified <paramref name="objectType"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<ConstructorInfo> GetConstructorsWithAttribute<TAttribute>(this Type objectType,
            Func<ConstructorInfo, bool> filter = null)
        where TAttribute : Attribute
        {
            return objectType.GetConstructors().Where(constructor =>
                constructor.GetCustomAttributes<TAttribute>().Any() && (filter?.Invoke(constructor) ?? true)
            );
        } 
        
        /// <summary>
        /// Returns an enumeration with all the constructors that have a custom attribute within the specified <paramref name="object"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<ConstructorInfo> GetConstructorsWithAttribute<TClass, TAttribute>(this TClass @object,
            Func<ConstructorInfo, bool> filter = null)
            where TAttribute : Attribute
        {
            var objectType = @object.GetType();
            return GetConstructorsWithAttribute<TAttribute>(objectType, filter);
        }

        /// <summary>
        /// Constructs/Builds a class using the provided <paramref name="constructorInfo"/> and <paramref name="parameters"/>
        /// </summary>
        /// <param name="constructorInfo"></param>
        /// <param name="parameters"></param>
        /// <typeparam name="TClass"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static TClass Construct<TClass>(this ConstructorInfo constructorInfo, params object[] parameters)
            where TClass : class
        {
            if (constructorInfo.DeclaringType == typeof(TClass))
            {
                throw new InvalidCastException("The passed TClass doesn't match the declaring type of the constructor");
            }

            return constructorInfo.Invoke(parameters) as TClass;
        }
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
    }
}