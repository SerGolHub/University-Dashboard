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
	// Implementation class for reports with tables
	public class WordWithTableReport : WordReportBase
	{
		private readonly WordWithTableConfig _tableConfig;

		public WordWithTableReport(WordWithTableConfig config) : base(config)
		{
			_tableConfig = config;
		}

		public override void GenerateReport(string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

			using (var wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
			{
				var mainPart = wordDocument.AddMainDocumentPart();
				mainPart.Document = new Document(new Body());
				var body = mainPart.Document.Body;

				// Настраиваем ориентацию страницы и поля
				SetPageOrientation(mainPart);

				// Заголовок
				if (!string.IsNullOrEmpty(_tableConfig.Header))
				{
					AddTextElement(body!, _tableConfig.Header, justification: JustificationValues.Center);
				}

				// Таблица
				var table = CreateTable();

				body!.AppendChild(table);

				// Нижний колонтитул
				if (!string.IsNullOrEmpty(_tableConfig.Footer))
				{
					AddTextElement(body, _tableConfig.Footer, justification: JustificationValues.Left);
				}
			}
		}

		private Table CreateTable()
		{
			var table = new Table();

			// Apply table properties
			table.AppendChild(new TableProperties(new TableBorders
			{
				TopBorder = new TopBorder { Val = BorderValues.Single, Size = 12 },
				BottomBorder = new BottomBorder { Val = BorderValues.Single, Size = 12 },
				LeftBorder = new LeftBorder { Val = BorderValues.Single, Size = 12 },
				RightBorder = new RightBorder { Val = BorderValues.Single, Size = 12 },
				InsideHorizontalBorder = new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
				InsideVerticalBorder = new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 },
			}));

			// Заголовок таблицы
			var headerRow = new TableRow();

			foreach (var header in _tableConfig.Headers)
			{
				headerRow.AppendChild(CreateCell(header.Header, bold: true, isHeader: true));
			}

			table.AppendChild(headerRow);

			// Add data rows
			for (int i = 0; i < _tableConfig.ColumnsRowsDataCount.Rows; i++)
			{
				var dataRow = new TableRow();

				foreach (var header in _tableConfig.Headers)
				{

					// Для "Форма занятий" (первый столбец)
					if (header.ColumnIndex == 0 && header.RowIndex == i)
					{
						dataRow.AppendChild(CreateCell("1. ЛЕКЦИИ"));
					}
					// Для "Лекции" (вторая строка)
					if (header.RowIndex == i && header.ColumnIndex == 0)
					{
						dataRow.AppendChild(CreateCell("аудит."));
					}

					if (header.ColumnIndex == 0 && header.RowIndex == 5)
					{
						dataRow.AppendChild(CreateCell("2. ЛАБОРАТОРНЫЕ"));
					}

					// Для "Лекции" (вторая строка)
					if (header.RowIndex == 5 && header.ColumnIndex == 0)
					{
						dataRow.AppendChild(CreateCell("аудит."));
					}
					
					dataRow.AppendChild(CreateCell($"{header.PropertyName} (Row {i})"));
				}

				table.AppendChild(dataRow);
			}

			return table;
		}

		private TableCell CreateCell(string text, bool bold = false, bool isHeader = false)
		{
			var run = new Run(new Text(text));

			if (bold)
				run.RunProperties = new RunProperties(new Bold());

			// Создаём новый параграф для каждой ячейки
			var paragraph = new Paragraph(run);

			// Если это ячейка заголовка, выравниваем текст по центру
			if (isHeader)
			{
				paragraph.ParagraphProperties = new ParagraphProperties(
					new Justification { Val = JustificationValues.Center }
				);
			}

			// Создаём TableCell и устанавливаем вертикальное выравнивание
			var tableCell = new TableCell(paragraph);

			// Вертикальное выравнивание по центру для ячеек
			tableCell.TableCellProperties = new TableCellProperties(
				new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
			);

			return tableCell;
		}
	}
}
