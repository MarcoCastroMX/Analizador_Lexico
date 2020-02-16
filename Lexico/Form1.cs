using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void BtnAnalizar_Click(object sender, EventArgs e)
        {
            string Texto = TxtIngreseTexto.Text;
            int Estado = 0;
            for (int Indice = 0; Indice < Texto.Length; Indice++)
            {
                char Caracter = Texto[Indice];
                int CodigoASCCI = Caracter;
                switch (Estado)
                {
                    case 0:
                        {
                            if (CodigoASCCI >= 65 && CodigoASCCI <= 122)
                            {
                                Estado = 1;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Cadena";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "3";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 2;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Entero";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "1";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (CodigoASCCI >= 65 && CodigoASCCI <= 122)
                            {
                                Estado = 1;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Cadena";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "3";
                                Tabla.Rows.Add(Fila);
                            }
                            if(CodigoASCCI>=48 && CodigoASCCI <= 57)
                            {
                                Estado = 1;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Entero";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "1";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Indice + 1 == Texto.Length)
                            {
                                Estado = 1;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Identificador";
                                Fila.Cells[1].Value = Texto;
                                Fila.Cells[2].Value = "0";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 2;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Entero";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "1";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI==46)
                            {
                                Estado = 3;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Punto";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "24";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 4;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Real";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "2";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 4;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Real";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "2";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                }
            }
            System.Diagnostics.Debug.WriteLine(Estado);
            if(Estado!=1 && Estado!=2 && Estado!=4)
            {
                MessageBox.Show("Token Desconocido");
            }
        }
    }
}
