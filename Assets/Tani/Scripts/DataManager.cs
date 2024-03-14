using System.IO;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    [HideInInspector] public SaveData data;     // json�ϊ�����f�[�^�̃N���X
    string filepath;                            // json�t�@�C���̃p�X
    string fileName = "Data.json";              // json�t�@�C����

    //-------------------------------------------------------------------
    // �J�n���Ƀt�@�C���`�F�b�N�A�ǂݍ���
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        // �p�X���擾
        filepath = Application.dataPath + "/Tani/Saves/" + fileName;
    }
    private void Start()
    {
        

        //// �t�@�C�����Ȃ��Ƃ��A�t�@�C���쐬
        //if (!File.Exists(filepath))
        //{
        //    Save(data);
        //}

        //// �t�@�C����ǂݍ����data�Ɋi�[
        //data = Load(filepath);
    }
    //-------------------------------------------------------------------
    // json�Ƃ��ăf�[�^��ۑ�
    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);                 // json�Ƃ��ĕϊ�
        StreamWriter wr = new StreamWriter(filepath, false);    // �t�@�C���������ݎw��
        wr.WriteLine(json);                                     // json�ϊ�����������������
        wr.Close();                                             // �t�@�C������
    }

    // json�t�@�C���ǂݍ���
    public SaveData Load()
    {
        StreamReader rd = new StreamReader(filepath);               // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<SaveData>(json);            // json�t�@�C�����^�ɖ߂��ĕԂ�
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