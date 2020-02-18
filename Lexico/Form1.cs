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
            Tabla.Rows.Clear();
            bool Real = false;
            bool Or = false;
            bool And = false;
            string Texto = TxtIngreseTexto.Text+"$";
            int Estado = 0;
            string Contenido = "";
            string ID = "";
            string Numero = "";
            string Fracciones = "";
            string Iguales = "";
            string Relacion = "";
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
                                Estado = 1;
                                ID += Texto[Indice];
                                break;
                            }
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 2;
                                Numero += Texto[Indice];
                                break;
                            }
                            if (CodigoASCCI == 43 || CodigoASCCI == 45)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpSuma";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "5";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 42 || CodigoASCCI == 47)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "OpMul";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "6";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 61)
                            {
                                Estado = 3;
                                Iguales += Texto[Indice];
                                break;
                            }

                            if (CodigoASCCI == 60 || CodigoASCCI==62)
                            {
                                Estado = 4;
                                Relacion += Texto[Indice];
                                break;
                            }
                            if (CodigoASCCI == 59)
                            {
                                Estado = 0;

                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "PuntoComa";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "12";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 44)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Coma";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "13";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 40)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "AbreParentesis";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "14";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 41)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "CierraParentesis";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "15";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 123)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "AbreLlaves";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "16";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 125)
                            {
                                Estado = 0;
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "CierraLlaves";
                                Fila.Cells[1].Value = Texto[Indice];
                                Fila.Cells[2].Value = "17";
                                Tabla.Rows.Add(Fila);
                                break;
                            }
                            if (CodigoASCCI == 33)
                            {
                                Estado = 5;
                                Iguales += Texto[Indice];
                                break;
                            }
                            if (CodigoASCCI == 124)
                            {
                                Estado = 0;
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
                                break;
                            }
                            if (CodigoASCCI == 38)
                            {
                                Estado = 0;
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
                                break;
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
                                break;
                            }
                            Estado = 0;
                            DataGridViewRow Desconocido = new DataGridViewRow();
                            Desconocido.CreateCells(Tabla);
                            Desconocido.Cells[0].Value = "Desconocido";
                            Desconocido.Cells[1].Value = Texto[Indice];
                            Desconocido.Cells[2].Value = "?";
                            Tabla.Rows.Add(Desconocido);
                            break;
                        }

                    case 1:
                        {
                            if (CodigoASCCI >= 65 && CodigoASCCI <= 122)
                            {
                                Estado = 1;
                                ID += Texto[Indice];
                                string NewID = "";
                                if (Contenido.Contains("return"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 6 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 6; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Reservada";
                                    FilaReturn.Cells[1].Value = "return";
                                    FilaReturn.Cells[2].Value = "21";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                if (Contenido.Contains("while"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 5 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 5; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Reservada";
                                    FilaReturn.Cells[1].Value = "while";
                                    FilaReturn.Cells[2].Value = "20";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                if (Contenido.Contains("if"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 2 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 2; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Reservada";
                                    FilaReturn.Cells[1].Value = "if";
                                    FilaReturn.Cells[2].Value = "19";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                if (Contenido.Contains("void"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 4 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 4; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Tipo";
                                    FilaReturn.Cells[1].Value = "void";
                                    FilaReturn.Cells[2].Value = "4";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                if (Contenido.Contains("float"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 5 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 5; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Tipo";
                                    FilaReturn.Cells[1].Value = "float";
                                    FilaReturn.Cells[2].Value = "4";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                if (Contenido.Contains("int"))
                                {
                                    Contenido = "";
                                    if (ID.Length - 3 != 0)
                                    {
                                        for (int i = 0; i < ID.Length - 3; i++)
                                        {
                                            NewID += ID[i];
                                        }
                                        DataGridViewRow FilaIdentificador = new DataGridViewRow();
                                        FilaIdentificador.CreateCells(Tabla);
                                        FilaIdentificador.Cells[0].Value = "Identificador";
                                        FilaIdentificador.Cells[1].Value = NewID;
                                        FilaIdentificador.Cells[2].Value = "0";
                                        Tabla.Rows.Add(FilaIdentificador);
                                    }
                                    DataGridViewRow FilaReturn = new DataGridViewRow();
                                    FilaReturn.CreateCells(Tabla);
                                    FilaReturn.Cells[0].Value = "Tipo";
                                    FilaReturn.Cells[1].Value = "int";
                                    FilaReturn.Cells[2].Value = "4";
                                    Tabla.Rows.Add(FilaReturn);
                                    Estado = 0;
                                    ID = "";
                                    break;
                                }
                                break;
                            }
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                char Diferenciador = Texto[Indice + 1];
                                CodigoASCCI = Diferenciador;
                                if (CodigoASCCI != 46)
                                {
                                    Estado = 1;
                                    ID += Texto[Indice];
                                    break;
                                }
                            }
                            DataGridViewRow Fila = new DataGridViewRow();
                            Fila.CreateCells(Tabla);
                            Fila.Cells[0].Value = "Identificador";
                            Fila.Cells[1].Value = ID;
                            Fila.Cells[2].Value = "0";
                            Tabla.Rows.Add(Fila);
                            Indice--;
                            Estado = 0;
                            ID = "";
                            break;
                        }
                    case 2:
                        {
                            if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                            {
                                Estado = 2;
                                Numero += Texto[Indice];
                                if (Real)
                                    Fracciones += Texto[Indice];
                                break;
                            }
                            if (CodigoASCCI == 46 && !Real)
                            {
                                char NumPosPunto = Texto[Indice + 1];
                                CodigoASCCI = NumPosPunto;
                                if (CodigoASCCI >= 48 && CodigoASCCI <= 57)
                                {
                                    Estado = 2;
                                    Numero += Texto[Indice];
                                    Real = true;
                                    break;
                                }
                                Estado = 0;
                                Numero += Texto[Indice];
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Desconocido";
                                Fila.Cells[1].Value = Numero;
                                Fila.Cells[2].Value = "?";
                                Tabla.Rows.Add(Fila);
                                Numero = "";
                                break;
                            }
                            if (CodigoASCCI == 46 && Real)
                            {
                                if (Fracciones.Length > 1)
                                {
                                    string RealAux = "";
                                    for (int i = 0; i < Numero.Length - 1; i++)
                                    {
                                        RealAux += Numero[i];
                                    }
                                    DataGridViewRow Fila = new DataGridViewRow();
                                    Fila.CreateCells(Tabla);
                                    Fila.Cells[0].Value = "Real";
                                    Fila.Cells[1].Value = RealAux;
                                    Fila.Cells[2].Value = "2";
                                    Tabla.Rows.Add(Fila);
                                    Indice =Indice-2;
                                    Real = false;
                                    Estado = 0;
                                    Fracciones = "";
                                    Numero = "";
                                    break;
                                }
                            }
                            if (!Real)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Entero";
                                Fila.Cells[1].Value = Numero;
                                Fila.Cells[2].Value = "1";
                                Tabla.Rows.Add(Fila);
                            }
                            if (Real)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();
                                Fila.CreateCells(Tabla);
                                Fila.Cells[0].Value = "Real";
                                Fila.Cells[1].Value = Numero;
                                Fila.Cells[2].Value = "2";
                                Tabla.Rows.Add(Fila);
                            }
                            Indice--;
                            Real = false;
                            Estado = 0;
                            Numero = "";
                            Fracciones = "";
                            break;
                        }
                    case 3:
                        {
                            Estado = 0;
                            if (CodigoASCCI == 61)
                            {
                                Iguales += Texto[Indice];
                                DataGridViewRow Igualdad = new DataGridViewRow();
                                Igualdad.CreateCells(Tabla);
                                Igualdad.Cells[0].Value = "OpIgualdad";
                                Igualdad.Cells[1].Value = Iguales;
                                Igualdad.Cells[2].Value = "11";
                                Tabla.Rows.Add(Igualdad);
                                Iguales = "";
                                break;
                            }
                            DataGridViewRow Fila = new DataGridViewRow();
                            Fila.CreateCells(Tabla);
                            Fila.Cells[0].Value = "Asignacion";
                            Fila.Cells[1].Value = Iguales;
                            Fila.Cells[2].Value = "18";
                            Tabla.Rows.Add(Fila);
                            Indice--;
                            Iguales = "";
                            break;
                        }
                    case 4:
                        {
                            Estado = 0;
                            if (CodigoASCCI == 61)
                            {
                                Relacion += Texto[Indice];
                                DataGridViewRow Relac = new DataGridViewRow();
                                Relac.CreateCells(Tabla);
                                Relac.Cells[0].Value = "OpRelac";
                                Relac.Cells[1].Value = Relacion;
                                Relac.Cells[2].Value = "7";
                                Tabla.Rows.Add(Relac);
                                Relacion = "";
                                break;
                            }
                            DataGridViewRow Fila = new DataGridViewRow();
                            Fila.CreateCells(Tabla);
                            Fila.Cells[0].Value = "OpRelac";
                            Fila.Cells[1].Value = Relacion;
                            Fila.Cells[2].Value = "7";
                            Tabla.Rows.Add(Fila);
                            Indice--;
                            Relacion = "";
                            break;
                        }
                    case 5:
                        {
                            Estado = 0;
                            if (CodigoASCCI == 61)
                            {
                                Iguales += Texto[Indice];
                                DataGridViewRow Igualdad = new DataGridViewRow();
                                Igualdad.CreateCells(Tabla);
                                Igualdad.Cells[0].Value = "OpIgualdad";
                                Igualdad.Cells[1].Value = Iguales;
                                Igualdad.Cells[2].Value = "11";
                                Tabla.Rows.Add(Igualdad);
                                Iguales = "";
                                break;
                            }
                            DataGridViewRow Fila = new DataGridViewRow();
                            Fila.CreateCells(Tabla);
                            Fila.Cells[0].Value = "OpNot";
                            Fila.Cells[1].Value = Iguales;
                            Fila.Cells[2].Value = "10";
                            Tabla.Rows.Add(Fila);
                            Indice--;
                            Iguales = "";
                            break;
                        }
                }
            }
        }
    }
}
