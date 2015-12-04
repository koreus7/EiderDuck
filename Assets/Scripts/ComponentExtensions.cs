using System;
using System.Reflection;
using System.Collections;
using UnityEngine;

/// <summary>
/// Component extensions.
/// </summary>
public static  class ComponentExtensions 
{

	/// <summary>
	/// Clones a component.
	/// </summary>
	/// <returns>The new copy of the component</returns>
	/// <param name="component">The component this is called from</param>
	/// <param name="other">Where we copy the properties from.</param>
	/// <typeparam name="T">The type of component</typeparam>
	public static T GetCopyOf<T>(this Component component, T other) where T : Component
	{
		Type type = component.GetType();

		// Type missmatch
		if (type != other.GetType ())
		{
			Debug.LogWarning("Tried to copy " +  other.GetType().ToString() + "on to "+ type.ToString());
			return null; 
		}


		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | 
				BindingFlags.Default | BindingFlags.DeclaredOnly;

		PropertyInfo[] propertInfos = type.GetProperties(flags);

		//Look through all the properties
		foreach (var propertyInfo in propertInfos) 
		{
			if (propertyInfo.CanWrite) 
			{
				try 
				{
					//Copy the property.
					propertyInfo.SetValue(component, propertyInfo.GetValue(other, null), null);
				}
				// In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
				catch 
				{
				} 
			}
		}

		//Copy fields.
		FieldInfo[] finfos = type.GetFields(flags);
		foreach (var finfo in finfos) 
		{
			finfo.SetValue(component, finfo.GetValue(other));
		}

		return component as T;
	}

}
