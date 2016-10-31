using UnityEngine;
using System.Collections;

public class WalkingSurface : MonoBehaviour {

	public virtual Vector3 GetMovePos(Vector3 directedMovePos, Vector3 currentPlayerPos)
	{
		return directedMovePos;
	}
}
