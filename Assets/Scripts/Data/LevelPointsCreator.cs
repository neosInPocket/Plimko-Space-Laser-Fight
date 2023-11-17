using UnityEngine;

public static class LevelPointsCreator
{
    public static int LevelRewardCoins()
    {
        return (int)(11 * Mathf.Log(Mathf.Pow(PlayerData.CurrentProgress, 2) + 1) + 11);
    }
	
    public static int LevelPoints()
    {
        return (int)(11 * Mathf.Log(Mathf.Sqrt(PlayerData.CurrentProgress) + 1));
    }
}