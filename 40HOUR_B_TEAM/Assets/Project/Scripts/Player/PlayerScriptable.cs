using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


[CreateAssetMenu(menuName ="Test_Scriptable")]
public class PlayerScriptable : ScriptableObject
{
    public List<animData> AnimDataList = new List<animData>();
}
[System.Serializable]
public class animData 
{  
    public Animation anime_Stand; 
    public Animation anime_Shock; 
    public Animation anime_YareYare; 
    public Animation anime_4th; 
    public Animation anime_Happy; 
}
