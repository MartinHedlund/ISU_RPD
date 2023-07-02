namespace WindowsFormsApp8
{
    partial class FormMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonContract = new System.Windows.Forms.Button();
            this.buttonFilial = new System.Windows.Forms.Button();
            this.buttonType = new System.Windows.Forms.Button();
            this.buttonAgent = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonContract
            // 
            this.buttonContract.Location = new System.Drawing.Point(189, 94);
            this.buttonContract.Name = "buttonContract";
            this.buttonContract.Size = new System.Drawing.Size(132, 37);
            this.buttonContract.TabIndex = 0;
            this.buttonContract.Text = "Договора";
            this.buttonContract.UseVisualStyleBackColor = true;
            this.buttonContract.Click += new System.EventHandler(this.buttonContract_Click);
            // 
            // buttonFilial
            // 
            this.buttonFilial.Location = new System.Drawing.Point(189, 137);
            this.buttonFilial.Name = "buttonFilial";
            this.buttonFilial.Size = new System.Drawing.Size(132, 37);
            this.buttonFilial.TabIndex = 1;
            this.buttonFilial.Text = "Филиалы";
            this.buttonFilial.UseVisualStyleBackColor = true;
            this.buttonFilial.Click += new System.EventHandler(this.buttonFilial_Click);
            // 
            // buttonType
            // 
            this.buttonType.Location = new System.Drawing.Point(189, 180);
            this.buttonType.Name = "buttonType";
            this.buttonType.Size = new System.Drawing.Size(132, 42);
            this.buttonType.TabIndex = 2;
            this.buttonType.Text = "Вид страхования";
            this.buttonType.UseVisualStyleBackColor = true;
            this.buttonType.Click += new System.EventHandler(this.buttonType_Click);
            // 
            // buttonAgent
            // 
            this.buttonAgent.Location = new System.Drawing.Point(189, 228);
            this.buttonAgent.Name = "buttonAgent";
            this.buttonAgent.Size = new System.Drawing.Size(132, 36);
            this.buttonAgent.TabIndex = 3;
            this.buttonAgent.Text = "Агенты";
            this.buttonAgent.UseVisualStyleBackColor = true;
            this.buttonAgent.Click += new System.EventHandler(this.buttonAgent_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Location = new System.Drawing.Point(189, 270);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(132, 34);
            this.buttonClient.TabIndex = 4;
            this.buttonClient.Text = "Клиенты";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 414);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonAgent);
            this.Controls.Add(this.buttonType);
            this.Controls.Add(this.buttonFilial);
            this.Controls.Add(this.buttonContract);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonContract;
        private System.Windows.Forms.Button buttonFilial;
        private System.Windows.Forms.Button buttonType;
        private System.Windows.Forms.Button buttonAgent;
        private System.Windows.Forms.Button buttonClient;
    }
}