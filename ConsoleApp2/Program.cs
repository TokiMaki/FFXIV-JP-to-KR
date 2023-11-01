using Newtonsoft.Json;

// 네이버 Papago NMT API 예제
using System;
using System.Net;
using System.Text;
using System.IO;
using System.Numerics;

Console.WriteLine("Hello, World!");
string[] koFiles = { "", };
string[] jpFiles = { "", };
string[] backupjpFiles = { "", };
;
string[] clientID = { "0yIjmTIHgY55gV0YLn1t",
    "1diyex9YS4dgzlB4snbH",
    "3N0APG6TUX8hFTMYXkW1",
    "4jnBi_joxX0RUCJStA8V",
    "4npNPAJSnHQourFgo16s",
    "4nuw6WIXPZawZUp4XPUq",
    "5sRHBiRovInXCBFIccb8",
    "6cy6BqujgRGKjFfvWPAa",
    "ArIK2vwVeaXt2jERXIQe",
    "C_TjTzOMxJDusPlpA0G6",

    "DE2Sn2t2mdjZJdfBwIaK",
    "L4JcTAI6uFlKK6v_5V_y",
    "M7ekziJClHVhdBabApjb",
    "QsNibmVqNQfx8QUokGLC",
    "T5HGlE2pD6tC6ZGQTccc",
    "WVMN7iNlIGlZOs_DHu4q",
    "XhHrCRKJIUfh8SXsMryr",
    "Y0pD2EI7drmypH_X8_hV",
    "YwxqUN4TPwle3IgFcjvy",
    "_9qx1l45xZUsaTEyOfwA",

    "dOJcRXWnKMHZSMK6SeQU",
    "e0heVQPWMTTVljk4TKKF",
    "eYtSYfTNIOPEVbaqX1L9",
    "iTwQvWbWSpb97nno44KU",
    "k8Jje3tKYd5CFEcLf0Cp",
    "lSoKofubO0SRQwdlv6oz",
    "pTQw95RNKpODV5hPNzG6",
    "rsCsg3WAf_bKUh6b7wnj",
    "rxJChoV7thHZ8NEa9T0c",
    "w28Oyv_sY0c6mo_8i26M",

    "wLi4fGTILfP5OWh0zBKg",
    "zLfczRfmNPBll4tJyEWL",
    "zaRGBsPKQTztCLQe0Kw5",
    
    //--------------------------------------------

    "AgFZ3YzGty6w3CeaCVeB",
    "BRpBPXrsyDxpA0GNSNjQ",
    "CGxaLwb0nOAVYkTleK4i",
    "E8Km52WjoYIdvwUm3Tdd",
    "LhdwfS8LuVnWum8fr_um",
    "No3u8q7cAl75XvO5aSoy",
    "PqbfNBDaZAll7GhsQEM0",
    "Rryc81OR3PQYBV9q2pYq",
    "dd1pFFlARfLCB_ivOQgM",
    "zimG6sulUits1n95ZG5D",

    //--------------------------------------------
    
    "1exj1JukygGxKyynDcTt",
    "1flFyuQVE3HjOBdSfweX",
    "2NEqe5ybmyBwWyyqq85e",
    "47UKEG1LxgSxogS5csCJ",
    "8IJbktFUrXOmVIntbOE4",
    "Aoe_cUiOnQldX3A4YbZA",
    "GPILTauOWOjta5wGBQMU",
    "IFxvx_Ac_6H1kE46stWU",
    "JGVp8DEQdmbjxm_qiF4b",
    "Kt6m0OPY1kmsCSfzfYY9",

    "Kt75qBCOyRCyKCgS4CCP",
    "L9MFTWELA8zQwIpw3uGf",
    "OThuT12jZwVSLoEJXvWi",
    "SizDaISeqL3EN1u8ZADi",
    "YsD5wz6OpTw1y_dI3_g3",
    "a3Q1LRG7OX_1i87S8R1K",
    "bG3yF6PHIiSqzy0OVjsf",
    "dged1mJP6g2d6_TlkvpW",
    "e4l8t3JF2TMOF0hwbUK_",
    "eAVrMkpanTUIBi7JqvTI",

    "eqBxCajwlxI4C1ImTAgt",
    "fxGYhTHgFeWOEqd0wUIr",
    "jKGZTyCT6ngHxfgebvBK",
    "mZLWBtb2PIlkJNm0R5kB",
    "tBV9YZSLKZh3ASkbZ2Za",
    "tSYLmJOd1LgXiCncAAcF",
    "zP2fIOw3fg_O9QgrLKIF",



};
string[] clientSecret = { "csv0AFQpS4",
    "2A8viQI3Uz",
    "MRo6YpNwIW",
    "r9A9YAfqOD",
    "aruuu7ppqW",
    "sUm3rrNbhz",
    "4CWE9lXdZl",
    "ac190n0Gi3",
    "Ua4ShEnQZX",
    "NxJhmzaIh8",

    "MBUm0h9whK",
    "4HJGla6gS9",
    "bDQCluolM1",
    "grCrlBQv77",
    "NlaHGBpnPq",
    "awTX2eex0I",
    "2f6ZFVqKoA",
    "KdpgEK2nC2",
    "_tWle22lro",
    "xQvJmWi3tY",

    "dh730jgseD",
    "sJ9pIFluVT",
    "1VwZ1cI7DO",
    "CCZfecfm6o",
    "CbXlR7rW2J",
    "wOGUdjsKpa",
    "Rsetczj3Xm",
    "s5JxZ4ttvy",
    "e1cR6wyIcA",
    "mrpNGlzS4j",

    "xVAiWoVVYZ",
    "Qz0t0_fNyF",
    "5rAD3vuPwc",

    //--------------------------------------------

    "HMj_oCr_wH",
    "QTvJHB5yP8",
    "o7paGKa4xw",
    "nS7b7rdZ34",
    "pwtFNUYM4q",
    "nxTjBonAs1",
    "P1Pq_FrKxD",
    "48Sh7laO1O",
    "bTwpgoLQop",
    "YFpQcMWRxM",

    //--------------------------------------------
    
    "sX5ssivBDF",
    "TstF_x_B4z",
    "p62aZBULfZ",
    "VDnVsOEmcv",
    "0sUVR98aQc",
    "usa0OYnuPf",
    "43TsGl99Pm",
    "oRSv3JrJcU",
    "BZgsE6JIBG",
    "P2g7ZdxMBj",

    "czg1mEMKk6",
    "bD2W8VVgYV",
    "4F6XobkXV9",
    "zAYHolo8da",
    "7WBXBpbJd2",
    "T6H_x0iVCO",
    "7tiYP7eO1P",
    "E4sW3fNeVO",
    "aLsnciZIFU",
    "Cl0c519Baf",

    "PheQ0tgKCe",
    "vS7dTk2lkl",
    "vhFI8ZawF1",
    "oXyDwqPGQT",
    "B0_UhULQFi",
    "r3rfP90UrN",
    "UDePl1Jgn0",

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
        if (query.Contains("、"))
            query = query.Replace("、", ", ");
        query = query.Replace("%", "パーセント");
        query = query.Replace("。", ". ");
        query = query.Replace("「", "\'");
        query = query.Replace("」", "\'");
        query = query.Replace("『", "\"");
        query = query.Replace("』", "\"");
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
    catch (Exception ex)
    {
        if (ex.Message.Contains("429"))
        {
            Translatecount++;
            return PapagoTranslate(TranslateText);
        }
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
                if (jp.Fields.Count != target.Fields.Count) continue;
                for (int i = 0; i < target.Fields.Count; i++)
                {
                    if (jp.Fields[i].FieldValue.Count != target.Fields[i].FieldValue.Count) continue;
                    for (int j = 0; j < target.Fields[i].FieldValue.Count; j++)
                        if (jp.Fields[i].FieldValue.Any()
                            && jp.Fields[i].FieldValue[j].EntryType == "text"
                            && target.Fields[i].FieldValue[j].EntryType == "text")
                        {
                            if (iskoCheck(target.Fields[i].FieldValue[j].EntryValue.ToString()))
                            {
                                jp.Fields[i].FieldValue[j].EntryValue = target.Fields[i].FieldValue[j].EntryValue;
                            }
                        }
                }
            }
        }
        Console.WriteLine(loop + "/" + jpFiles.Length);
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
                        if (isjpCheck(jp.Fields[i].FieldValue[j].EntryValue.ToString()) && iskoCheck(jp.Fields[i].FieldValue[j].EntryValue.ToString()))
                        {
                            string PapagoTranslateTextString =
                                PapagoTranslate(jp.Fields[i].FieldValue[j].EntryValue.ToString());
                            if (PapagoTranslateTextString != null)
                            {
                                if (jpTargetFilePath.Contains("Item"))
                                {
                                    Console.WriteLine(jp.Fields[i].FieldValue[j].EntryValue + " -> " +
                                                      PapagoTranslateTextString);
                                    jp.Fields[i].FieldValue[j].EntryValue +=
                                        " " + jp.Fields[i].FieldValue[j].EntryValue.ToString();
                                }
                                else
                                {
                                    Console.WriteLine(jp.Fields[i].FieldValue[j].EntryValue + " -> " +
                                                      PapagoTranslateTextString);
                                    jp.Fields[i].FieldValue[j].EntryValue = PapagoTranslateTextString;
                                }
                            }
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


void JPtoWritingSystem()
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
                        jp.Fields[i].FieldValue[j].EntryValue =
                            jp.Fields[i].FieldValue[j].EntryValue.ToString().Replace("퍼센트", "%");
                        jp.Fields[i].FieldValue[j].EntryValue =
                            jp.Fields[i].FieldValue[j].EntryValue.ToString().Replace("에스티니안", "에스티니앙");
                        jp.Fields[i].FieldValue[j].EntryValue = 
                            jp.Fields[i].FieldValue[j].EntryValue.ToString().Replace("야 슈트라", "야슈톨라");
                        jp.Fields[i].FieldValue[j].EntryValue = 
                            jp.Fields[i].FieldValue[j].EntryValue.ToString().Replace("우리엔제", "위리앙제");
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
//JPtobackupJP();
JPtoPapagoKR();
//JPtoWritingSystem();
//JPtoWritingSystem();
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
