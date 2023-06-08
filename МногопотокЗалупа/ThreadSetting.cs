using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МногопотокЗалупа
{
    internal abstract class ThreadSetting
    {
        protected static List<FileInfo> list = new List<FileInfo>(){
            new FileInfo("File1.txt"),
            new FileInfo("File2.txt"),
            new FileInfo("File3.txt")};

        protected Random random = new Random();

        protected bool isStoped = false;

        public bool IsStoped { get; set; }

        protected delegate void textHandler();

        protected FileInfo getFile()
        {
            return list[random.Next(list.Count)];

        }   
    }
}


        //Писать две строки в конец файла 	
        //Удалить три последние строки  из файла 	
        //Не писать строки, если в файле более 7 строк