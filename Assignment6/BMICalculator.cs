using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Shivya Balachandran
// 300 884 989
// 08/02/16 

namespace Assignment6
{
    /**
  * <summary>
  * This class contains the BMI calculator 
  * </summary>
  * 
  * @class BMICalculator
  */
    public partial class BMICalculator : Form
    {
        private bool _blockKeyPress;

        /**
     * <summary>
     * This constructor builds the BMI caclutator form 
     * </summary>
     * 
     * @constructor
     */
        public BMICalculator()
        {
            InitializeComponent();
        }
        /**
     * <summary>
     * This event handler calculates the BMI 
     * </summary>
     * 
     * @method CalculateButton_Click
     * @param {object} sender
     * @param {EventArgs} e
     */
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string heightString = HeightTextBox.Text;
            double height;
            try
            {
                height = Convert.ToDouble(heightString);
            }
            catch
            {
                MessageBox.Show("Invalid height");
                return;
            }
            string weightString = WeightTextBox.Text;
            double weight;
            try
            {
                weight = Convert.ToDouble(weightString);
            }
            catch
            {
                MessageBox.Show("Invalid weight");
                return;
            }
            double bmi;

            if (ImperialRadio.Checked)
            {
                bmi = (weight*703) / (height*height);
            }
            else
            {
                bmi = (weight) / (height * height);
            }

            BMITextBox.Text = string.Format("Your BMI is {0:f2}.", bmi);
        }

        /**
      * <summary>
      * This event handler resets the form
      * </summary>
      * 
      * @method ResetButton_Click
      * @param {object} sender
      * @param {EventArgs} e
      */
        private void ResetButton_Click(object sender, EventArgs e)
        {
            BMITextBox.Text = "";
            WeightTextBox.Text = "";
            HeightTextBox.Text = "";
        }

        /**
        * <summary>
        * This event handler checks keys to see if they are allowed 
        * </summary>
        * 
        * @method NumericTextBox_KeyDown
        * @param {object} sender
        * @param {KeyEventArgs} e
        */
        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            _blockKeyPress = false;

            // block ctrl and shift
            if (e.Control || e.Shift)
            {
                _blockKeyPress = true;
                return;
            }

            // allow number keys
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                return;
            }

            // allow numpad keys
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                return;
            }

            // allow period
            if (e.KeyCode == Keys.OemPeriod)
            {
                return;
            }

            // allow backspace and delete
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                return;
            }

            // allow left and right arrow keys
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                return;
            }

            _blockKeyPress = true;
        }
        /**
     * <summary>
     * This event blocks key presses if they were not allowed
     * </summary>
     * 
     * @method NumericTextBox_KeyPress
     * @param {object} sender
     * @param {KeyPressEventArgs} e
     */
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _blockKeyPress;
        }
    }
}
