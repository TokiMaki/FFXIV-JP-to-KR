using Newtonsoft.Json;

// 네이버 Papago NMT API 예제
using System;
using System.Net;
using System.Text;
using System.IO;

Console.WriteLine("Hello, World!");
string[] koFiles = { "", };
string[] jpFiles = { "", };
string[] backupjpFiles = { "", };
string[] clientID = { "92Sphm95Rb3BovoOoocL",
    "QENw_ceZhxwbP65RKJKD",
    "HyNx0lOiEyj6xBfYNByk",
    "KVP8mrJViAbOSCHUpU6V",
    "_3tAHggjENRP5pG_V59o",
    "7r2egzcSdZAH3lz4JZMM",
    "sPGZS6HX_te6YlBadUJc",
    "VBpAKKqyd0gpeBsKUxTr",
    "B1pFC5eUEUW4xngjn1Xv",
    "nU407q3GZKGhm4FMYOfU",

    "dS9JKz5j2h9pDyU6BloN",
    "ZC1nGrkZ5jlUWXjsyXod",
    "jWnFNiNlxrgn00sl9A_M",
    "utzCAk9AbPRZku7HUW1A",
    "BP1jMiY36srLlIRKAdwm",
    "wqnajSiJB5TBmfOQgKBT",
    "yOhgWvInFGgpv7gsNojY",
    "Ij8TzF67n9U66TLMq1o0",
    "VS4nZfRMH13jcCOG2m82",
    "TU9ChoOEyJfHkjOUrBvq",

    "XnNxq1eTAa8zA6yhXhqx",
    "aGfBqWotnUOWrSEQDa5I",
    "GNkd4T7gHba39Cczhzqc",
    "xSG0ieO2tE9IM9JO7Fu_",
    "uKO_jA5KoFKyZrolPjaG",
    "XG9DJzhiyVGIMrYAN7VF",
    "yoh4Myi0K_viycx4RxW7",
    "7dGExnbHazO2GyB7lYDM",
    "TK70XyDRUC3YWZJQUCk5",
    "2R7LjXTgd4kbbEdgCDdg",

    "sWb1xMT25BCEpOtH6UtK",
    "vk8oNh63RbEjo8bWx6gs",
    "2kgBrwqQzaR4cuFvfBoF",
    "_oT1bfw4hDsdLXRv9L82",
    "SpT7xSFhTCu_vH4iQ6jr",
    "Fuudtxwi_nxUdKT3KLJX",
    "1_IYCSk985oXidAr7Ui1",
    "LAxjVVUP7RGAqvuvaQbb",
    "_TK3qPkyQS8gvYKU1zhb",
    "SWgpd_yLbt4ACRCSyo1Y",
    };
string[] clientSecret = { "b2coWb9mA1",
    "ZiEIDPzJE6",
    "EmMkVJRt2p",
    "Ot0ioLOh0_",
    "ELTbSdaWAw",
    "pm8jjF5fON",
    "Dtgy34EMEh",
    "dv2mqac7RK",
    "3Nmo39m2GD",
    "qMgQj3tXUc",

    "KUM4SmNhYA",
    "ip_CLzkHHV",
    "a7MuxpYc49",
    "whuM7yUVTO",
    "ImsK1h0Nv8",
    "OZU4NXz329",
    "P9osNFfYww",
    "HbVjSuHvJA",
    "uT2gRQFDRC",
    "ijOtcBVg8o",

    "hp_FFJViUi",
    "GqOkTcDe7S",
    "kg1CRC4kU3",
    "MjWdk2aF1O",
    "2CaLqeB3MC",
    "BhhKXPqneB",
    "VwNrs3CgsG",
    "CActkv3sLm",
    "atRrpEDzSp",
    "yCo2I9HmWt",

    "lmS4VIrWhV",
    "FJ2GMysfiD",
    "nrmUAag6N8",
    "bLjMFiGDlP",
    "5RwLe2RGpI",
    "YnHqfxbVME",
    "5G5NDF2brO",
    "mzwN7tpjny",
    "CbXEEEIKoo",
    "_lILYRIEQ7",
    };
int Translatecount = 0;

