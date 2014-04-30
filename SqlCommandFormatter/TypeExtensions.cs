﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlCommandFormatter
{
    public static class TypeExtensions
    {
#if NET40 || SILVERLIGHT || PORTABLE_LEGACY
        public static IEnumerable<PropertyInfo> GetDeclaredProperties(this Type type)
        {
            return type.GetProperties();
        }

        public static PropertyInfo GetDeclaredProperty(this Type type, string propertyName)
        {
            return type.GetProperty(propertyName);
        }

        public static IEnumerable<FieldInfo> GetDeclaredFields(this Type type)
        {
            return type.GetFields();
        }

        public static MethodInfo GetDeclaredMethod(this Type type, string methodName)
        {
            return type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static IEnumerable<ConstructorInfo> GetDeclaredConstructors(this Type type)
        {
            return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetConstructor(new Type[] {});
        }

        public static TypeAttributes GetTypeAttributes(this Type type)
        {
            return type.Attributes;
        }

        public static Type[] GetGenericTypeArguments(this Type type)
        {
            return type.GetGenericArguments();
        }

        public static bool IsTypeAssignableFrom(this Type type, Type otherType)
        {
            return type.IsAssignableFrom(otherType);
        }

        public static bool HasCustomAttribute(this Type type, Type attributeType, bool inherit)
        {
            return Attribute.IsDefined(type, attributeType, inherit);
        }

        public static bool IsGeneric(this Type type)
        {
            return type.IsGenericType;
        }

        public static bool IsValue(this Type type)
        {
            return type.IsValueType;
        }
#else
        public static IEnumerable<PropertyInfo> GetDeclaredProperties(this Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }

        public static PropertyInfo GetDeclaredProperty(this Type type, string propertyName)
        {
            return type.GetTypeInfo().GetDeclaredProperty(propertyName);
        }

        public static IEnumerable<FieldInfo> GetDeclaredFields(this Type type)
        {
            return type.GetTypeInfo().DeclaredFields;
        }

        public static MethodInfo GetDeclaredMethod(this Type type, string methodName)
        {
            return type.GetTypeInfo().GetDeclaredMethod(methodName);
        }

        public static IEnumerable<ConstructorInfo> GetDeclaredConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors.SingleOrDefault(x => x.GetParameters().Length == 0);
        }

        public static TypeAttributes GetTypeAttributes(this Type type)
        {
            return type.GetTypeInfo().Attributes;
        }

        public static Type[] GetGenericTypeArguments(this Type type)
        {
            return type.GetTypeInfo().GenericTypeArguments;
        }

        public static bool IsTypeAssignableFrom(this Type type, Type otherType)
        {
            return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
        }

        public static bool HasCustomAttribute(this Type type, Type attributeType, bool inherit)
        {
            return type.GetTypeInfo().GetCustomAttribute(attributeType, inherit) != null;
        }

        public static bool IsGeneric(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        public static bool IsValue(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }
#endif
    }
}