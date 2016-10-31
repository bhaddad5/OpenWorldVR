using UnityEngine;
using System.Collections;

public class Stairs : WalkingSurface
{
	public Transform moveToPos1;
	public Transform moveToPos2;

	public override Vector3 GetMovePos(Vector3 directedMovePos, Vector3 currentPlayerPos)
	{
		float distToPos1 = Vector3.Magnitude(currentPlayerPos.VectorTo(moveToPos1.position));
		float distToPos2 = Vector3.Magnitude(currentPlayerPos.VectorTo(moveToPos2.position));
		if (distToPos1 > distToPos2)
		{
			return moveToPos1.position;
		}
		return moveToPos2.position;
	}
}
