using Encryption.CeaserCypher;
using Encryption.VigenereCypher;
using MCypherWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MCypherWinForms
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
            InitializeFormComponents();
        }

        private void InitializeFormComponents()
        {
            foreach (EnumEncryptionType type in Enum.GetValues(typeof(EnumEncryptionType)))
                cbEncryptionType.Items.Add(type);

            cbEncryptionType.SelectedIndex = 0;
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            var model = CreateModel();
            var valid = ValidateModel(model);

            if (!valid)
            {
                txtResult.Text = string.Empty;
                return;
            }

            switch (model.EncryptionType)
            {
                case EnumEncryptionType.CeaserCipher:
                    var ceaseCipher = new CeaserCypherEncoder(Convert.ToInt32(model.Key));
                    model.CipherText = ceaseCipher.Encode(model.PlainText);
                    break;
                case EnumEncryptionType.VigenereCipher:
                    var vigenereCipher = new VigenereCypherEncoder(model.Key);
                    model.CipherText = vigenereCipher.Encode(model.PlainText);
                    break;
            }

            txtResult.Text = model.CipherText;
        }

        private EncryptionViewModel CreateModel()
        {
            return new EncryptionViewModel
            {
                PlainText = txtPlainText.Text,
                Key = txtKey.Text,
                EncryptionType = (EnumEncryptionType)cbEncryptionType.SelectedItem
            };
        }

        private bool ValidateModel(EncryptionViewModel model)
        {
            errorProvider.Clear();

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (isValid)
                return true;

            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    var control = FindControlByName(this, memberName);

                    if (control != null)
                        errorProvider.SetError(control, validationResult.ErrorMessage);
                }
            }
            return false;
        }

        private Control FindControlByName(Control parent, string name)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Tag?.ToString() == name)
                    return child;

                Control found = FindControlByName(child, name);

                if (found != null)
                    return found;
            }

            return null;
        }
    }
}
