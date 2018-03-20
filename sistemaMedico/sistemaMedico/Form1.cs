using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace sistemaMedico
{
    public partial class Form1 : Form
    {
        static string strCn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\Documents\\Visual Studio 2010\\Projects\\sistema_medico.sql";
        OleDbConnection conexao = new OleDbConnection(strCn);
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_pesquisa_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por pesquisar o banco de dados (CRUD - Read)
            string pesquisa = "select * from funcionarios where Id = " + txt_acesso.Text;

            //criando um objeto de nome cmd tendo como modelo a classe OleDbCommand para executar a instrução sql
            OleDbCommand cmd = new OleDbCommand(pesquisa, conexao);
            // Atravé da classe OleDbDataReader que faz parte do SqlCliente, criamos uma //variável chamada DR que será usada na leitura dos dados (instrução select)
            OleDbDataReader DR;

                        //tratamento de exceções: try - catch - finally (em caso de erro capturamos o //tipo do erro)

try 
{
// Abrindo a conexão com o banco
conexao.Open();
// Executando a instrução e armazenando o resultado no reader DR
DR = cmd.ExecuteReader();
// Se houver um registro correspondente ao Id
if (DR.Read()) 

{ 
// Exibe as informações nas caixas de texto (textBox) correspondentes (0) //corresponde ao Id, (1) ao Nome e assim sucessivamente 
txt_idmedico.Text = DR.GetValue(0).ToString(); 
txt_idpaciente.Text = DR.GetValue(1).ToString();
txt_acesso.Text = DR.GetValue(2).ToString(); 
txt_crm.Text = DR.GetValue(3).ToString(); 
txt_rg.Text = DR.GetValue(4).ToString(); 
txt_cpf.Text = DR.GetValue(5).ToString(); 
txt_endereco.Text = DR.GetValue(6).ToString(); 
txt_tel.Text = DR.GetValue(7).ToString(); 
txt_especialidade.Text = DR.GetValue(8).ToString(); 
txt_login.Text = DR.GetValue(9).ToString(); 
txt_senha.Text = DR.GetValue(10).ToString(); 

} 

// Senão, exibimos uma mensagem avisando e também limpamos os campos para uma //nova pesquisa 
else 
{ 
MessageBox.Show("Registro não encontrado"); 
txt_idmedico.Clear(); 
txt_idpaciente.Clear();
txt_acesso.Clear();
txt_crm.Clear(); 
txt_rg.Clear(); 
txt_cpf.Clear(); 
txt_endereco.Clear();
txt_tel.Clear(); 
txt_especialidade.Clear(); 
txt_login.Clear(); 
txt_senha.Clear();
txt_acesso.Focus();

} // Encerrando o uso do reader DR 
DR.Close(); 

// Encerrando o uso do cmd 
cmd.Dispose(); 
} 

//caso ocorra algum erro 
catch (Exception ex) 
{
 
//exiba qual é o erro 
MessageBox.Show(ex.Message); 
} 

// de qualquer forma sempre fechar a conexão com o banco ("lembrar da porta da //geladeira rsrsrs") 
finally 
{ 
conexao.Close(); 
} 
}

        private void btn_adiciona_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por adicionar dados ao banco (CRUD - Create) 
string adiciona = "insert into funcionarios values (" + 
txt_idmedico.Text + ",'" + 
txt_idpaciente.Text + "','" +
txt_acesso.Text + "','" + 
txt_crm.Text + "','" +
txt_rg.Text + "','" +
txt_cpf.Text + "','" +
txt_endereco.Text + "','" +
txt_tel.Text + "','" +
txt_especialidade.Text + "','" +
txt_login.Text + "','" + 
txt_senha.Text + "')"; 

//criando um objeto de nome cmd tendo como modelo a classe OleDbCommand para //executar a instrução sql 
OleDbCommand cmd = new OleDbCommand(adiciona, conexao);
 
//tratamento de exceções: try - catch - finally (em caso de erro capturamos o //tipo do erro) 
try 
{ 
// Abrindo a conexão com o banco 
conexao.Open(); 

// Criando uma variável para adicionar e armazenar o resultado 
int resultado;
resultado = cmd.ExecuteNonQuery(); 

// Verificando se o registro foi adicionado 
// Caso o valor da variável resultado seja 1 
// significa que o comando funcionou, neste caso limpar os campos e exibir uma //mensagem 
if (resultado == 1) 
{ 
MessageBox.Show("Registro adicionado com sucesso");
txt_idmedico.Clear();
txt_idpaciente.Clear();
txt_acesso.Clear();
txt_crm.Clear();
txt_rg.Clear();
txt_cpf.Clear();
txt_endereco.Clear();
txt_tel.Clear();
txt_especialidade.Clear();
txt_login.Clear();
txt_senha.Clear();
txt_acesso.Focus();
}
 
// Encerrando o uso do cmd 
cmd.Dispose(); 
}
 
//caso ocorra algum erro 
catch (Exception ex) 
{
 
//exiba qual é o erro 
MessageBox.Show(ex.Message); 
} 

// de qualquer forma sempre fechar a conexão com o banco ("lembrar da porta da //geladeira rsrsrs") 
finally 
{ 
conexao.Close(); 
} 
}

        private void btn_altera_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por alterar um registro do banco (CRUD - Update) 
