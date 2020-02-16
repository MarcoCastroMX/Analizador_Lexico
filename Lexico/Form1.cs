using System;
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
            bool Identificador = true;
            bool Real = false;
            bool Punto = false;
            bool Or = false;
            bool And = false;
            bool Relacion = false;
            bool Asignacion = false;
            bool Igual = true;
            bool Diferente = false;
            string Texto = TxtIngreseTexto.Text;
            int Estado = 0;
            string Contenido = "";
            for (int Indice = 0; Indice < Texto.Length; Indice++)
            {
                char Caracter = Texto[Indice];
                Contenido += Caracter;
                int CodigoASCCI = Caracter;
                switch (Estado)
                {
                    case 0:
                        {
                            if (CodigoASCCI >= 65 && CodigoASCCI <= 122)
                            {
                                Estado = 0;
                                Real = false;
                                Punto = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Cadena";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "3";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57 && !Punto)
                            {
                                Estado = 0;
                                Real = true;
                                Punto = false;
                                Asignacion = false;
                                Relacion = false;
                                if (Indice == 0)
                                    Identificador = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Entero";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "1";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57 && Real && Punto)
                            {
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Real";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "2";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 46 && Real)
                            {
                                Estado = 0;
                                Punto = true;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Punto";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "24";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 43 || CodigoASCCI == 45)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpSuma";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "5";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 42 || CodigoASCCI == 47)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpMul";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "6";
                                Tabla.Rows.Add(Fila);
                            }


                            if (CodigoASCCI == 61)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                if (Asignacion)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "OpIgualdad";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "11";
                                    Tabla.Rows.Add(Fila);
                                    Asignacion = false;
                                    Igual = false;
                                }                               
                                if (Relacion)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "OpRelac";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "7";
                                    Tabla.Rows.Add(Fila);
                                    Relacion = false;
                                    Igual = false;
                                }
                                if (Diferente)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "OpIgualdad";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "11";
                                    Tabla.Rows.Add(Fila);
                                    Diferente = false;
                                    Igual = false;
                                }
                                if (Igual)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "Asignacion";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "18";
                                    Tabla.Rows.Add(Fila);
                                    Asignacion = true;
                                }
                                else
                                {
                                    Igual = true;
                                }
                            }
                            if (CodigoASCCI == 60 || CodigoASCCI==62)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = true;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpRelac";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "7";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 59)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "PuntoComa";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "12";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 44)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Coma";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "13";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 40)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "AbreParentesis";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "14";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 41)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "CierraParentesis";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "15";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 123)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "AbreLlaves";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "16";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 125)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "CierraLlaves";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "17";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 33)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                Diferente = true;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpNot";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "10";
                                Tabla.Rows.Add(Fila);
                            }
                            if (CodigoASCCI == 124)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                if (Or)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "OpNor";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "10";
                                    Tabla.Rows.Add(Fila);
                                    Or = false;
                                }
                                else
                                    Or = true;
                                    
                            }
                            if (CodigoASCCI == 38)
                            {
                                Estado = 0;
                                Real = false;
                                Identificador = false;
                                Asignacion = false;
                                Relacion = false;
                                if (And)
                                {
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "OpAnd";
                                    Fila.Cells[1].Value = Texto[Indice];
                                    Fila.Cells[2].Value = "9";
                                    Tabla.Rows.Add(Fila);
                                    And = false;
                                }
                                else
                                    And = true;
                                
                            }
                            if (Contenido.Contains("int"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Tipo";
                                Fila.Cells[1].Value = "int";
                                Fila.Cells[2].Value = "4";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("float"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Tipo";
                                Fila.Cells[1].Value = "float";
                                Fila.Cells[2].Value = "4";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("void"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Tipo";
                                Fila.Cells[1].Value = "void";
                                Fila.Cells[2].Value = "4";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("if"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Reservada";
                                Fila.Cells[1].Value = "if";
                                Fila.Cells[2].Value = "19";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("while"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Reservada";
                                Fila.Cells[1].Value = "while";
                                Fila.Cells[2].Value = "20";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("return"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Reservada";
                                Fila.Cells[1].Value = "return";
                                Fila.Cells[2].Value = "21";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Contenido.Contains("$"))
                            {
                                Contenido = "";
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Fin";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "23";
                                Tabla.Rows.Add(Fila);
                            }
                            break;
                        }
                }
            }
            if (Identificador)
            {
                DataGridViewRow Fila = new DataGridViewRow();
                Fila.CreateCells(Tabla);
                Fila.Cells[0].Value = "Identificador";
                Fila.Cells[1].Value = Texto;
                Fila.Cells[2].Value = "0";
                Tabla.Rows.Add(Fila);
            }
        }
    }
}
