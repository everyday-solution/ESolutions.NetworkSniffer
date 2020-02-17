using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ESolutions.NetworkSniffer
{
	/// <summary>
	/// Used to sort the list view with the connected clients
	/// </summary>
	class ListViewTextComparer : IComparer
	{
		#region column
		/// <summary>
		/// The colum that is used to sort the list view.
		/// </summary>
		private int column;
		#endregion

		#region Column
		/// <summary>
		/// Gets a value indicating the column which is used as the sorting index.
		/// </summary>
		public Int32 Column
		{
			get
			{
				return this.column;
			}
		}
		#endregion

		#region sortOrder
		/// <summary>
		/// The current sort order.
		/// </summary>
		private SortOrder sortOrder;
		#endregion

		#region ToggleSortOrder
		/// <summary>
		/// Toggles through the three SortingOrders: Ascending, Descending;
		/// </summary>
		public void ToggleSortOrder ()
		{
			switch (this.sortOrder)
			{
				case SortOrder.Ascending:
				{
					this.sortOrder = SortOrder.Descending;
					break;
				}

				case SortOrder.Descending:
				{
					this.sortOrder = SortOrder.Ascending;
					break;
				}
			}
		}
		#endregion

		#region ConnectedClientsListViewItemComparer
		/// <summary>
		/// Standard constructor.
		/// </summary>
		public ListViewTextComparer ()
		{
			this.column = 0;
			this.sortOrder = SortOrder.Ascending;
		}
		#endregion

		#region ConnectedClientsListViewItemComparer
		/// <summary>
		/// Constructor taking the column that is used as the sorting index.
		/// </summary>
		/// <param name="column">Number of the colum to use as sorting index.</param>
		public ListViewTextComparer (int column)
		{
			this.column = column;
			this.sortOrder = SortOrder.Ascending;
		}
		#endregion

		#region Compare
		/// <summary>
		/// Compares the text of two ListViewItems. 
		/// </summary>
		/// <param name="x">First ListViewItem for the comparison</param>
		/// <param name="y">Second ListViewItem for the comparison</param>
		/// <returns>True if the first item is greater than the second. False otherwise.</returns>
		public int Compare (object x, object y)
		{
			int result = 0;

			switch (this.sortOrder)
			{
				case SortOrder.Ascending:
				{
					result = String.Compare (
						((ListViewItem)x).SubItems[column].Text,
						((ListViewItem)y).SubItems[column].Text); 
					
					break;
				}

				case SortOrder.Descending:
				{
					result = String.Compare (
						((ListViewItem)y).SubItems[column].Text,
						((ListViewItem)x).SubItems[column].Text); 
					
					break;
				}
			}

			return result;
		}
		#endregion
	}
}
