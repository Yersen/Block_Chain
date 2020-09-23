using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    /// <summary>
    /// Блок данных
    /// </summary>
    public class Block
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int Id { get;private set; }
        /// <summary>
        /// данные
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Created { get; private set; }
        /// <summary>
        /// хэш блока
        /// </summary>
        public string Hash { get; private set; }
        /// <summary>
        /// предыдущий хэш блока
        /// </summary>
        public string PreviousHash { get; private set; }
        /// <summary>
        /// имя пользователь
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// конструкто генезис блока
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Hello,World";
            Created = DateTime.Parse("23/09/2020 00:00:00.000");
            PreviousHash = "111111";
            User = "Admin";

            var data = GetData();
            var hash = GetHash(data);
        }
        /// <summary>
        /// Конструктор блока
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="block"></param>
        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException($"Пустой аргумент {data}", nameof(data));
            }

            if(block == null)
            {
                throw new ArgumentNullException("Пустой аргумент block", nameof(block));
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException($"Пустой аргумент {user}", nameof(user));
            }
            Data = data;
            User = user;
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;

            var blockData = GetData();
            var hash = GetHash(data);
        }

        /// <summary>
        /// получение значимых данных 
        /// </summary>
        /// <returns></returns>
        private string GetData()
        {
            string result = "";
            result += Id.ToString();
            result += Data;
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PreviousHash;
            result += User;

            return result;
        }
        /// <summary>
        /// хэширование данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetHash(string data)//алгоритм хэширования
        {
            var message = Encoding.ASCII.GetBytes(data);
            var hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);//хэширование сообщения
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;//выводим в 16-ом формате
        }
        public override string ToString()
        {
            return Data;
        }
    }
}
