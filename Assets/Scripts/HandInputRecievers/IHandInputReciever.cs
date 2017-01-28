using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface IHandInputReciever
{
	void TouchPadDown();
	void TouchPadHold();
	void TouchPadUp();

	void TriggerDown();
	void TriggerUp();
	void TriggerHold();
}
