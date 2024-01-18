using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity�̃G�f�B�^�ゾ���Ŏg����@�\��ǉ�
//���ʏ�̃Q�[���{�́iEditor�t�H���_�̊O�j�Ŏg��Ȃ��I
using UnityEditor;

//Excel�̃f�[�^�ǂݍ��ݗp��dll����ǉ�
using ExcelDataReader;

//�t�@�C�����o�͂̂��߂ɗ��p
using System.IO;

public class ConvertXlsxToCharacterStatus
{
    //MenuItem��Attribute��t�����
    // Unity�G�f�B�^��Ń��j���[��I�񂾂Ƃ��Ɋ֐������s���Ă��炦��
    [MenuItem("Tools/Excel�̃f�[�^����X�e�[�^�X�𐶐�")]
    public static void Execute()
    {
        var inputPath = EditorUtility.OpenFilePanel("Excel�̃t�@�C�����J��", "", "xlsx");
        if (string.IsNullOrEmpty(inputPath))
        {
            return;
        }

        var outputPath = EditorUtility.OpenFolderPanel("�o�͐�̃t�H���_���J��", "", "");
        if (string.IsNullOrEmpty(outputPath))
        {
            return;
        }

        //TODO : outputPath��Assets�t�H���_�ȉ��o�Ȃ��ꍇ�̓G���[�ɂ���
        // ����͏����o���������ȊO�ɂ͂��Ȃ��Ƃ������ƂŊ���

        //�t���p�X�ɂȂ��Ă���outputPath��Assets����̃p�X�ɂȂ�悤�ɕύX
        var assetsOutPutPath = outputPath.Replace(Application.dataPath, "Assets");

        using (var inputStream = File.OpenRead(inputPath))
        {
            var reader = ExcelReaderFactory.CreateReader(inputStream);
            var dataset = reader.AsDataSet();
            var sheet = dataset.Tables[0];

            //0�s�ڂ͍��ږ��Ȃ̂Ŕ�΂���1�s�ڂ���Ǎ���
            for (int row = 1; row < sheet.Rows.Count; row++)
            {
                var rowData = sheet.Rows[row];

                //A��ڂ����O�Ȃ̂ł�����t�@�C�����ɂ���
                var filePath = assetsOutPutPath + "/" + rowData[0].ToString() + ".asset";

                //�t�@�C�����̃A�Z�b�g�����邩�ǂ����ŕ���
                EventData datas = null;
                if (File.Exists(filePath))
                {
                    //����Ȃ�X�V�̂��߂ɓǍ���
                    datas = AssetDatabase.LoadAssetAtPath<EventData>(filePath);
                }
                else
                {
                    //�Ȃ���ΐV�K�쐬
                    datas = ScriptableObject.CreateInstance<EventData>();
                    AssetDatabase.CreateAsset(datas, filePath);
                }

                //Excel�̃f�[�^����X�e�[�^�X��int�ϊ����Đݒ�
                datas.SetEventData(
                    int.Parse(rowData[1].ToString()),
                              rowData[2].ToString(),
                              rowData[3].ToString(),
                              rowData[4].ToString(),
                              rowData[5].ToString(),
                              rowData[6].ToString(),
                              rowData[7].ToString(),
                    int.Parse(rowData[8].ToString()),
                              rowData[9].ToString(),
                    int.Parse(rowData[10].ToString()),
                              rowData[11].ToString(),
                    int.Parse(rowData[12].ToString())
                    );

                //�t�@�C���̍X�V�t���O�𗧂Ă�
                EditorUtility.SetDirty(datas);
            }
            //�A�Z�b�g�̕ۑ�
            AssetDatabase.SaveAssets();
        }
    }
}