bool isjpCheck(string str)
{
    ushort usr = BitConverter.ToUInt16(Encoding.Unicode.GetBytes(str), 0);

    if ((usr >= 13312 && usr <= 19903) ||
            (usr >= 19968 && usr <= 40895) ||
            (usr >= 63744 && usr <= 64255) ||
            (usr >= 12352 && usr <= 12447) ||
            (usr >= 12448 && usr <= 12543))
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool iskoCheck(string str)
{
    char[] charArr = str.ToCharArray();
    foreach (char c in charArr)
    {
        if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
        {
            return true;
        }
    }
    return false;
}

string PapagoTranslate(string TranslateText)
{
    try
    {
        string url = "https://openapi.naver.com/v1/papago/n2mt";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("X-Naver-Client-Id", clientID[Translatecount]);
        request.Headers.Add("X-Naver-Client-Secret", clientSecret[Translatecount]);
        request.Method = "POST";
        string query = TranslateText;
        byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ja&target=ko&text=" + query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteDataParams.Length;
        Stream st = request.GetRequestStream();
        st.Write(byteDataParams, 0, byteDataParams.Length);
        st.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        Papago myDeserializedClass = JsonConvert.DeserializeObject<Papago>(reader.ReadToEnd());
        string text = reader.ReadToEnd();
        stream.Close();
        response.Close();
        reader.Close();
        Console.WriteLine(text);
        return myDeserializedClass.message.result.translatedText;
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        //Translatecount++;
        //return PapagoTranslate(TranslateText);
        Environment.Exit(0);
        return null;
    }
}

void JPtoKR()
{
    try
    {
        koFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ko", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    try
    {
        jpFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ja", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    foreach (string koFile in koFiles)
    {
        string koFilePath = koFile;
        string koTargetFilePath = koFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
        koTargetFilePath = koTargetFilePath.Substring(0, koTargetFilePath.Length - 5);
        string jpFilePath = "";

        int loop = 0;
        foreach (string jpFile in jpFiles)
        {
            jpFilePath = jpFile;
            string jpTargetFilePath = jpFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
            jpTargetFilePath = jpTargetFilePath.Substring(0, jpTargetFilePath.Length - 5);
            if (jpTargetFilePath == koTargetFilePath)
            {
                break;
            }
            loop++;
        }
        if (loop >= jpFiles.Length) continue;


        StreamReader jpsr = new StreamReader(jpFilePath);
        string jpData = jpsr.ReadToEnd();
        jpsr.Close();
        List<datamodel> jpDataList = JsonConvert.DeserializeObject<List<datamodel>>(jpData);

        StreamReader kosr = new StreamReader(koFilePath);
        string koData = new StreamReader(koFilePath).ReadToEnd();
        kosr.Close();
        List<datamodel> koDataList = JsonConvert.DeserializeObject<List<datamodel>>(koData);

        foreach (var jp in jpDataList)
        {
            var target = koDataList.Find(x => jp.Key == x.Key);
            if (target != null)
            {
                for (int i = 0; i < target.Fields.Count; i++)
                {
                    for (int j = 0; j < target.Fields[i].FieldValue.Count; j++)
                        if (target.Fields[i].FieldValue[j].EntryType == "text")
                            jp.Fields[i].FieldValue[j].EntryValue = target.Fields[i].FieldValue[j].EntryValue;
                }
            }
        }
        string output = JsonConvert.SerializeObject(jpDataList, Formatting.Indented);
        FileStream fs = File.Create(jpFilePath);
        fs.Close();
        if (File.Exists(jpFilePath))
            File.WriteAllText(jpFilePath, output);
    }
}

void JPtoPapagoKR()
{
    try
    {
        jpFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ja", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    foreach (string jpFile in jpFiles)
    {
        string jpFilePath = jpFile;
        string jpTargetFilePath = jpFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
        jpTargetFilePath = jpTargetFilePath.Substring(0, jpTargetFilePath.Length - 5);

        StreamReader jpsr = new StreamReader(jpFilePath);
        string jpData = jpsr.ReadToEnd();
        jpsr.Close();
        List<datamodel> jpDataList = JsonConvert.DeserializeObject<List<datamodel>>(jpData);

        foreach (var jp in jpDataList)
        {
            for (int i = 0; i < jp.Fields.Count; i++)
            {
                for (int j = 0; j < jp.Fields[i].FieldValue.Count; j++)
                    if (jp.Fields[i].FieldValue[j].EntryType == "text")
                    {
                        string PapagoTranslateTextString = PapagoTranslate(jp.Fields[i].FieldValue[j].EntryValue.ToString());
                        if (jpTargetFilePath.Contains("Item"))
                            jp.Fields[i].FieldValue[j].EntryValue += "" + jp.Fields[i].FieldValue[j].EntryValue.ToString();
                        else
                            jp.Fields[i].FieldValue[j].EntryValue = PapagoTranslateTextString;
                    }
            }
        }
        string output = JsonConvert.SerializeObject(jpDataList, Formatting.Indented);
        FileStream fs = File.Create(jpFilePath);
        fs.Close();
        if (File.Exists(jpFilePath))
            File.WriteAllText(jpFilePath, output);
    }
}

void JPtoBackup()
{
    try
    {
        jpFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ja", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    foreach (string jpFile in jpFiles)
    {
        string jpFilePath = jpFile;
        string jpTargetFilePath = jpFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
        jpTargetFilePath = jpTargetFilePath.Substring(0, jpTargetFilePath.Length - 5);

        StreamReader jpsr = new StreamReader(jpFilePath);
        string jpData = jpsr.ReadToEnd();
        jpsr.Close();
        List<datamodel> jpDataList = JsonConvert.DeserializeObject<List<datamodel>>(jpData);

        string output = JsonConvert.SerializeObject(jpDataList, Formatting.Indented);
        FileStream fs = File.Create(jpFilePath + "1");
        fs.Close();
        if (File.Exists(jpFilePath + "1"))
            File.WriteAllText(jpFilePath + "1", output);
    }
}

void JPtobackupJP()
{
    try
    {
        backupjpFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ja1", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    try
    {
        jpFiles = Directory.GetFiles("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd", "ja", SearchOption.AllDirectories);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    foreach (string BackupjpFile in backupjpFiles)
    {
        string BackupjpFilePath = BackupjpFile;
        string BackupjpTargetFilePath = BackupjpFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
        BackupjpTargetFilePath = BackupjpTargetFilePath.Substring(0, BackupjpTargetFilePath.Length - 6);
        string jpFilePath = "";

        int loop = 0;
        foreach (string jpFile in jpFiles)
        {
            jpFilePath = jpFile;
            string jpTargetFilePath = jpFilePath.Substring("C:\\Users\\gustj\\Desktop\\유틸리티\\파판14 한글패치\\AllaganNode\\output\\exd".Length + 1);
            jpTargetFilePath = jpTargetFilePath.Substring(0, jpTargetFilePath.Length - 5);
            if (jpTargetFilePath == BackupjpTargetFilePath)
            {
                break;
            }
            loop++;
        }
        if (loop >= jpFiles.Length) continue;


        StreamReader jpsr = new StreamReader(jpFilePath);
        string jpData = jpsr.ReadToEnd();
        jpsr.Close();
        List<datamodel> jpDataList = JsonConvert.DeserializeObject<List<datamodel>>(jpData);

        StreamReader Backupjpsr = new StreamReader(BackupjpFilePath);
        string BackupjpData = new StreamReader(BackupjpFilePath).ReadToEnd();
        Backupjpsr.Close();
        List<datamodel> BackupjpDataList = JsonConvert.DeserializeObject<List<datamodel>>(BackupjpData);

        foreach (var jp in jpDataList)
        {
            var target = BackupjpDataList.Find(x => jp.Key == x.Key);
            if (target != null)
            {
                for (int i = 0; i < target.Fields.Count; i++)
                {
                    for (int j = 0; j < target.Fields[i].FieldValue.Count; j++)
                    {
                        if (target.Fields[i].FieldValue[j].EntryType == "text")
                            if (!BackupjpTargetFilePath.Contains("Item"))
                                jp.Fields[i].FieldValue[j].EntryValue = target.Fields[i].FieldValue[j].EntryValue;
                    }
                }
            }
        }
        string output = JsonConvert.SerializeObject(jpDataList, Formatting.Indented);
        FileStream fs = File.Create(jpFilePath);
        fs.Close();
        if (File.Exists(jpFilePath))
            File.WriteAllText(jpFilePath, output);
    }
}

//JPtoKR();
JPtobackupJP();
Console.WriteLine("F");

public class datamodel
{
    public int Key { get; set; }
    public int Offset { get; set; }
    public int Size { get; set; }
    public int CheckDigit { get; set; }
    public List<Field> Fields { get; set; }
}


public class Field
{
    public int FieldKey { get; set; }
    public List<FieldValue> FieldValue { get; set; }
}

public class FieldValue
{
    public string EntryType { get; set; }
    public object EntryValue { get; set; }
}
public class Message
{
    public Result result { get; set; }

    [JsonProperty("@type")]
    public string Type { get; set; }

    [JsonProperty("@service")]
    public string Service { get; set; }

    [JsonProperty("@version")]
    public string Version { get; set; }
}

public class Result
{
    public string srcLangType { get; set; }
    public string tarLangType { get; set; }
    public string translatedText { get; set; }
    public string engineType { get; set; }
    public object pivot { get; set; }
    public object dict { get; set; }
    public object tarDict { get; set; }
}

public class Papago
{
    public Message message { get; set; }
}
