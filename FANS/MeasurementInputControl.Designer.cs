namespace FANS
{
    partial class MeasurementInputControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MeasurementInputGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MeasureFromTextBox = new System.Windows.Forms.TextBox();
            this.MeasureToTextBox = new System.Windows.Forms.TextBox();
            this.MeasurementsNumberTextBox = new System.Windows.Forms.TextBox();
            this.MeasurementStepTextBox = new System.Windows.Forms.TextBox();
            this.MeasurementInputGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MeasurementInputGroup
            // 
            this.MeasurementInputGroup.Controls.Add(this.label4);
            this.MeasurementInputGroup.Controls.Add(this.label3);
            this.MeasurementInputGroup.Controls.Add(this.label2);
            this.MeasurementInputGroup.Controls.Add(this.label1);
            this.MeasurementInputGroup.Controls.Add(this.MeasureFromTextBox);
            this.MeasurementInputGroup.Controls.Add(this.MeasureToTextBox);
            this.MeasurementInputGroup.Controls.Add(this.MeasurementsNumberTextBox);
            this.MeasurementInputGroup.Controls.Add(this.MeasurementStepTextBox);
            this.MeasurementInputGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MeasurementInputGroup.Location = new System.Drawing.Point(0, 0);
            this.MeasurementInputGroup.Name = "MeasurementInputGroup";
            this.MeasurementInputGroup.Size = new System.Drawing.Size(162, 125);
            this.MeasurementInputGroup.TabIndex = 13;
            this.MeasurementInputGroup.TabStop = false;
            this.MeasurementInputGroup.Text = "Value Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Measurements # ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            // 
            // MeasureFromTextBox
            // 
            this.MeasureFromTextBox.Location = new System.Drawing.Point(97, 19);
            this.MeasureFromTextBox.Name = "MeasureFromTextBox";
            this.MeasureFromTextBox.Size = new System.Drawing.Size(56, 20);
            this.MeasureFromTextBox.TabIndex = 2;
            this.MeasureFromTextBox.TextChanged += new System.EventHandler(this.MeasureFromTextBox_TextChanged);
            this.MeasureFromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MeasureFromTextBox_KeyPress);
            this.MeasureFromTextBox.Leave += new System.EventHandler(this.MeasureFromTextBox_Leave);
            // 
            // MeasureToTextBox
            // 
            this.MeasureToTextBox.Location = new System.Drawing.Point(97, 45);
            this.MeasureToTextBox.Name = "MeasureToTextBox";
            this.MeasureToTextBox.Size = new System.Drawing.Size(56, 20);
            this.MeasureToTextBox.TabIndex = 3;
            this.MeasureToTextBox.TextChanged += new System.EventHandler(this.MeasureToTextBox_TextChanged);
            this.MeasureToTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MeasureToTextBox_KeyPress);
            this.MeasureToTextBox.Leave += new System.EventHandler(this.MeasureToTextBox_Leave);
            // 
            // MeasurementsNumberTextBox
            // 
            this.MeasurementsNumberTextBox.Location = new System.Drawing.Point(97, 97);
            this.MeasurementsNumberTextBox.Name = "MeasurementsNumberTextBox";
            this.MeasurementsNumberTextBox.Size = new System.Drawing.Size(56, 20);
            this.MeasurementsNumberTextBox.TabIndex = 5;
            this.MeasurementsNumberTextBox.TextChanged += new System.EventHandler(this.MeasurementsNumberTextBox_TextChanged);
            this.MeasurementsNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MeasurementsNumberTextBox_KeyPress);
            this.MeasurementsNumberTextBox.Leave += new System.EventHandler(this.MeasurementsNumberTextBox_Leave);
            // 
            // MeasurementStepTextBox
            // 
            this.MeasurementStepTextBox.Location = new System.Drawing.Point(97, 71);
            this.MeasurementStepTextBox.Name = "MeasurementStepTextBox";
            this.MeasurementStepTextBox.Size = new System.Drawing.Size(56, 20);
            this.MeasurementStepTextBox.TabIndex = 4;
            this.MeasurementStepTextBox.TextChanged += new System.EventHandler(this.MeasurementStepTextBox_TextChanged);
            this.MeasurementStepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MeasurementStepTextBox_KeyPress);
            this.MeasurementStepTextBox.Leave += new System.EventHandler(this.MeasurementStepTextBox_Leave);
            // 
            // MeasurementInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MeasurementInputGroup);
            this.Name = "MeasurementInputControl";
            this.Size = new System.Drawing.Size(162, 125);
            this.MeasurementInputGroup.ResumeLayout(false);
            this.MeasurementInputGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MeasurementInputGroup;
        private System.Windows.Forms.TextBox MeasureFromTextBox;
        private System.Windows.Forms.TextBox MeasureToTextBox;
        private System.Windows.Forms.TextBox MeasurementsNumberTextBox;
        private System.Windows.Forms.TextBox MeasurementStepTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        

    }
}
