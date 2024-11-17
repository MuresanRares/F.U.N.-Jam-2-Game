using UnityEngine;

public interface IInteractable
{
	/// <summary>
	/// The key that should be pressed in order to interact with this object.
	/// </summary>
	KeyCode Key { get; }
	/// <summary>
	/// Is true if the player can interact with this object at the current moment.
	/// </summary>
	bool CanInteract { get; set; }

	/// <summary>
	/// Called when the player interacts with this object.
	/// </summary>
	void Interact();
}
