using System.IO;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    [HideInInspector] public SaveData data;     // json変換するデータのクラス
    string filepath;                            // jsonファイルのパス
    string fileName = "Data.json";              // jsonファイル名

    //-------------------------------------------------------------------
    // 開始時にファイルチェック、読み込み
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        // パス名取得
        filepath = Application.dataPath + "/Tani/Saves/" + fileName;
    }
    private void Start()
    {
        

        //// ファイルがないとき、ファイル作成
        //if (!File.Exists(filepath))
        //{
        //    Save(data);
        //}

        //// ファイルを読み込んでdataに格納
        //data = Load(filepath);
    }
    //-------------------------------------------------------------------
    // jsonとしてデータを保存
    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    public SaveData Load()
    {
        StreamReader rd = new StreamReader(filepath);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
       // Save(new SaveData());
    }

    public bool DoesSaveExist()
    {
        return File.Exists(filepath);
    }

}