using UnityEngine;

/// <summary>
/// Manages a part of the car that can be interacted with in order to fix/upgrade it.
/// </summary>
public class CarPartController : MonoBehaviour, IInteractable
{
	public KeyCode Key => KeyCode.R;
	public bool CanInteract
	{
		get => InventoryManager.Instance.Contains(_repairItemID);
		set { }
	}

	[SerializeField]
	private string _repairItemID;

	public void Interact()
	{
		// _TODO: show the changes on the car
		InventoryManager.Instance.Remove(_repairItemID);
		Destroy(gameObject);
	}
}
