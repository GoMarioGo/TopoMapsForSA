using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GIS2LKMAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLK2ASC_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "LK8000 DEM files (*.dem)|*.dem";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                String outFileAscName = Path.ChangeExtension(fileName, ".asc");

                double Left;
                double Right;
                double Top;
                double Bottom;
                double StepSize;
                uint Rows;
                uint Columns;

                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        Left = reader.ReadDouble();
                        Right = reader.ReadDouble();
                        Top = reader.ReadDouble();
                        Bottom = reader.ReadDouble();
                        StepSize = reader.ReadDouble();
                        Rows = reader.ReadUInt32();
                        Columns = reader.ReadUInt32();

                        //uint nsize = Rows * Columns;

                        var utf8WithoutBom = new System.Text.UTF8Encoding(false);
                        FileStream ostream = new FileStream(outFileAscName, FileMode.Create, FileAccess.ReadWrite);
                        StreamWriter writer = new StreamWriter(ostream, utf8WithoutBom);


                        writer.WriteLine("ncols         " + Columns.ToString());
                        writer.WriteLine("nrows         " + Rows.ToString());
                        writer.WriteLine("xllcorner     " + Left.ToString());
                        writer.WriteLine("yllcorner     " + Bottom.ToString());
                        writer.WriteLine("cellsize      " + StepSize.ToString());

                        writer.WriteLine("NODATA_value  0");
                        writer.Flush();
                        

                        for (int r = 0; r < Rows; r++)
                        {
                            String line = "";
                            short val;
                            for (int c = 0; c < Columns; c++)
                            {
                                val = reader.ReadInt16();
                                line += val.ToString() + " ";
                            }
                            writer.WriteLine(line);
                        }

                        writer.Flush();
                        ostream.Close();

                        MessageBox.Show("Done");
                    }

                    
                }
  
            }
        }

        private void buttonASC2LK_Click(object sender, EventArgs e)
        {
           OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "LK8000 DEM files (*.asc)|*.asc";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                String outFileDemName = Path.ChangeExtension(fileName, ".dem");

                double Left=0;
                double Right = 0;
                double Top = 0;
                double Bottom = 0;
                double StepSize = 0;
                uint Rows = 0;
                uint Columns = 0;

                if (File.Exists(fileName))
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(outFileDemName, FileMode.Create));
                    StreamReader sr = new StreamReader(fileName);
                    for (int j = 0; j < 6; j++)
                    {
                        String line = sr.ReadLine();
                        String[] components = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        switch  ( components[0] ) 
                        {
                            case "ncols":
                                Columns = UInt16.Parse(components[1]);
                                break;
                            case "nrows":
                                Rows = UInt16.Parse(components[1]);
                                break;
                            case "xllcorner":
                                Left = Double.Parse(components[1]);
                                break;
                            case "yllcorner":
                                Bottom = Double.Parse(components[1]);
                                break;
                            case "cellsize":
                                StepSize = Double.Parse(components[1]);
                                break;
                        }

                      

                    }

                    Top = Bottom + StepSize * (Rows);
                    Right = Left + StepSize * (Columns );

                    writer.Write(Left);
                    writer.Write(Right);
                    writer.Write(Top);
                    writer.Write(Bottom);
                    writer.Write(StepSize);
                    writer.Write(Rows);
                    writer.Write(Columns);


                    for (int j = 0; j < Rows; j++)
                    {
                        String line = sr.ReadLine();
                        String[] components = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        for (int k = 0; k < Columns; k++)
                        {
                            short val = Int16.Parse(components[k]);
                            if (val == -9999)
                                val = 0;
                            writer.Write((ushort)val);
                        }

                    }



                    writer.Close();
                    sr.Close();

                    MessageBox.Show("Done");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
