using UnityEngine;

public class PickupController : MonoBehaviour, IInteractable
{
	public KeyCode Key => KeyCode.E;
	public bool CanInteract { get; set; } = true;

	[SerializeField]
	private string _inventoryID;

	private void Awake()
	{
		if (string.IsNullOrEmpty(_inventoryID))
		{
			Debug.LogError("The inventory ID cannot be null for " + name);
		}
	}

	public void Interact()
	{
		InventoryManager.Instance.Add(_inventoryID);
		Destroy(gameObject);
	}
}
