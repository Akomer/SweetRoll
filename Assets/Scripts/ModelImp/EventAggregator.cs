using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public static class EventAggregator
{
    private static readonly Dictionary<Type, List<object>> _cache = new Dictionary<Type, List<object>>();

    public static void Register<T>(this object obj)
    {
        if(!_cache.ContainsKey(typeof(T)))
            _cache[typeof(T)] = new List<object>();
        _cache[typeof(T)].Add(obj);
    }

    public static void UnRegister<T>(this object obj)
    {
        if(!_cache.ContainsKey(typeof(T)))
            return;
        _cache[typeof(T)].Remove(obj);
    }

    public static void Register(object obj, Type listener)
    {
        if(!_cache.ContainsKey(listener))
            _cache[listener] = new List<object>();
        _cache[listener].Add(obj);
    }

    public static void UnRegister(object obj, Type listener)
    {
        if(!_cache.ContainsKey(listener))
            return;
        _cache[listener].Remove(obj);
    }

    public static void SendMessage<T>(T message)
    {
        if(!_cache.ContainsKey(message.GetType()))
            return;
        _cache[message.GetType()].Each(x => ((IListener<T>)x).Handle(message));
    }

    public static void SendMessage<T>() where T : new()
    {
        T message = new T();
        SendMessage<T>(message);
    }

    public static void UpdateCache<T>()
    {
        var type = typeof(IListener<T>);
        var list = new List<object>();

        // Get all types of IListener<T>
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetInterfaces().Contains(type))
            .Each(x => {
            // Add existing unity objects that listen for event
            GameObject.FindObjectsOfType<MonoBehaviour>()
                        .Where(t => t.GetType() == x)
                        .Each(list.Add);
        });

        _cache[typeof(T)] = list;
    }
}
