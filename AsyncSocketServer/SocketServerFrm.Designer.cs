namespace AsyncSocketServer
{
    partial class SocketServerFrm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnAcceptIncomingAsyncConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAcceptIncomingAsyncConn
            // 
            this.btnAcceptIncomingAsyncConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptIncomingAsyncConn.Location = new System.Drawing.Point(27, 371);
            this.btnAcceptIncomingAsyncConn.Name = "btnAcceptIncomingAsyncConn";
            this.btnAcceptIncomingAsyncConn.Size = new System.Drawing.Size(317, 67);
            this.btnAcceptIncomingAsyncConn.TabIndex = 1;
            this.btnAcceptIncomingAsyncConn.Text = "Accept Incoming Async Connection";
            this.btnAcceptIncomingAsyncConn.UseVisualStyleBackColor = true;
            this.btnAcceptIncomingAsyncConn.Click += new System.EventHandler(this.btnAcceptIncomingAsyncConn_Click);
            // 
            // SocketServerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAcceptIncomingAsyncConn);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SocketServerFrm";
            this.ShowIcon = false;
            this.Text = "Socket Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAcceptIncomingAsyncConn;
    }
}

