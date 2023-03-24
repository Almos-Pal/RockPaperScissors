using System;
using System.Text.Json.Serialization;

[Serializable]
public class JsonData
{
    [JsonPropertyName("EnemyPoints")]
    private string _enemyPoints;
    [JsonPropertyName("MyPoints")]
    private string _myPoints;
  
    public string EnemyPoints { get => _enemyPoints; set => _enemyPoints = value; }
    public string MyPoints { get => _myPoints; set => _myPoints = value; }
}
