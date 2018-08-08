using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace GridViewRelease
{

	/// <summary>
	/// Summary description for GridPersister.
	/// </summary>
	public class GridPersister
	{

		private GridView m_GridView = null;
		private string FilePath;

		public GridPersister(GridView theGrid)
		{
			FilePath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) + "\\grid.xml";
			m_GridView = theGrid;
			//
			// TODO: Add constructor logic here
			//
		}

		public void Read()
		{
			XmlTextReader reader = new XmlTextReader(FilePath);
			int rowCount = 0;
			int colCount = 0;
			int colHeaderCount = 0;
			try
			{
				while (reader.Read()) 
				{
					switch (reader.NodeType) 
					{
						case XmlNodeType.Element: // The node is an Element
						switch (reader.Name)
						{
							case "rowheader":
								break;
							case "colheader":
								colHeaderCount++;
								for (int i = 0; i < reader.AttributeCount; i++)
								{
									reader.MoveToAttribute(i);
									switch(reader.Name)
									{
										case "text":
											m_GridView.SetColumnName(colHeaderCount, reader.Value);
											break;
										case "width":
											m_GridView.SetColumnWidthAndIgnoreFont(colHeaderCount, XmlConvert.ToInt32(reader.Value));
											break;
									}
								}

								break;
							case "row":
								rowCount++;
								colCount = 0;
								break;
							case "col":
								colCount++;
								for (int i = 0; i < reader.AttributeCount; i++)
								{
									reader.MoveToAttribute(i);
									switch(reader.Name)
									{
									   case "text":
									    m_GridView.SetCell(rowCount, colCount, reader.Value);
										break;
										case "forecolor":
											m_GridView.SetCellTextColor(rowCount, colCount, Color.FromArgb(Convert.ToInt32(reader.Value)));
											break;
										case "backcolor":
											m_GridView.SetCellColor(rowCount, colCount, Color.FromArgb(Convert.ToInt32(reader.Value)));
											break;
									}
								}
								break;

						}
						break;

					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message.ToString());
			}
		}

		public void Write()
		{
			XmlTextWriter writer = new XmlTextWriter(FilePath, null);
			writer.Formatting = Formatting.Indented;
			writer.Namespaces = true;
			writer.Indentation = 4;

			// write header 

			writer.WriteStartDocument(false);
			writer.WriteStartElement("GridView");

			// write grid attributes column names and widths
			writer.WriteStartElement("rowheader", null);
			for (int j = 1; j <= m_GridView.NumberOfColumns; j++)
			{
				writer.WriteStartElement("colheader", null);
				writer.WriteAttributeString("text", m_GridView.GetColumnName(j));
				writer.WriteAttributeString("width", m_GridView.GetColumnWidth(j).ToString());
				writer.WriteEndElement();
			}
			writer.WriteEndElement();

			// write internal grid

			for (int i = 0; i < m_GridView.NumberOfRows - 1; i++)
			{
				writer.WriteStartElement("row", null);
				for (int j = 0; j < m_GridView.NumberOfColumns; j++)
				{
					writer.WriteStartElement("col", null);
					writer.WriteAttributeString("text", m_GridView.GetCell(i + 1, j + 1));
					writer.WriteAttributeString("backcolor", m_GridView.GetCellColor(i+1, j+1).ToArgb().ToString());
					writer.WriteAttributeString("forecolor", m_GridView.GetCellTextColor(i+1, j+1).ToArgb().ToString());
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
					    
			writer.WriteEndElement();
			writer.Flush();
			writer.Close();
		}


	}
}
