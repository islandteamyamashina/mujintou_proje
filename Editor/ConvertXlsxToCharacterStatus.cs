using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unityのエディタ上だけで使える機能を追加
//※通常のゲーム本体（Editorフォルダの外）で使わない！
using UnityEditor;

//Excelのデータ読み込み用のdllから追加
using ExcelDataReader;

//ファイル入出力のために利用
using System.IO;

public class ConvertXlsxToCharacterStatus
{
    //MenuItemのAttributeを付けると
    // Unityエディタ上でメニューを選んだときに関数を実行してもらえる
    [MenuItem("Tools/Excelのデータからステータスを生成")]
    public static void Execute()
    {
        var inputPath = EditorUtility.OpenFilePanel("Excelのファイルを開く", "", "xlsx");
        if (string.IsNullOrEmpty(inputPath))
        {
            return;
        }

        var outputPath = EditorUtility.OpenFolderPanel("出力先のフォルダを開く", "", "");
        if (string.IsNullOrEmpty(outputPath))
        {
            return;
        }

        //TODO : outputPathがAssetsフォルダ以下出ない場合はエラーにする
        // 今回は書き出し先をそれ以外にはしないということで割愛

        //フルパスになっているoutputPathをAssetsからのパスになるように変更
        var assetsOutPutPath = outputPath.Replace(Application.dataPath, "Assets");

        using (var inputStream = File.OpenRead(inputPath))
        {
            var reader = ExcelReaderFactory.CreateReader(inputStream);
            var dataset = reader.AsDataSet();
            var sheet = dataset.Tables[0];

            //0行目は項目名なので飛ばして1行目から読込む
            for (int row = 1; row < sheet.Rows.Count; row++)
            {
                var rowData = sheet.Rows[row];

                //A列目が名前なのでそれをファイル名にする
                var filePath = assetsOutPutPath + "/" + rowData[0].ToString() + ".asset";

                //ファイル名のアセットがあるかどうかで分岐
                CharacterStatus status = null;
                if (File.Exists(filePath))
                {
                    //あるなら更新のために読込む
                    status = AssetDatabase.LoadAssetAtPath<CharacterStatus>(filePath);
                }
                else
                {
                    //なければ新規作成
                    status = ScriptableObject.CreateInstance<CharacterStatus>();
                    AssetDatabase.CreateAsset(status, filePath);
                }

                //Excelのデータからステータスにint変換して設定
                status.SetParamter(
                    int.Parse(rowData[1].ToString()),
                    int.Parse(rowData[2].ToString()),
                    int.Parse(rowData[3].ToString()),
                    int.Parse(rowData[4].ToString()),
                    int.Parse(rowData[5].ToString())
                    );

                //ファイルの更新フラグを立てる
                EditorUtility.SetDirty(status);
            }
            //アセットの保存
            AssetDatabase.SaveAssets();
        }
    }
}
