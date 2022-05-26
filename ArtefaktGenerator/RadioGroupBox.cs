using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class RadioGroupBox : GroupBox
    {
        public event EventHandler SelectedChanged = delegate { };

        int _selected;
        public int Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                int val = 0;
                List<RadioButton> radioButton = new List<RadioButton>();

                foreach (Control control in this.Controls)
                {
                    if (control is RadioButton)
                        radioButton.Add((RadioButton)control);
                }


                //RadioButton res = null;
                foreach (RadioButton radio in radioButton)
                {
                    if (radio.Tag != null)
                    {
                        int.TryParse(radio.Tag.ToString(), out val);
                        if (val == value)
                        {
                            radio.Checked = true;
                            _selected = value;
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            var radioButton = e.Control as RadioButton;
            if (radioButton != null)
                radioButton.CheckedChanged += radioButton_CheckedChanged;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            int val = 0;
            if (radio.Checked && radio.Tag != null
                 && int.TryParse(radio.Tag.ToString(), out val))
            {
                _selected = val;
                SelectedChanged(this, new EventArgs());
            }
        }
    }
}
