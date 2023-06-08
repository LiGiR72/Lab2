namespace МногопотокЗалупа
{
    internal class ThreadWrite : ThreadSetting
    {

        Form1 form = Form1.getForm();
        public void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                Run();
                Thread.Sleep(500);
            }
        }
        public void Run()
        {
            FileInfo file = getFile();
            lock (file)
            {
                form.changeColor(file.Name, false);
                form.Label1("Работает");
                Thread.Sleep(500);
                FileStream fs = file.Open(FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(fs);
                StreamReader reader = new StreamReader(fs);
                if (Check(reader))
                {
                    writer.WriteLine("СТРОООООООООООООКА");
                    writer.WriteLine("СТРООООООООООООООООООООООООООКА");
                }
                Thread.Sleep(500);
                writer.Dispose();
                reader.Dispose();
                fs.Dispose();
                form.changeColor(file.Name, true);
                form.Label1("Ожидает");
            }
        }

        private bool Check(StreamReader sr)
        {
            int count = 0;

            while (true)
            {
                if (sr.ReadLine() != null)
                {
                    count++;
                    continue;
                }
                break;
            }

            if (count >= 7)
            {
                return false;
            }

            return true;
        }
    }
}
