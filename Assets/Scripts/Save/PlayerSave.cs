using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PlayerSave : Singleton<PlayerSave>
{

    // Start is called before the first frame update
    public PlayerModel playerModel = new PlayerModel(); //浅拷贝playerModel类，同一地址共享数据
    private PlayerSaveModel playerSaveModel = new PlayerSaveModel(); //playerSaveModel类
    string filePath = Application.dataPath + "/Resources/Save/Save.json";

    #region 存档
    public void gameSave()
    {
        ObjectToJson();
        string playerModelJson = JsonMapper.ToJson(playerSaveModel);
        StreamWriter sw = new StreamWriter(filePath,true);
        sw.Write(playerModelJson);
        //关闭StreamWriter
        sw.Close();
    }
    void ObjectToJson()
    {
        playerSaveModel.playerName = playerModel.playerName;
        playerSaveModel.playerMaxHP = playerModel.playerMaxHP;
        playerSaveModel.playerHP = playerModel.playerHP;
        playerSaveModel.playerSTR = playerModel.playerSTR;
        playerSaveModel.playerDEF = playerModel.playerDEF;
        playerSaveModel.playerINT = playerModel.playerINT;
        playerSaveModel.playerSkillList = playerModel.playerSkillList;
        playerSaveModel.playerPosition = creatVector2Save(playerModel.playerPosition);
    }
    Vector2Save creatVector2Save(Vector2 vec)
    {
        Vector2Save v2s = new Vector2Save();
        v2s.x = double.Parse(vec.x.ToString());
        v2s.y = double.Parse(vec.y.ToString());
        return v2s;
    }
    #endregion


    #region 读档
    public void GameRead()
    {
        
        if (File.Exists(filePath))
        {
            //创建一个StreamReader，用来读取流
            StreamReader sr = new StreamReader(filePath);
            //将读取到的流赋值给playerModelJson
            string playerModelJson = sr.ReadToEnd();
            //关闭
            sr.Close();

            //将字符串playerModelJson转换为PlayerModel对象
            playerSaveModel = JsonMapper.ToObject<PlayerSaveModel>(playerModelJson);
            JsonToObject();
        }
        else 
        {
            Debug.Log("nothing");
            playerSaveModel.playerHP = 200;
        }

    }
    void JsonToObject()
    {
        playerModel.playerName = playerSaveModel.playerName;
        playerModel.playerMaxHP = playerSaveModel.playerMaxHP;
        playerModel.playerHP = playerSaveModel.playerHP;
        playerModel.playerSTR = playerSaveModel.playerSTR;
        playerModel.playerDEF = playerSaveModel.playerDEF;
        playerModel.playerINT = playerSaveModel.playerINT;
        playerModel.playerSkillList = playerSaveModel.playerSkillList;
        playerModel.playerPosition = new Vector2((float)playerModel.playerPosition.x, (float)playerModel.playerPosition.y);

    }
    #endregion



}
public class PlayerSaveModel
{
    public string playerName;
    public int playerMaxHP;
    public int playerHP;
    public int playerSTR;
    public int playerDEF;
    public int playerINT;
    public List<string> playerSkillList;
    public Vector2Save playerPosition;


}
public class Vector2Save
{
    public double x;
    public double y;

}