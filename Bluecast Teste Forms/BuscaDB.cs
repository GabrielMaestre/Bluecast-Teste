using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Bluecast_Teste_Forms
{
    public partial class BuscaDB : Form
    {
        public BuscaDB()
        {
            InitializeComponent();
        }

        MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=db_bluecast; password=root");

        private void btnBuscaAll_Click(object sender, EventArgs e)
        {
            //MySqlDataAdapter adapter = new MySqlDataAdapter("", objCon);

            adgvMain.Refresh();

            int escolha = lbTxtEscolha.SelectedIndex;

            try
            {
                objCon.Open();
            }
            catch (Exception a)
            {

            }


            switch (escolha)
            {
                case 0:
                    //TODOS
                    if(String.IsNullOrEmpty(txtBusca.Text))
                    {
                        //SEM BUSCA, TUDO.
                        QueryAll();
                    }
                    else
                    {
                        QueryAllFind();
                    }
                    break;
                case 1:
                    //Nome
                    QueryNome();
                    break;
                case 2:
                    //Sobrenome
                    QuerySobreNome();
                    break;
                case 3:
                    //Valor
                    QueryValor();
                    break;
                case 4:
                    //Desde
                    QueryData();
                    break;
                case 5:
                    //Ultimo
                    QueryIndi();
                    break;
                default:
                    MessageBox.Show("Favor escolha alguma das opções a Esquerda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            txtBusca.Clear();
        }

        public void QueryAll()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM db_bluecast.clientes;", objCon);
            UpdateDGV(adapter);
        }


        public void QueryAllFind()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(
$"SELECT * FROM clientes WHERE '{txtBusca.Text}' IN (nome, sobrenome, valor, desde, inadimplentes) LIMIT 100;", objCon);
            UpdateDGV(adapter);
        }


        public void QueryNome()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(
$"SELECT * FROM clientes WHERE (nome LIKE '{txtBusca.Text}');", objCon);
            UpdateDGV(adapter);
        }


        public void QuerySobreNome()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(
$"SELECT * FROM clientes WHERE (sobrenome LIKE '{txtBusca.Text}');", objCon);
            UpdateDGV(adapter);
        }


        public void QueryValor()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(
    $"SELECT * FROM clientes WHERE (valor {txtBusca.Text});", objCon);
                UpdateDGV(adapter);
            }
            catch (Exception a)
            {
                MessageBox.Show("ERROR");
            }
        }


        public void QueryData()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(
    $"SELECT * FROM clientes WHERE (desde >= '{txtBusca.Text}');", objCon);
                UpdateDGV(adapter);
            }
            catch (Exception a)
            {
                MessageBox.Show("ERROR");
            }
        }

        public void QueryIndi()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(
    $"SELECT * FROM clientes WHERE '{txtBusca.Text}' IN (nome, sobrenome, valor, desde, inadimplentes) LIMIT 100;", objCon);
                UpdateDGV(adapter);
            }
            catch (Exception a)
            {
                MessageBox.Show("ERROR");
            }
        }





        public void UpdateDGV(MySqlDataAdapter adapter)
        {
            try
            {
                objCon.Close();
            }
            catch(Exception a)
            {

            }

            LimparTabela();

            DataSet ds = new DataSet();
            adapter.Fill(ds, "clientes");
            adgvMain.DataSource = ds.Tables["clientes"];
        }

        public void LimparTabela()
        {
            try
            {
                adgvMain.Refresh();
                adgvMain.DataSource = null;
                adgvMain.Rows.Clear();
                adgvMain.Refresh();
            }
            catch (Exception a)
            {

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTabela();
        }

        private void lbTxtEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbTxtEscolha.SelectedIndex == 3)
            {
                MessageBox.Show("O texto deve conter: > OU = OU < COM O VALOR A FRENTE!\nExemplo: >= 1000", "AVISO!!!");
            }
            if (lbTxtEscolha.SelectedIndex == 4)
            {
                MessageBox.Show("O texto deve estar no padrão: 0000-00-00\nExemplo: 2020-12-31", "AVISO!!!");
            }
        }
    }
}
