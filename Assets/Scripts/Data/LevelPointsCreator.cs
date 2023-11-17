using UnityEngine;

public static class LevelPointsCreator
{
    public static int LevelRewardCoins()
    {
        PlayerData playerData = new PlayerData(false);
        return (int)(11 * Mathf.Log(Mathf.Pow(playerData.CurrentGameProgress, 2) + 1) + 11);
    }
	
    public static int LevelPoints()
    {
        PlayerData playerData = new PlayerData(false);
        return (int)(11 * Mathf.Log(Mathf.Sqrt(playerData.CurrentGameProgress) + 1));
    }
}