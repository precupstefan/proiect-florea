using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace ProiectFlorea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

            string oldText =  @"We the people
                of the united states of america
                establish justice
                ensure domestic tranquility
                provide for the common defence
                secure the blessing of liberty
                to ourselves and our posterity";
            string newText = @"We the peaple
                in order to form a more perfect union
                establish justice
                ensure domestic tranquility
                promote the general welfare and
                secure the blessing of liberty
                to ourselves and our posterity
                do ordain and establish this constitution
                for the United States of America";

        }
        
    }
}
