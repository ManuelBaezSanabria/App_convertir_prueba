using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace App_convertir_prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbTablas.Items.Add("Instituciones");
            cmbTablas.Items.Add("Titulados");
            cmbTablas.Items.Add("Titulos");
            cmbTablas.Items.Add("Prueba");
        }

        public void btnAnnadir_Click(object sender, EventArgs e)
        {
            try
            {
                var schemadireccion = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "C:\\";
                    //Filtro para solo aceptar archivos de csv(Separados por coma)
                    openFileDialog.Filter = "csv files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Obtener la ruta del archivo específico
                        filePath = openFileDialog.FileName;
                        schemadireccion = Path.GetDirectoryName(filePath) + "\\Schema.ini";
                    }
                }
                System.Data.OleDb.OleDbConnection MyConnection;
                DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                //Creación de la ruta de acceso para poder extraer los datos
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + "; Extended Properties='TEXT;HDR=NO;FMT=CSVDelimited';");
                //MessageBox.Show("Se obtuvo correctamente la dirección del archivo provisto");
                DataTable tablallena = new DataTable();
                //tablallena = relllenartabla(filePath);
               // MessageBox.Show("Tabla llena con éxito");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("Select * from", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new DataSet();
                //MyCommand.FillSchema(DtSet, SchemaType);
                //MyCommand.Fill(tablallena);
                
                //MessageBox.Show("Se está mostrando una tabla con la información del archivo subido");
                MyConnection.Close();
                if (cmbTablas.SelectedItem != null)
                {
                    if (Convert.ToString(cmbTablas.SelectedItem) == "Instituciones")
                    {
                        tablallena = Relllenartablainstituciones(filePath);
                        dgvImportar.DataSource = tablallena;
                    }

                    if (Convert.ToString(cmbTablas.SelectedItem) == "Titulados")
                    {
                        tablallena = Relllenartablatitulados(filePath);
                        dgvImportar.DataSource = tablallena;
                    }

                    if (Convert.ToString(cmbTablas.SelectedItem) == "Titulos")
                    {
                        tablallena = Relllenartablatitulos(filePath);
                        dgvImportar.DataSource = tablallena;
                    }
                    if (Convert.ToString(cmbTablas.SelectedItem) == "Prueba")
                    {
                        tablallena = Relllenartablaprueba(filePath);
                        dgvImportar.DataSource = tablallena;
                    }
                }

                else
                {
                    _ = MessageBox.Show("Por favor seleccione una tabla para importar y/o el tipo de la misma");
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnImportSQL_Click(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "C:\\";
                    openFileDialog.Filter = "csv files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + "; Extended Properties='Excel 12.0;HDR=YES;';");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("Select * from", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);

                if (cmbTablas.SelectedItem != null)
                {
                    if (Convert.ToString(cmbTablas.SelectedItem) == "Instituciones")
                    {
                        ImportarInstituciones(DtSet);
                    }

                    if (Convert.ToString(cmbTablas.SelectedItem) == "Titulados")
                    {
                        ImportarTitulados(DtSet);
                    }

                    if (Convert.ToString(cmbTablas.SelectedItem) == "Titulos")
                    {
                        ImportarTitulos(DtSet);
                    }

                }

                else
                {
                    _ = MessageBox.Show("Por favor seleccione una tabla para importar");
                }
            }


            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

        public void ImportarInstituciones(System.Data.DataSet table)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=SMJ09Y4PX\SQLEXPRESS;Initial Catalog=Sicobatec_Pruebas;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                DataTable dt = table.Tables[0];
                SqlBulkCopy objbulk = new SqlBulkCopy(cnn);
                objbulk.BulkCopyTimeout = 0;
                objbulk.DestinationTableName = "instituc$";
                //Aquí van los campos para pegar
                objbulk.WriteToServer(dt);
                cnn.Close();
                MessageBox.Show("Importacion Finalizada");
                System.Diagnostics.Debug.WriteLine("La importación finalizo:");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ImportarTitulados(System.Data.DataSet table)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=SMJ09Y4PX\SQLEXPRESS;Initial Catalog=Sicobatec_Pruebas;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                DataTable dt = table.Tables[0];
                SqlBulkCopy objbulk = new SqlBulkCopy(cnn);
                objbulk.BulkCopyTimeout = 0;
                objbulk.DestinationTableName = "tblTITULADO";
                objbulk.WriteToServer(dt);
                cnn.Close();
                MessageBox.Show("Importacion Finalizada");
                System.Diagnostics.Debug.WriteLine("La importación finalizo:");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo importar la plantilla: ", ex.ToString());
            }
        }

        public void ImportarTitulos(System.Data.DataSet table)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=SMJ09Y4PX\SQLEXPRESS;Initial Catalog=Sicobatec_Pruebas;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                DataTable dt = table.Tables[0];
                SqlBulkCopy objbulk = new SqlBulkCopy(cnn);
                objbulk.BulkCopyTimeout = 0;
                objbulk.DestinationTableName = "tblTITULO";
                objbulk.WriteToServer(dt);
                cnn.Close();
                MessageBox.Show("Importacion Finalizada");
                System.Diagnostics.Debug.WriteLine("La importación finalizo:");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "No se pudo importar la plantilla: ");
            }
        }

        public void ImportarPrueba(DataSet table)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=SMJ09Y4PX\SQLEXPRESS;Initial Catalog=Sicobatec_Pruebas;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                DataTable dt = table.Tables[0];
                SqlBulkCopy objbulk = new SqlBulkCopy(cnn);
                objbulk.BulkCopyTimeout = 0;
                objbulk.DestinationTableName = "TCS0020R$";
                objbulk.WriteToServer(dt);
                cnn.Close();
                MessageBox.Show("Importacion Finalizada");
                System.Diagnostics.Debug.WriteLine("La importación finalizo:");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "No se pudo importar la plantilla: ");
            }
        }

