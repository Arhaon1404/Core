using System;
using System.Collections.Generic;
using UnityEngine;


public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services;

    static ServiceLocator()
    {
        _services = new Dictionary<Type, object>();
    }
    
    public static T GetService<T>()
    {
        if (_services.ContainsKey(typeof(T)) == false)
        {
            throw new KeyNotFoundException($"The service of type {typeof(T).FullName} could not be found.");
        }

        return (T)_services[typeof(T)];
    }
    
    public static void Register<T>(T service)
    {
        if (_services.ContainsKey(typeof(T)) == false)
        {
            _services[typeof(T)] = service;
        }
        else
        {
            Debug.Log("Service already registered.");
        }
    }
    
    public static void Reset()
    {
        _services.Clear();
    }
}
