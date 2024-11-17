using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
	private List<string> _items = new List<string>();

	/// <summary>
	/// Adds an item (through its given <paramref name="ID"/>) to the inventory.
	/// </summary>
	/// <param name="ID"></param>
	public void Add(string ID)
	{
		if (!IsValid(ID)) return;

		if (!_items.Contains(ID))
		{
			_items.Add(ID);
		}
	}

	/// <summary>
	/// Removes an item (through its given <paramref name="ID"/>) from the inventory.
	/// </summary>
	/// <param name="ID"></param>
	public void Remove(string ID)
	{
		if (!IsValid(ID)) return;

		if (_items.Contains(ID))
		{
			_items.Remove(ID);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ID"></param>
	/// <returns>true if the item with the given <paramref name="ID"/> exists in the inventory</returns>
	public bool Contains(string ID)
	{
		if (!IsValid(ID)) return false;

		return _items.Contains(ID);
	}

	private bool IsValid(string ID)
	{
		if (string.IsNullOrEmpty(ID))
		{
			Debug.LogError("The ID cannot be null or empty.");
			return false;
		}

		return true;
	}
}