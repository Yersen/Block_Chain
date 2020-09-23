using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    /// <summary>
    /// цепочка блоков
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// все блоки
        /// </summary>
        public List<Block> Blocks { get; private set; }
        /// <summary>
        /// последний добавленный блок
        /// </summary>
        public Block Last { get; private set; }


        /// <summary>
        /// создание новой цепочки
        /// </summary>
        public Chain()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();
            Blocks.Add(genesisBlock);
            Last = genesisBlock;
        }

        /// <summary>
        /// добавить блок 
        /// </summary>
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
        }
    }
}
