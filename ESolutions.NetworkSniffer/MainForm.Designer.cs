namespace ESolutions.NetworkSniffer
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.connectedClientsListView = new System.Windows.Forms.ListView ();
			this.hostnameColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.ipAddressColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.timeConnectedColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.messagesListView = new System.Windows.Forms.ListView ();
			this.messageColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.hostname2ColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.ipAddress2ColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.timeReceivedColumnHeader = new System.Windows.Forms.ColumnHeader ();
			this.groupBox1 = new System.Windows.Forms.GroupBox ();
			this.groupBox2 = new System.Windows.Forms.GroupBox ();
			this.groupBox1.SuspendLayout ();
			this.groupBox2.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// connectedClientsListView
			// 
			this.connectedClientsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.connectedClientsListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.hostnameColumnHeader,
            this.ipAddressColumnHeader,
            this.timeConnectedColumnHeader});
			this.connectedClientsListView.Font = new System.Drawing.Font ("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectedClientsListView.FullRowSelect = true;
			this.connectedClientsListView.GridLines = true;
			this.connectedClientsListView.Location = new System.Drawing.Point (6, 19);
			this.connectedClientsListView.Name = "connectedClientsListView";
			this.connectedClientsListView.Size = new System.Drawing.Size (670, 206);
			this.connectedClientsListView.TabIndex = 0;
			this.connectedClientsListView.UseCompatibleStateImageBehavior = false;
			this.connectedClientsListView.View = System.Windows.Forms.View.Details;
			this.connectedClientsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler (this.ConnectedClientsListView_ColumnClick);
			// 
			// hostnameColumnHeader
			// 
			this.hostnameColumnHeader.Text = "Hostname";
			this.hostnameColumnHeader.Width = 262;
			// 
			// ipAddressColumnHeader
			// 
			this.ipAddressColumnHeader.Text = "IP Address";
			this.ipAddressColumnHeader.Width = 143;
			// 
			// timeConnectedColumnHeader
			// 
			this.timeConnectedColumnHeader.Text = "Time connected";
			this.timeConnectedColumnHeader.Width = 109;
			// 
			// messagesListView
			// 
			this.messagesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.messagesListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.messageColumnHeader,
            this.hostname2ColumnHeader,
            this.ipAddress2ColumnHeader,
            this.timeReceivedColumnHeader});
			this.messagesListView.Font = new System.Drawing.Font ("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.messagesListView.FullRowSelect = true;
			this.messagesListView.GridLines = true;
			this.messagesListView.Location = new System.Drawing.Point (6, 19);
			this.messagesListView.Name = "messagesListView";
			this.messagesListView.Size = new System.Drawing.Size (670, 260);
			this.messagesListView.TabIndex = 2;
			this.messagesListView.UseCompatibleStateImageBehavior = false;
			this.messagesListView.View = System.Windows.Forms.View.Details;
			this.messagesListView.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler (this.MessagesListView_ItemMouseHover);
			this.messagesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler (this.MessagesListView_ColumnClick);
			this.messagesListView.Leave += new System.EventHandler (this.MessagesListView_Leave);
			// 
			// messageColumnHeader
			// 
			this.messageColumnHeader.Text = "Message";
			this.messageColumnHeader.Width = 237;
			// 
			// hostname2ColumnHeader
			// 
			this.hostname2ColumnHeader.Text = "Hostname";
			this.hostname2ColumnHeader.Width = 112;
			// 
			// ipAddress2ColumnHeader
			// 
			this.ipAddress2ColumnHeader.Text = "IP Address";
			this.ipAddress2ColumnHeader.Width = 122;
			// 
			// timeReceivedColumnHeader
			// 
			this.timeReceivedColumnHeader.Text = "Time received";
			this.timeReceivedColumnHeader.Width = 107;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add (this.connectedClientsListView);
			this.groupBox1.Location = new System.Drawing.Point (12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (682, 232);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connected Clients";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add (this.messagesListView);
			this.groupBox2.Location = new System.Drawing.Point (12, 250);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size (682, 286);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Messages";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (706, 548);
			this.Controls.Add (this.groupBox2);
			this.Controls.Add (this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Network Sniffer";
			this.groupBox1.ResumeLayout (false);
			this.groupBox2.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.ListView connectedClientsListView;
		private System.Windows.Forms.ColumnHeader hostnameColumnHeader;
		private System.Windows.Forms.ColumnHeader ipAddressColumnHeader;
		private System.Windows.Forms.ListView messagesListView;
		private System.Windows.Forms.ColumnHeader hostname2ColumnHeader;
		private System.Windows.Forms.ColumnHeader messageColumnHeader;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader timeReceivedColumnHeader;
		private System.Windows.Forms.ColumnHeader timeConnectedColumnHeader;
		private System.Windows.Forms.ColumnHeader ipAddress2ColumnHeader;

	}
}

