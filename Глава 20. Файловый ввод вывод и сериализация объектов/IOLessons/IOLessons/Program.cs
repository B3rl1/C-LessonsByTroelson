using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IOLessons
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DirectoryInfo
            //DirectoryInfo dir = new DirectoryInfo(@"W:\");
            //dir.CreateSubdirectory(@"MyFolder"); Создание подкаталога. В случае успешного выполнения возвращается объект типа DirectoryInfo.

            //Directory - тот же самый класс, но работает не на уровне экземпляра. 
            //Его статические члены полностью повторяют работу членов класс DirectoryInfo

            //foreach(var d in Directory.GetLogicalDrives())
            //{
            //    Console.WriteLine(d);
            //} //Вывести все логические диски.

            //Directory.Delete("...", true); - Удаление подкаталога. 2 параметр - удалять ли внутренние подкаталоги

            //foreach(var d in DriveInfo.GetDrives())
            //{
            //    //Данный класс предоставляет метод, который даёт расширенную информацию о дисках, нежели Directory.GetLogicalDrives()
            //    Console.WriteLine(d.Name + " " + d.TotalFreeSpace + " " + d.TotalSize + " " + d.RootDirectory + " " + d.IsReady);
            //}
            #endregion

            #region FileInfo
            //FileInfo f = new FileInfo(@"W:\Test.dat");
            //FileStream fs = f.Create(); // f.Create вовзращает объект типа FileStream, который позволяет записывать/читать лежащий в основе файл(синх и асинх)
            //Также при окончании работы с файлом нужно закрыть FileStream, и освободить внутренние неуправляемые ресурсы потока.
            //using (FileStream fs = f.Create())
            //{
            //Что-то делаем с объектом FileStream.
            //}

            //FileInfo f2 = new FileInfo(@"W:\Test1.dat");
            //using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            //{
            //Метод Open, позволяет открывать файл, а также создавать новый файл с большей точностью представления.
            //FileMode
            //  CreateNew - создание файла, если существует, то исключение IOException.
            //  Create - создание файла, если существует, то перезаписан
            //  Open - открытие файла, если не существует, то исключение FileNotFoundException.
            //  OpenOrCreate - открыть файл, в противном случае создать.
            //  Truncate - открывает файл и усекает его до нулевой длины.
            //  Append - открытие файла, и запись с конца, если не существует, то создаёт.
            //...
            //}
            //FileInfo f3 = new FileInfo(@"W:\Test1.dat");
            //using (FileStream fs3 = f3.OpenRead())
            //{
            //    //f3.OperWrite)//Эти методы возрващают уже сконфигурированный только для чтения или записи объект FileStream.
            //}

            //using (StreamReader fs3 = f3.OpenText())
            //{ 
            //    //Метод, возвращающий экземпляр StreamReader.
            //}

            //using (StreamWriter sw1 = f3.CreateText())
            //{
            //    //Метод, возвращающий экземпляр StreamWriter, и предоставляет способ записи данных в файл
            //}
            //using (StreamWriter sw2 = f3.AppendText())
            //{
            //    //Метод, возвращающий экземпляр StreamWriter, и предоставляет способ записи данных в файл
            //}
            //----------------------------------------------------------
            #endregion

            #region File
            //В данном классе представлен почти такой же функционал как и в классе FileInfo, но на уровне класса.
            //Также в нем предоставляеются члены, которые могут упростить жизнь
            //  ReadAllBytes(массив байтов)/ReadAllLines(массив строк)/ReadAllText(строковый формат)
            //  WriteAllBytes()/WriteAllLines()/WriteAllText()
            //Преимущество FileInfo в том, что при создании экземпляра, появляется возможность сбора сведений о файле с помощью класса FileSystemInfo
            //----------------------------------------------------------
            #endregion

            #region Stream
            //Stream(поток) - порция данных, протекающая между источником и приемником. Они предоставляют общий способ взаимодействия
            //с последовательностью байтов.
            // CanRead/CanWrite/CanSeek - поддерживает ли данный поток чтение/запись/поиск.
            // Close() - закрытие потока и освобождение ресурсов(закрытие потока = освобождению потока)
            // Flush() - обновляет лежащий в основе источник данных или хранилище текущим состоянием буфера и затем очищает буфер.
            // Length - длина потока в байтах
            // Position - текущая позиция в потоке
            // Read()/ReadByte()/ReadAsync() - чтение из текущего потока
            // Seek() - установка позиции в потоке.
            // SetLength() - установка длины текущего потока.
            // Write()/WriteByte()/WriteAsync() - запись в текущий поток и перемещение текущей позиции на количество записанных байт.
            //----------------------------------------------------------
            #endregion

            #region FileStream
            //Может записывать/считывать только один байт или поток байтов. На практике встречаться будет редко, скорее всего будут использованы
            //"оболочки" для потоков. 

            //using(FileStream fss = File.Open(@"W:\MyMessage.dat", FileMode.Create))
            //{
            //    string msg = "Hello!";
            //    byte[] byteMsg = Encoding.Default.GetBytes(msg);

            //    fss.Write(byteMsg, 0, byteMsg.Length);
            //    fss.Position = 0;

            //    byte[] byteMsgFromFile = new byte[byteMsg.Length];
            //    for(int i = 0; i < byteMsgFromFile.Length; i++)
            //    {
            //        byteMsgFromFile[i] = (byte)fss.ReadByte();
            //        Console.WriteLine(byteMsgFromFile[i]);
            //    }

            //    Console.WriteLine(Encoding.Default.GetString(byteMsgFromFile));
            //}
            //----------------------------------------------------------
            #endregion

            #region StreamWriter || StreamReader
            //Удобны, когда нужно обрабатывать символьные данные, работают по умолчанию с Unicode. 
            //StreamReader - производный от TextReader. Он предоставляет возможность читать и заглядывать в символьный поток.
            //TextWriter.
            //  Close() - закрывает метод записи и освобождает все связанные с ним ресурсы
            //  Flush() - очищает все буферы текущего средства записи и записывает все буферизированные данные.
            //  NewLine - Константа новой строки.
            //  Write() - Перегруженный метод записывает данные в текстовый поток без добавления константы новой строки.
            //  WriteLine() - Перегруженный метод записывает данные в текстовый поток с добавлением константы новой строки.
            // StreamWriter предоставляет подходяющую реализацию Write() Close() Flush(), а также дополнительное свойство AutoFlush.

            //Запись
            //using (StreamWriter sw1 = File.CreateText(@"W:\test.txt"))
            //{
            //    sw1.WriteLine("Pipka");
            //    sw1.WriteLine("Pipka2");
            //    sw1.WriteLine("Pipka3");

            //    for(int i = 0; i < 5; i++)
            //    {
            //        sw1.Write(i + " ");
            //    }
            //}

            //Чтение
            //TextReader
            //  Peek() - возвращает следующий доступный символ(в виде целого числа). -1 - достижение конца потока.
            //  Read() - читает данные из входного потока
            //  ReadBlock() - читает указанное количество символов, с заданного индекса
            //  ReadLine() - читает строку символов, и возвращает строку.
            //  ReadToEnd() - читает все символы и возвращает их в виде единственной строки.

            //using (StreamReader sr1 = File.OpenText(@"W:\test.txt"))
            //{
            //    string input = null;
            //    while((input = sr1.ReadLine()) != null)
            //    {
            //        Console.WriteLine(input);
            //    }
            //}    

            //----------------------------------------------------------
            #endregion

            #region StringWriter / StringReader
            //Трактовка текстовой информации как потока символов в памяти. 
            //В следующем примере блок строковых данных записывается в объект StringWriter вместо в файл на жестком диске.
            //using (StringWriter sw1 = new StringWriter())
            //{
            //    sw1.WriteLine("Hello World!");
            //    Console.WriteLine(sw1);
            //    //При применении метода GetStringBuilder() - извлекается объект типа StringBuilder.
            //    StringBuilder sb = sw1.GetStringBuilder();
            //    //Когда необходимо прочитать данные из потока строковые данные, можно использовать StringReader.
            //    using (StringReader sr = new StringReader(sw1.ToString()))
            //    {
            //        string input = null;

            //        while((input = sr.ReadLine()) != null)
            //        {
            //            Console.WriteLine(input);
            //        }
            //    }
            //}
            #endregion

            #region BinaryWriter / BinaryReader
            //Позволяют читать и записывать в поток дискретные типы данных в компактном двоичном формате.
            //BinaryWriter 
            //  BaseStream - обеспечивает доступ к лежащему в основе потоку
            //  Close() - закрывает двоичный поток.
            //  Flush() - выталкивает буфер двоичного потока.
            //  Seek() - устанавливает позицию в текущем потоке.
            //  Write() - записывает значение в текущий поток.
            //BinaryReader
            //  BaseStream - обеспечивает доступ к лежащему в основе потоку
            //  Close() - закрывает двоичный поток
            //  PeekChar() - возвращает следующий доступный символ без перемещения текущей позиции потока
            //  Read() - Читает заданный набор байтов или символов и сохраняет их во входном массиве.
            //  ReadXXXX() - ReadByte(), ReadBoolean(), и т.п Извлечение из потока объектов различных типов.

            //FileInfo fi1 = new FileInfo(@"W:\Stats.dat");
            //Возвращение объекта FileStream конструктору объекта BinaryWriter облегчает организацию потока по уровням перед записью данных. 
            //Он принимает любой тип, производный от Stream
            //using (BinaryWriter bw = new BinaryWriter(fi1.OpenWrite()))
            //{
            //    Console.WriteLine(bw.BaseStream);

            //    double Double = 1234.56;
            //    int Int = 34567;
            //    string aString = "A,b,c";

            //    bw.Write(Double);
            //    bw.Write(Int);
            //    bw.Write(aString);
            //}

            //using (BinaryReader br = new BinaryReader(fi1.OpenRead()))
            //{
            //    Console.WriteLine(br.ReadDouble());
            //    Console.WriteLine(br.ReadInt32());
            //    Console.WriteLine(br.ReadString());
            //}
            //----------------------------------------------------------
            #endregion

            #region Программное слежение за файлами
            //FileSystemWatcher - отслеживание состояние файлов в системе.
            //Начало работы - указать Path и в свойстве Filter - расширение отслеживаемых файлов.
            //Обработка событий Changed, Created, Deleted - работаю вместе с делегатом FileSystemEventHandler
            //Этот делегат может вызывать любой метод, который соответствует следующей сигнатуре:
            //void NotificationHandler(object source, FileSystemEventArgs e)
            //Событие Renamed обрабатывается с помощью делегата RenamedEventHandler - void MyRenamedHandler(object source, RenamedEventArgs e)

            #region FileWatcher
            //FileSystemWatcher fsw = new FileSystemWatcher();
            //try
            //{
            //    fsw.Path = @"W:\";
            //}
            //catch(ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //fsw.NotifyFilter = NotifyFilters.LastWrite 
            //    | NotifyFilters.LastAccess
            //    | NotifyFilters.FileName 
            //    | NotifyFilters.DirectoryName;

            //fsw.Filter = "*.txt";

            //fsw.Changed += (object o, FileSystemEventArgs e) =>
            //{
            //    Console.WriteLine(e.FullPath + " " + e.ChangeType);
            //};

            //fsw.Created += (object o, FileSystemEventArgs e) =>
            //{
            //    Console.WriteLine(e.FullPath + " " + e.ChangeType);
            //};

            //fsw.Deleted += (object o, FileSystemEventArgs e) =>
            //{
            //    Console.WriteLine(e.FullPath + " " + e.ChangeType);
            //};

            //fsw.Renamed += (object o, RenamedEventArgs e) =>
            //{
            //    Console.WriteLine(e.OldFullPath + " " + e.FullPath);
            //};

            //fsw.EnableRaisingEvents = true;

            //while (Console.Read() != 'q') ;
            #endregion
            #endregion

            #region Сериализация
            //Сериализация - процесс сохранения состояния объекта в потоке.
            //Пометив класс атрибутом [Serializable], можно сэкономить кучу времени.
            //В итоге следующий код покажет, как легко сохранить состояние в файл.

            PlayerPrefs player = new PlayerPrefs();
            player.Name = "Tom";
            player.HP = 22;

            //Сериализация объектов упрощает сохранение объектов, но ее внутренний процесс довольно сложен. Когда объект сохраняется
            //в потоке, все ассоциированные с ним данные также автоматически сериализуются.
            //Граф объектов может быть сохранен в любом типе производном от System.IO.Stream.
            //Набор связанных объектов предоставляет простой способ документирования взаимосвязи между множеством элементов - граф объектов.
            //Здесь применимы понятия требует и зависит от, а не является и имеет.
            //Каждый объект в графе получает уникальное числовое значение
            //Если мы будем сериализовывать с помозью BinaryFormatter/SoapFormatter, то буду сохранаться все сериализуемые поля типа
            //независимо, являются ли они закрытыми или открытыми.
            //Если использовать XmlSerializer - то он будет сериализовывать только те поля которые открытые, либо закрытые, если они 
            //доступны посредством свойств.
            //Сериализация коллекций объектов.
            //Большинство типов в пространствах имен System.Collections и System.Collections.Generic 
            //уже помечено атрибутом[Serializable]. 
            #region Выбор форматера сериализации
            //Вне зависимости от того какой форматтер выбран, все они наследуются от System.Object, а потому не разделяют общий набор членов.
            //Типы BinaryFormatter и SoapFormatter поддерживают общие члены, благодаря реализации интерфейсов IFormatter и IRemotingFormatter
            //IFormatter - определяет Serialize() и Deserialize(), которые работают с графами объектов помещая или извлекая из потока. 
            //И некторые свойства.
            //IRemotingFormatter - перегружает методы Serialize() и Deserialize()
            #region BinaryFormatter
            //BinaryFormatter - сохранения состояния объекта в поток используя компкатный двоичный формат
            //System.Runtime.Serialisation.Formatters.Binary

            //BinaryFormatter binFormat = new BinaryFormatter();
            ////Сериализация
            //using (Stream stream = new FileStream(@"W:\stats.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    binFormat.Serialize(stream, player);
            //}
            ////Десериализация
            //using (Stream fstream = File.OpenRead(@"W:\stats.dat"))
            //{
            //    PlayerPrefs pf = (PlayerPrefs)binFormat.Deserialize(fstream);
            //    Console.WriteLine(pf.Name + " " + pf.HP);
            //}

            #endregion
            #region SoapFormatter
            //SoapFormatter - сохранение состояния объекта в виде сообщения SOAP(стандартный XML-формат для передачи 
            //и приема сообщений от веб-служб, основанных на SOAP)
            //Находится в другой сборке, нужно добавить ссылку на System.Runtime.Serialization.Formatters.Soap.dll 
            //и добавить с помощью using System.Runtime.Serialization.Formatters.Soap;
            //SoapFormatter soapFormat = new SoapFormatter();
            //using (Stream fstream = new FileStream(@"W:\soap.soap", FileMode.OpenOrCreate))
            //{
            //soapFormat.Serialize(fstream, player);
            //}
            #endregion
            #region XmlSerializer
            //XmlSerializer - сохранение дерева объектов в документе XML. 
            //System.Xml.Serialization
            //Требует наличия стандартного конструктора у сериализуемых типов. (InvalidOperationException)
            //Требует указания информации о типе, который представляет класс.
            //         XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerPrefs));
            //         using (Stream fstream = new FileStream(@"W:\xml.xml", FileMode.OpenOrCreate))
            //{
            //             xmlSerializer.Serialize(fstream, player);
            //}
            //Управление генерацией XML 
            //[XmlAttribute] - поле/свойство. Сериализовать как атрибут XML(не подэлемент)
            //[XmlElement] - поле/свойство. Сериализовать как элемент.
            //[XmlEnum] - атрибут предсоставляет имя элемента члена перечисления
            //[XmlRoot] - как будет сконструирован корневой элемент
            //[XmlText] - свойство/поле. Сериализовать как текст XML
            //[XmlType] - предоставляет имся и пространство имен типа XML
            #endregion
            #endregion
            #region Настройка процесса сериализации SOAP и двоичной сериализации.
            //ISerializable Этот интерфейс может быть реализован типом[Serializable]
            //для управления его сериализацией и десериализацией
            //ObjectIDGenerator Этот тип генерирует идентификаторы для членов в графе объектов
            //[OnDeserialized] Этот атрибут позволяет указать метод, который будет вызван немедленно после десериализации объекта
            //[OnDeserializing] Этот атрибут позволяет указать метод, который будет вызван перед
            //началом процесса десериализации
            //[OnSerialized] Этот атрибут позволяет указать метод, который будет вызван немедленно после того, как объект сериализирован
            //[OnSerializing] Этот атрибут позволяет указать метод, который будет вызван перед
            //началом процесса сериализации
            //[OptionalField] Этот атрибут позволяет определить поле типа, которое может быть
            //пропущено в указанном потоке
            //Serializationlnfо Этот класс является пакетом свойств, который поддерживает пары
            //“имя - значение”, представляющие состояние объекта во время процесса сериализации

            #endregion
            #endregion
        }

        public void OpenFile()
        {
            
        }
    }

    [Serializable, XmlRoot(Namespace = "!!!МОЙ КОД!!!")]
    public class PlayerPrefs
    {
        public string Name { get; set; }
        public int HP { get; set; }
    }

    [Serializable]
    public class Human
    {
        public PlayerPrefs pp = new PlayerPrefs();
        public int Age { get; set; }
    }

    [Serializable]
    public class UFO : Human
    {
        public bool isUFO { get; set; }
    }
}
