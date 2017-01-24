using UnityEngine;
using System.Collections;

public class PlayerStatsContainer : MonoBehaviour
{
	private int gold;
	private int mana;

	public void AddGold(int goldChange)
	{
		gold += goldChange;
	}

	public int GetGold()
	{
		return gold;
	}

	public void AddMana(int manaChange)
	{
		mana += manaChange;
	}

	public int GetMana()
	{
		return mana;
	}

	public bool HasEnoughMana(int requiredMana)
	{
		return mana >= requiredMana;
	}

	public void AddStats(StatsLoot loot)
	{
		AddGold(loot.gold);
		AddMana(loot.mana);
	}
}
