using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//C:\Users\felip\source\repos pasta
namespace Sistema_Vendas.UIform
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e) {
            u.pr_nome = txtFirstName.Text;
            u.sb_nome = txtLastName.Text;
            u.email = txtEmail.Text;
            u.user_name = txtUserName.Text;
            u.password = txtSenha.Text;
            u.contato = txtContato.Text;
            u.nm_endereco = txtEndereco.Text;
            u.sexo = cbxSexo.Text;
            u.user_type = cbxTpUser.Text;
            u.data = DateTime.Now;
            u.add_por = 1;

            bool sucess = dal.Insert(u);
            if (sucess = true) {
                MessageBox.Show("Usuário cadastrado com sucesso");
                Limpar();
            }
            else {
                MessageBox.Show("Não foi possivel cadastrar esse usuário");
            }

            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }

        private void frmUsers_Load(object sender, EventArgs e) {
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
            dgvUser.Columns[0].HeaderText = "Id usuário";
            dgvUser.Columns[1].HeaderText = "Nome";
            dgvUser.Columns[2].HeaderText = "Ultimo nome";
            dgvUser.Columns[3].HeaderText = "E-mail";
            dgvUser.Columns[4].HeaderText = "Usuário";
            dgvUser.Columns[5].HeaderText = "Senha";
            dgvUser.Columns[6].HeaderText = "Contato";
            dgvUser.Columns[7].HeaderText = "Endereço";
            dgvUser.Columns[8].HeaderText = "Sexo";
            dgvUser.Columns[9].HeaderText = "Tipo";
            dgvUser.Columns[10].HeaderText = "Data/Hora";
            dgvUser.Columns[11].HeaderText = "Cadastrante";
        }

        private void Limpar(){
            txtUserId.Text = " ";
            txtFirstName.Text = " ";
            txtLastName.Text = " ";
            txtEmail.Text = " ";
            txtUserName.Text = " ";
            txtSenha.Text = "";
            txtContato.Text = " ";
            txtEndereco.Text = " ";
            cbxSexo.Text = " ";
            cbxTpUser.Text = " ";
        }

        private void dgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            int rowIndex = e.RowIndex;
            txtUserId.Text = dgvUser.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUser.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUser.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUser.Rows[rowIndex].Cells[3].Value.ToString();
            txtUserName.Text = dgvUser.Rows[rowIndex].Cells[4].Value.ToString();
            txtSenha.Text = dgvUser.Rows[rowIndex].Cells[5].Value.ToString();
            txtContato.Text = dgvUser.Rows[rowIndex].Cells[6].Value.ToString();
            txtEndereco.Text = dgvUser.Rows[rowIndex].Cells[7].Value.ToString();
            cbxSexo.Text = dgvUser.Rows[rowIndex].Cells[8].Value.ToString();
            cbxTpUser.Text = dgvUser.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnAtualiza_Click(object sender, EventArgs e) {
            u.id = Convert.ToInt32(txtUserId.Text);
            u.pr_nome = txtFirstName.Text;
            u.sb_nome = txtLastName.Text;
            u.email = txtEmail.Text;
            u.user_name = txtUserName.Text;
            u.password = txtSenha.Text;
            u.contato = txtContato.Text;
            u.nm_endereco = txtEndereco.Text;
            u.sexo = cbxSexo.Text;
            u.user_type = cbxTpUser.Text;
            u.data = DateTime.Now;
            u.add_por = 1;

            bool sucess = dal.update(u);
            if (sucess == true) {
                MessageBox.Show("Usuário atualizado com sucesso!");
                Limpar();
            }
            else { MessageBox.Show("Não foi possivel atualizar usuário!"); }

            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            Limpar();
        }

        private void btnDeletar_Click(object sender, EventArgs e) {
            u.id = Convert.ToInt32(txtUserId.Text);
            bool sucess = dal.Delete(u);
            if (sucess == true)
            {
                MessageBox.Show("Usuário deletado com sucesso!");
                Limpar();
            }
            else { MessageBox.Show("Não foi possivel deletar usuário!"); }

                DataTable dt = dal.Select();
                dgvUser.DataSource = dt;
            }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) {
            string keywords = txtPesquisa.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvUser.DataSource = dt;
            }
            else {
                DataTable dt = dal.Search();
                dgvUser.DataSource = dt;
            }
        }
    }
}
