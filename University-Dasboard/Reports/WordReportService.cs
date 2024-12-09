using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Reports.Models;

namespace University_Dasboard.Reports
{
	public class WordReportService
	{
		private Document _document = null;

		private Body _body = null;

		private DocumentFormat.OpenXml.Wordprocessing.Table _table = null;

		// Свойство для создания или получения документа
		private Document Document
		{
			get
			{
				if (_document == null)
				{
					_document = new Document();
				}

				return _document;
			}
		}

		// Свойство для создания или получения содержимого (Body) документа
		private Body Body
		{
			get
			{
				if (_body == null)
				{
					_body = Document.AppendChild(new Body());
				}

				return _body;
			}
		}

		// Свойство для создания или получения таблицы
		private DocumentFormat.OpenXml.Wordprocessing.Table Table
		{
			get
			{
				if (_table == null)
				{
					_table = new DocumentFormat.OpenXml.Wordprocessing.Table();
				}

				return _table;
			}
		}

		public void CreateWordReport<T>(WordWithTableDataConfig<T> config, string filePath)
		{
			using (var wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
			{
				// Создать главный документ
				var mainPart = wordDocument.AddMainDocumentPart();
				mainPart.Document = new Document(new Body());

				var body = mainPart.Document.Body;

				// Настройка ориентации страницы
				SetLandscapeOrientation(mainPart);

				// Добавить заголовок
				AddTitle(config.Header);

				// Добавить таблицы
				//foreach (var tableConfig in config.Tables)
				//{
				//	AddTableSection(body, tableConfig);
				//}

				// Добавить пожелания
				//AddFooter(config.Footer);
			}
		}

		private static void SetLandscapeOrientation(MainDocumentPart mainPart)
		{
			SectionProperties sectionProps = new SectionProperties(
				new PageSize { Orient = PageOrientationValues.Landscape });
			mainPart.Document.Body.Append(sectionProps);
		}

		private void AddTitle(string header)
		{
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());

			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
		}

		private void AddTableSection<T>(Body body, WordWithTableDataConfig<T> tableConfig)
		{
			// Добавить подзаголовок
			if (!string.IsNullOrEmpty(tableConfig.Header))
			{
				var paragraph = new Paragraph(new Run(new Text(tableConfig.Header)))
				{
					ParagraphProperties = new ParagraphProperties
					{
						Justification = new Justification { Val = JustificationValues.Left },
						SpacingBetweenLines = new SpacingBetweenLines { Before = "200", After = "100" },
						//RunProperties = new RunProperties(new Bold())
					}
				};
				body.AppendChild(paragraph);
			}

			// Создать таблицу
			var table = new Table();
			table.AppendChild(new TableProperties(new TableBorders
			{
				TopBorder = new TopBorder { Val = BorderValues.Single, Size = 12 },
				BottomBorder = new BottomBorder { Val = BorderValues.Single, Size = 12 },
				LeftBorder = new LeftBorder { Val = BorderValues.Single, Size = 12 },
				RightBorder = new RightBorder { Val = BorderValues.Single, Size = 12 },
				InsideHorizontalBorder = new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
				InsideVerticalBorder = new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 }
			}));

			// Добавить строки заголовков
			var headerRow = new TableRow();
			foreach (var header in tableConfig.Headers)
			{
				//headerRow.AppendChild(CreateCell(header, bold: true));
			}
			table.AppendChild(headerRow);

			// Добавить данные
			foreach (var item in tableConfig.Data)
			{
				var dataRow = new TableRow();
				foreach (var header in tableConfig.Headers)
				{
					//var value = item.GetType().GetProperty(header)?.GetValue(item)?.ToString() ?? "";
					//dataRow.AppendChild(CreateCell(value));
				}
				table.AppendChild(dataRow);
			}

			body.AppendChild(table);
		}

		private void AddFooter(Body body, string footer)
		{
			if (!string.IsNullOrEmpty(footer))
			{
				var paragraph = new Paragraph(new Run(new Text(footer)))
				{
					ParagraphProperties = new ParagraphProperties
					{
						Justification = new Justification { Val = JustificationValues.Left },
						SpacingBetweenLines = new SpacingBetweenLines { Before = "200" },
						//RunProperties = new RunProperties(new Italic())
					}
				};
				body.AppendChild(paragraph);
			}
		}

		private void AddTitle(Body body, string title)
		{
			var paragraph = new Paragraph(new Run(new Text(title)))
			{
				ParagraphProperties = new ParagraphProperties
				{
					Justification = new Justification { Val = JustificationValues.Center },
					SpacingBetweenLines = new SpacingBetweenLines { After = "200" }
				}
			};
			body.AppendChild(paragraph);
		}

		//private void AddTableSection<T>(Body body, WordWithTableDataConfig<T> tableConfig)
		//{
		//	// Добавить подзаголовок
		//	if (!string.IsNullOrEmpty(tableConfig.Header))
		//	{
		//		var paragraph = new Paragraph(new Run(new Text(tableConfig.Header)))
		//		{
		//			ParagraphProperties = new ParagraphProperties
		//			{
		//				Justification = new Justification { Val = JustificationValues.Left },
		//				SpacingBetweenLines = new SpacingBetweenLines { Before = "200", After = "100" },
		//									RunProperties = new RunProperties(new Bold())
		//			}
		//		};
		//		body.AppendChild(paragraph);
		//	}

		//	// Создать таблицу
		//	var table = new Table();
		//	table.AppendChild(new TableProperties(new TableBorders
		//	{
		//		TopBorder = new TopBorder { Val = BorderValues.Single, Size = 12 },
		//		BottomBorder = new BottomBorder { Val = BorderValues.Single, Size = 12 },
		//		LeftBorder = new LeftBorder { Val = BorderValues.Single, Size = 12 },
		//		RightBorder = new RightBorder { Val = BorderValues.Single, Size = 12 },
		//		InsideHorizontalBorder = new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
		//		InsideVerticalBorder = new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 }
		//	}));

		//	// Добавить строки заголовков
		//	var headerRow = new TableRow();
		//	foreach (var header in tableConfig.Headers)
		//	{
		//		headerRow.AppendChild(CreateCell(header, bold: true));
		//	}
		//	table.AppendChild(headerRow);

		//	// Добавить данные
		//	foreach (var item in tableConfig.Data)
		//	{
		//		var dataRow = new TableRow();
		//		foreach (var header in tableConfig.Headers)
		//		{
		//			var value = item.GetType().GetProperty(header)?.GetValue(item)?.ToString() ?? "";
		//			dataRow.AppendChild(CreateCell(value));
		//		}
		//		table.AppendChild(dataRow);
		//	}

		//	body.AppendChild(table);
		//}

		//private void AddFooter(string footer)
		//{
		//	if (!string.IsNullOrEmpty(footer))
		//	{
		//		var paragraph = new Paragraph(new Run(new Text(footer)))
		//		{
		//			ParagraphProperties = new ParagraphProperties
		//			{
		//				Justification = new Justification { Val = JustificationValues.Left },
		//				SpacingBetweenLines = new SpacingBetweenLines { Before = "200" },
		//				RunProperties = new RunProperties(new Italic())
		//			}
		//		};

		//		body.AppendChild(paragraph);
		//	}
		//}

		private TableCell CreateCell(string text, bool bold = false)
		{
			var run = new Run(new Text(text));
			if (bold)
				run.RunProperties = new RunProperties(new Bold());

			return new TableCell(new Paragraph(run));
		}
	}
}