private static DataTable relllenartabla(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Hacer que los espacios vacíos sean nulos
                        for (int i = 1; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
private static DataTable Relllenartablaprueba(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    
                    /*  
                      foreach (string column in colFields)
                      {
                          DataColumn datecolumn = new DataColumn(column);
                          datecolumn.AllowDBNull = true;
                          csvData.Columns.Add(datecolumn);
                      }*/
                    //string[] colFields = csvReader.ReadFields();
                    csvData.Columns.Add("Saludo");
                    csvData.Columns.Add("Persona");
                    
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Hacer que los espacios vacíos sean nulos
                        for (int i = 1; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
private static DataTable Relllenartablatitulados(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    /*  
                      foreach (string column in colFields)
                      {
                          DataColumn datecolumn = new DataColumn(column);
                          datecolumn.AllowDBNull = true;
                          csvData.Columns.Add(datecolumn);
                      }*/
                    //string[] colFields = csvReader.ReadFields();
                    csvData.Columns.Add("ID_Titulado");
                    csvData.Columns.Add("Titulado");
                    csvData.Columns.Add("Cedula");
                    csvData.Columns.Add("Apellido1");
                    csvData.Columns.Add("Apellido2");
                    csvData.Columns.Add("Nombre");
                    csvData.Columns.Add("UsuarioRegistro");
                    csvData.Columns.Add("UsuarioModificado");
                while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Hacer que los espacios vacíos sean nulos
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            fieldData[i + 1] = fieldData[i];
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                           /* if (i == 0) 
                            { 
                                fieldData = fieldData.Where(control => control != fieldData[0]).ToArray(); 
                            }*/
                            
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
private static DataTable Relllenartablainstituciones(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    /*  
                      foreach (string column in colFields)
                      {
                          DataColumn datecolumn = new DataColumn(column);
                          datecolumn.AllowDBNull = true;
                          csvData.Columns.Add(datecolumn);
                      }*/
                    //string[] colFields = csvReader.ReadFields();
                    csvData.Columns.Add("ID_Region");
                    csvData.Columns.Add("Nombre");
                    csvData.Columns.Add("Telefono");
                    csvData.Columns.Add("Fax");
                    csvData.Columns.Add("Provincia");
                    csvData.Columns.Add("Canton");
                    csvData.Columns.Add("Distrito");
                    csvData.Columns.Add("Direccion");
                    csvData.Columns.Add("UsuarioRegistro");
                    csvData.Columns.Add("UsuarioModificado");
                while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Hacer que los espacios vacíos sean nulos
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                            if (i == 0)
                            {
                                fieldData = fieldData.Where(control => control != fieldData[0]).ToArray();
                            }

                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
private static DataTable Relllenartablatitulos(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    /*  
                      foreach (string column in colFields)
                      {
                          DataColumn datecolumn = new DataColumn(column);
                          datecolumn.AllowDBNull = true;
                          csvData.Columns.Add(datecolumn);
                      }*/
                    //string[] colFields = csvReader.ReadFields();
                    csvData.Columns.Add("ID_Titulo");
                    csvData.Columns.Add("ID_Titulado");
                    csvData.Columns.Add("ID_Institucion");
                    csvData.Columns.Add("TipoTitulo");
                    csvData.Columns.Add("Modalidad");
                    csvData.Columns.Add("Tomo");
                    csvData.Columns.Add("Folio");
                    csvData.Columns.Add("Asiento");
                    csvData.Columns.Add("NumeroTitulo");
                    csvData.Columns.Add("Year");
                    csvData.Columns.Add("UsuarioRegistro");
                    csvData.Columns.Add("UsuarioModificado");
                    csvData.Columns.Add("Adecuacion");
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Hacer que los espacios vacíos sean nulos
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                            if (i == 0)
                            {
                                fieldData = fieldData.Where(control => control != fieldData[0]).ToArray();
                            }

                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
    }


}