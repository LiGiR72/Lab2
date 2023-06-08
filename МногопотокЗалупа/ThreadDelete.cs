using System.Windows.Forms;

namespace МногопотокЗалупа
{
    internal class ThreadDelete : ThreadSetting
    {
        Form1 form = Form1.getForm();

        public void Start()
        {
            for(int i = 0; i < 10 ; i++)
            {
                Run();
                Thread.Sleep(500);
            }
        }

        public void Run()
        {
            List<string> fileText;
            FileInfo file = getFile();
            lock (file)
            {
                form.changeColor(file.Name, false);
                form.Label2("Работает");
                Thread.Sleep(500);
                FileStream fs = file.Open(FileMode.OpenOrCreate);
                StreamReader reader = new StreamReader(fs);
                fileText = reader.ReadToEnd().TrimEnd().Split('\n').ToList();
                for (int i = 0; i < 3; i++)
                {
                    if (fileText.Count == 0)
                        break;
                    fileText.RemoveAt(fileText.Count - 1);
                }
                reader.Close();
                fs.Close();
                FileStream fs1 = file.Open(FileMode.Create);
                StreamWriter writer = new StreamWriter(fs1);
                for (int i = 0; i < fileText.Count(); i++)
                {
                    writer.WriteLine(fileText[i]);
                }
                Thread.Sleep(500);
                writer.Dispose();
                fs.Dispose();
                form.changeColor(file.Name, true);
                form.Label2("Ожидает");
            }
        }
    }
}
