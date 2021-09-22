using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RoleForm : Form
    {
        DS2Entities db = new DS2Entities();
        private int RoleId { get; set; }
        public RoleForm()
        {
            InitializeComponent();

            GetRecords();
        }

        private void GetRecords()
        {
            var query = db.Role.ToList();

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                query = query.Where(x=> x.Title.ToLower().Contains(txtTitle.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(txtDescription.Text))
            {
                query = query.Where(x => x.Description.ToLower().Contains(txtDescription.Text.ToLower())).ToList();
            }

            if (rbActive.Checked)
            {
                query = query.Where(x => x.Enabled).ToList();
            }
            else if (rbInactive.Checked)
            {
                query = query.Where(x => !x.Enabled).ToList();
            }


            dgvRecords.DataSource = query;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoleId = 0;
            pnlSearch.Enabled = false;
            pnlEdit.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (RoleId == 0)
            {
                var role = new Role
                {
                    Title = txtTitleEdit.Text,
                    Description = txtDescriptionEdit.Text,
                    Enabled = chkEnabledEdit.Checked,
                    CreatedDate = DateTime.Now
                };

                db.Role.Add(role);
            }
            else
            {
                var role = db.Role.FirstOrDefault(x=> x.Id == RoleId);
                if (role != null)
                {
                    role.Title = txtTitleEdit.Text;
                    role.Description = txtDescriptionEdit.Text;
                    role.Enabled = chkEnabledEdit.Checked;
                }
            }
            
            var result = db.SaveChanges() > 0;

            if (result)
            {
                ClearControlsEdit();
                GetRecords();
            }
        }

        private void ClearControlsEdit()
        {
            RoleId = 0;
            pnlSearch.Enabled = true;
            pnlEdit.Visible = false;
            txtTitleEdit.Text = string.Empty;
            txtDescriptionEdit.Text = string.Empty;
            chkEnabledEdit.Checked = false;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearControlsEdit();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void dgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowSelected = dgvRecords.Rows[e.RowIndex].Cells[0].Value;
            
            if(rowSelected != null)
            {
                RoleId = Convert.ToInt32(rowSelected);

                var role = db.Role.FirstOrDefault(x => x.Id == RoleId);
                if (role != null)
                {
                    pnlSearch.Enabled = false;
                    pnlEdit.Visible = true;
                    txtTitleEdit.Text = role.Title;
                    txtDescriptionEdit.Text = role.Description;
                    chkEnabledEdit.Checked = role.Enabled;
                    lblCreatedDateEdit.Text = role.CreatedDate.ToString("F");

                    btnRemove.Enabled = true;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void RemoveItem()
        {
            var msgConfirm = MessageBox.Show("Estas Seguro que deseas eliminar el registro?", "Confirmacion de Borrado", MessageBoxButtons.YesNo);
            if (msgConfirm == DialogResult.Yes)
            {
                var role = db.Role.FirstOrDefault(x => x.Id == RoleId);
                if (role != null)
                {
                    db.Role.Remove(role);
                    var result = db.SaveChanges() > 0;

                    ClearControlsEdit();
                    GetRecords();
                }
            }
        }
    }
}
