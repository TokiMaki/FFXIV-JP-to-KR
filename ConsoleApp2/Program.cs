using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string[] koFiles = { "",};
string[] jpFiles = { "", };
try
{
    koFiles = Directory.GetFiles("output kor", "ko", SearchOption.AllDirectories);
} catch (IOException ex){ 
    Console.WriteLine(ex.Message);
    return;
}
try
{
    jpFiles = Directory.GetFiles("output", "ja", SearchOption.AllDirectories);
}
catch (IOException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
foreach (string koFile in koFiles)
{
    string koFilePath = koFile;
    string koTargetFilePath = koFilePath.Substring(10);
    koTargetFilePath = koTargetFilePath.Substring(0, koTargetFilePath.Length - 3);
    string jpFilePath = "";

    int loop = 0;
    foreach (string jpFile in jpFiles)
    {
        jpFilePath = jpFile;
        string jpTargetFilePath = jpFilePath.Substring(6);
        jpTargetFilePath = jpTargetFilePath.Substring(0, jpTargetFilePath.Length - 3);
        if(jpTargetFilePath == koTargetFilePath)
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
            for(int i = 0; i < target.Fields.Count; i++)
            {
                jp.Fields[i].FieldValue = target.Fields[i].FieldValue;
            }
        }
    }
    string output = JsonConvert.SerializeObject(jpDataList, Formatting.Indented);
    FileStream fs = File.Create(jpFilePath);
    fs.Close();
    if (File.Exists(jpFilePath))
        File.WriteAllText(jpFilePath, output);
}


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