string altera = "update funcionarios set Nome= '" + txt_rg.Text + 
"', cpf= '" + txt_cpf.Text + 
"', endereco= '" + txt_endereco.Text +
"', telefone= '" + txt_tel.Text +
"', especialidade= '" + txt_especialidade.Text +
"', login= '" + txt_login.Text +
"', senha= '" + txt_senha.Text +
"', IDPaciente= '" + txt_idpaciente.Text +
"', IDMedico= '" + txt_idmedico.Text + 
"' where tipo_acesso= " + txt_acesso.Text; 


//criando um objeto de nome cmd tendo como modelo a classe OleDbCommand para //executar a instrução sql 
OleDbCommand cmd = new OleDbCommand(altera, conexao); 

//tratamento de exceções: try - catch - finally (em caso de erro capturamos o //tipo do erro) 
try 
{ 
// Abrindo a conexão com o banco 
conexao.Open(); 

// Criando uma variável para alterar e armazenar o resultado 
int resultado; 
resultado = cmd.ExecuteNonQuery();
// Verificando se o registro foi alterado 
// Caso o valor da variável resultado seja 1 
// significa que o comando funcionou, neste caso limpar os campos e exibir uma //mensagem 
if (resultado == 1) 
{
    txt_idmedico.Clear();
    txt_idpaciente.Clear();
    txt_acesso.Clear();
    txt_crm.Clear();
    txt_rg.Clear();
    txt_cpf.Clear();
    txt_endereco.Clear();
    txt_tel.Clear();
    txt_especialidade.Clear();
    txt_login.Clear();
    txt_senha.Clear();
    txt_acesso.Clear();
MessageBox.Show("Registro alterado com sucesso"); 
}
// Encerrando o uso do cmd 
cmd.Dispose(); 
} 

//caso ocorra algum erro 
catch (Exception ex) 
{ 

//exiba qual é o erro 
MessageBox.Show(ex.Message); 
} 

// De qualquer forma sempre fechar a conexão com o banco 
finally 
{ 
conexao.Close(); 
} 
}

        private void btn_exclui_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por remover um registro do banco (CRUD - Delete) 
string remove = "delete from tbcontatos where Id= " + txtId.Text; 

//criando um objeto de nome cmd tendo como modelo a classe OleDbCommand para //executar a instrução sql 
OleDbCommand cmd = new OleDBCommand(remove, conexao); 

//tratamento de exceções: try - catch - finally (em caso de erro capturamos o //tipo do erro) 
try 
{ 

// Abrindo a conexão com o banco 
conexao.Open(); 

// Criando uma variável para adicionar e armazenar o resultado 
int resultado; 
if (MessageBox.Show("Tem certeza que deseja remover este registro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
{ 
resultado = cmd.ExecuteNonQuery();
// Verificando se o registro foi apagado 
// Caso o valor da variável resultado seja 1 
// significa que o comando funcionou, neste caso limpar os campos e exibir uma //mensagem 
if (resultado == 1) 
{
    txt_idmedico.Clear();
    txt_idpaciente.Clear();
    txt_acesso.Clear();
    txt_crm.Clear();
    txt_rg.Clear();
    txt_cpf.Clear();
    txt_endereco.Clear();
    txt_tel.Clear();
    txt_especialidade.Clear();
    txt_login.Clear();
    txt_senha.Clear();
    txt_acesso.Clear();
MessageBox.Show("Registro removido com sucesso"); 
} 

// Encerrando o uso do cmd 
cmd.Dispose(); 
} 
} 

//caso ocorra algum erro 
catch (Exception ex) 
{ 

//exiba qual é o erro 
MessageBox.Show(ex.Message); 
} 
// de qualquer forma sempre fechar a conexão com o banco 
finally 
{ 
conexao.Close(); 
} 
}

        }


        }