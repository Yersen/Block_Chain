﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Chain _chain = new Chain();

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var block in _chain.Blocks)
            {
                listBox1.Items.Add(block);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            _chain.Add(textBox1.Text, "Admin");
            foreach (var block in _chain.Blocks)
            {
                listBox1.Items.Add(block);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
