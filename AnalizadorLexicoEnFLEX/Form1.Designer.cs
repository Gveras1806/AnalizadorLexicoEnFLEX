namespace AnalizadorLexicoEnFLEX
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            colorDialog1 = new ColorDialog();
            button1 = new Button();
            anali = new TextBox();
            salida = new TextBox();
            label1 = new Label();
            label2 = new Label();
            LIMP = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.Location = new Point(396, 103);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 0;
            button1.Text = "Analizar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // anali
            // 
            anali.Location = new Point(12, 27);
            anali.Multiline = true;
            anali.Name = "anali";
            anali.Size = new Size(377, 111);
            anali.TabIndex = 2;
            // 
            // salida
            // 
            salida.Location = new Point(12, 172);
            salida.Multiline = true;
            salida.Name = "salida";
            salida.Size = new Size(459, 223);
            salida.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 154);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Analizado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Analizar:";
            // 
            // LIMP
            // 
            LIMP.BackColor = Color.LightCoral;
            LIMP.Font = new Font("Segoe UI Black", 9F, FontStyle.Underline);
            LIMP.ForeColor = SystemColors.Control;
            LIMP.Image = Properties.Resources.icons8_limpiar_48;
            LIMP.Location = new Point(416, 27);
            LIMP.Name = "LIMP";
            LIMP.Size = new Size(55, 53);
            LIMP.TabIndex = 6;
            LIMP.UseVisualStyleBackColor = false;
            LIMP.Click += LIMP_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(483, 404);
            Controls.Add(LIMP);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(salida);
            Controls.Add(anali);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ANALIZADOR LÉXICO EN FLEX-GERMAN VERAS 1-1-0723";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorDialog colorDialog1;
        private Button button1;
        private TextBox anali;
        private TextBox salida;
        private Label label1;
        private Label label2;
        private Button LIMP;
    }
}
