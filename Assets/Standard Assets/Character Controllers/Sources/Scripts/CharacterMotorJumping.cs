using UnityEngine;
using System.Collections;

// We will contain all the jumping related variables in one helper class for clarity.
class CharacterMotorJumping {
	// Can the character jump?
	public bool enabled = true;

	// How high do we jump when pressing jump and letting go immediately
	public float baseHeight = 1.0f;

	// We add extraHeight units (meters) on top when holding the button down longer while jumping
	public float extraHeight = 4.1f;

	// How much does the character jump out perpendicular to the surface on walkable surfaces?
	// 0 means a fully vertical jump and 1 means fully perpendicular.
	public float perpAmount = 0.0f;

	// How much does the character jump out perpendicular to the surface on too steep surfaces?
	// 0 means a fully vertical jump and 1 means fully perpendicular.
	public float steepPerpAmount = 0.5f;

	// For the next variables, @System.NonSerialized tells Unity to not serialize the variable or show it in the inspector view.
	// Very handy for organization!

	// Are we jumping? (Initiated with jump button and not grounded yet)
	// To see if we are just in the air (initiated by jumping OR falling) see the grounded variable.
	//@System.NonSerialized
	public bool jumping = false;

	//@System.NonSerialized
	public bool holdingJumpButton = false;

	// the time we jumped at (Used to determine for how long to apply extra jump power after jumping.)
	//@System.NonSerialized
	public float lastStartTime = 0.0f;

	//@System.NonSerialized
	public float lastButtonDownTime = -100;

	//@System.NonSerialized
	public Vector3 jumpDir = Vector3.up;
}