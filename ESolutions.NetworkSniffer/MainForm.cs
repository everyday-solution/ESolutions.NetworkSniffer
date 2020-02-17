using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ESolutions.Net;

namespace ESolutions.NetworkSniffer
{
	public partial class MainForm : Form
	{
		#region messageToolTip
		ToolTip messageToolTip = new ToolTip ();
		#endregion

		#region hoveredItem
		/// <summary>
		/// My description text.
		private ListViewItem hoveredItem;
		#endregion

		#region adapter
		/// <summary>
		/// Networkadpater accepting connections.
		/// </summary>
		private ESolutions.Net.NetworkAdapter adapter;
		#endregion

		#region MainForm
		/// <summary>
		/// Constructor creating the networkadapter and starts Listening
		/// </summary>
		public MainForm ()
		{
			InitializeComponent ();
			this.adapter = new ESolutions.Net.NetworkAdapter (Dns.GetHostAddresses (Properties.Settings.Default.ListeningAddress)[0]);
			this.adapter.PackageReceived += new ESolutions.Net.PackageReceivedEventHandler (Adapter_PackageReceived);
			this.adapter.ConnectionAccepted += new ESolutions.Net.ConnectionAcceptedEventHandler (Adapter_ConnectionAccepted);
			this.adapter.AfterConnectionClosed += new ESolutions.Net.AfterConnectionClosedEventHandler (Adapter_AfterConnectionClosed);
			this.adapter.StartListening (Properties.Settings.Default.ListeningPort);
		}
		#endregion

		#region Adapter_AfterConnectionClosed
		/// <summary>
		/// Removes clients from the ConnectedClientListView after the connection was terminated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Marshals the call to the gui thread and then removes the closed connectio from the connectedClientListView.
		/// </remarks>
		void Adapter_AfterConnectionClosed (
			object sender,
			AfterConnectionClosedEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke (new AfterConnectionClosedEventHandler (Adapter_AfterConnectionClosed), new object[] { sender, e });
			}
			else
			{
				if (connectedClientsListView.Items.Count > 0)
				{
					int index = 0;
					Boolean found = false;

					while (found == false && index < this.connectedClientsListView.Items.Count)
					{
						if (connectedClientsListView.Items[index].Tag == e.Connection)
						{
							connectedClientsListView.Items[index].Remove ();
							found = true;
						}

						index++;
					}
				}
			}
		}
		#endregion

		#region Adapter_ConnectionAccepted
		/// <summary>
		/// When new connections from NetworkTraceListeners are accepted the method adds
		/// the new client to the connected client listview.
		/// </summary>
		/// <param name="sender">Sender of the message should be a NetworkAdapter</param>
		/// <param name="e">Parameters for the event. Containing the accepted connection</param>
		/// <remarks>
		/// Marshals the call to the gui thread an then adds the new client to the
		/// connectedclient listbox.
		/// </remarks>
		void Adapter_ConnectionAccepted (
			object sender,
			ESolutions.Net.ConnectionAcceptedEventArgs e)
		{
			if (InvokeRequired)
			{
				Delegate thisMethod = new ConnectionAcceptedEventHandler (Adapter_ConnectionAccepted);

				Invoke (thisMethod, new object[] { sender, e });
			}
			else
			{
				System.Net.IPHostEntry entry = System.Net.Dns.GetHostEntry (
					e.Connection.FarEndPoint.Address);

				String[] itemStrings = new String[] { 
					entry.HostName, 
					e.Connection.FarEndPoint.ToString(),
					DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString ()};

				ListViewItem newItem = new ListViewItem (
					itemStrings);

				newItem.Tag = e.Connection;

				this.connectedClientsListView.Items.Add (newItem);
			}
		}
		#endregion

		#region Adapter_PackageReceived
		/// <summary>
		/// The adapter received a package from a NetworkTraceListener.
		/// </summary>
		/// <param name="sender">Adapter sending the event.</param>
		/// <param name="e">Parameters for this event including the connection that was used for transmission.</param>
		/// <remarks>
		/// The call is marshaled to the gui thread and then adds the message to the message window.
		/// </remarks>
		void Adapter_PackageReceived (
			object sender,
			ESolutions.Net.PackageReceivedEventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke (new ESolutions.Net.PackageReceivedEventHandler (Adapter_PackageReceived), new object[] { sender, e });
			}
			else
			{
				System.Net.IPHostEntry entry = System.Net.Dns.GetHostEntry (
					e.Connection.FarEndPoint.Address);

				String[] values = new String[] {
					e.Package.Payload,
					entry.HostName,
					e.Connection.FarEndPoint.ToString (),
					DateTime.Now.ToShortDateString () + " - " + DateTime.Now.ToLongTimeString() };

				ListViewItem newItem = new ListViewItem (values);

				messagesListView.Items.Insert (
					0,
					newItem);
			}
		}
		#endregion

		#region ConnectedClientsListView_ColumnClick
		/// <summary>
		/// A column header of the connectedClientsListView is clicked and sorted accordingly to the data in the column.
		/// </summary>
		/// <param name="sender">Sender of the event should be a list view.</param>
		/// <param name="e">Arguments for this message.</param>
		private void ConnectedClientsListView_ColumnClick (object sender, ColumnClickEventArgs e)
		{
			ListViewTextComparer currentComparer = connectedClientsListView.ListViewItemSorter as ListViewTextComparer;

			if (currentComparer == null || currentComparer.Column != e.Column)
			{
				connectedClientsListView.ListViewItemSorter = new ListViewTextComparer (e.Column);
			}
			else
			{
				currentComparer.ToggleSortOrder ();
				connectedClientsListView.Sort ();
			}
		}
		#endregion

		#region MessagesListView_ColumnClick
		/// <summary>
		/// A column header of the messagesListView is clicked and sorted accordingly to the data in the column.
		/// </summary>
		/// <param name="sender">Sender of this message.</param>
		/// <param name="e">Arguments for this message.</param>
		private void MessagesListView_ColumnClick (object sender, ColumnClickEventArgs e)
		{
			ListViewTextComparer currentComparer = messagesListView.ListViewItemSorter as ListViewTextComparer;

			if (currentComparer == null || currentComparer.Column != e.Column)
			{
				messagesListView.ListViewItemSorter = new ListViewTextComparer (e.Column);
			}
			else
			{
				currentComparer.ToggleSortOrder ();
				messagesListView.Sort ();
			}
		}
		#endregion

		#region MessagesListView_ItemMouseHover
		private void MessagesListView_ItemMouseHover (object sender, ListViewItemMouseHoverEventArgs e)
		{
			if (this.hoveredItem != e.Item)
			{
				Point toolTipPosition = this.messagesListView.PointToClient (Cursor.Position);

				messageToolTip.Show (
					e.Item.SubItems[0].Text,
					this.messagesListView,
					toolTipPosition.X + Cursor.Size.Width,
					toolTipPosition.Y,
					4000);

				this.hoveredItem = e.Item;
			}
		}
		#endregion

		#region MessagesListView_Leave
		private void MessagesListView_Leave (object sender, EventArgs e)
		{
			this.messageToolTip.Hide (this.messagesListView);
		}
		#endregion
	}
}