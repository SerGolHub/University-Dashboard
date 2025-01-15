using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using OfficePackage.HelperEnums;
using OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.Implements
{
    public class SaveToPdf : AbstractSaveToPdf
    {
        private Document? _document;
        private Section? _section;
        private Table? _table;

        // Преобразование необходимого типа выравнивания
        private static ParagraphAlignment GetParagraphAlignment(PdfParagraphAlignmentType type)
        {
            return type switch
            {
                PdfParagraphAlignmentType.Center => ParagraphAlignment.Center,
                PdfParagraphAlignmentType.Left => ParagraphAlignment.Left,
                PdfParagraphAlignmentType.Right => ParagraphAlignment.Right,
                _ => ParagraphAlignment.Justify,
            };
        }

        // Создание стилей для документа
        private static void DefineStyles(Document document)
        {
            // Стиль для обычного текста
            var style = document.Styles["Normal"];
            style!.Font.Name = "Times New Roman";
            style.Font.Size = 14;

            // Стиль для заголовков
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style.Font.Bold = true;

            // Стиль для заголовков
            style = document.Styles.AddStyle("TableText", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;
        }

        protected override void CreatePdf(PdfInfo info)
        {
            // Создаём документ
            _document = new Document();

            // Передаём для него стили
            DefineStyles(_document);

            // Получение первой секции документа
            _section = _document.AddSection();

            // Устанавливаем ориентацию страницы на альбомную
            _section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
        }

        protected override void CreateParagraph(PdfParagraph pdfParagraph)
        {
            if (_section == null)
            {
                return;
            }

            // Создаём параграф
            var paragraph = _section.AddParagraph(pdfParagraph.Text);
            paragraph.Format.SpaceAfter = "0.2cm";
            paragraph.Format.Alignment = GetParagraphAlignment(pdfParagraph.ParagraphAlignment);

            // Если заданы Spans, добавляем текст с форматированием
            if (pdfParagraph.Spans.Any())
            {
                foreach (var span in pdfParagraph.Spans)
                {
                    var formattedText = paragraph.AddFormattedText(span.Text);

                    // Устанавливаем шрифт
                    if (!string.IsNullOrEmpty(span.Font))
                    {
                        formattedText.Font.Name = span.Font;
                    }

                    // Устанавливаем жирность
                    if (span.FontWeight == "Bold")
                    {
                        formattedText.Bold = true;
                    }

                    // Устанавливаем подчёркивание
                    if (span.Underline)
                    {
                        formattedText.Underline = Underline.Single;
                    }
                }
            }

            // Устанавливаем стиль параграфа
            if (pdfParagraph.Style == "Title")
            {
                paragraph.Style = "NormalTitle";  // Используем стиль для заголовков
            }
            else
            {
                paragraph.Style = "Normal";  // Используем стиль для обычного текста
            }
        }

        protected override void CreateTable(List<string> columns)
        {
            if (_document == null)
            {
                return;
            }

            // Добавляем таблицу в документ как последнюю секцию
            _table = _document.LastSection.AddTable();

            foreach (var elem in columns)
            {
                _table.AddColumn(elem);
            }
        }

        // Реализация разрыва страницы
        protected override void CreatePageBreak()
        {
            // Создание нового раздела для разрыва страницы
            _section = _document!.AddSection(); // Это добавляет новый раздел, который будет начинаться с новой страницы
        }

        protected override void CreateRow(PdfRowParameters rowParameters)
        {
            if (_table == null)
            {
                return;
            }

            // Проверяем, что количество ячеек в строке соответствует количеству столбцов
            if (rowParameters.Texts.Count != _table.Columns.Count)
            {
                throw new InvalidOperationException("The number of row cells does not match the number of columns in the table.");
            }

            // Добавляем новую строку
            var row = _table.AddRow();

            // Инициализируем MergeColumns и MergeRows, если они равны null
            if (rowParameters.MergeColumns1 == null) rowParameters.MergeColumns1 = new List<int>();

            // Инициализируем MergeColumns и MergeRows, если они равны null
            if (rowParameters.MergeColumns2 == null) rowParameters.MergeColumns2 = new List<int>();

            if (rowParameters.MergeRows == null) rowParameters.MergeRows = new List<int>();

            // Индикатор текущей ячейки для объединения
            int mergeStartIndex = -1;

            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                var cell = row.Cells[i];

                // Если требуется вертикальный текст
                if (rowParameters.Rotations.Count > i && rowParameters.Rotations[i] != 0)
                {
                    // Добавляем TextFrame для перевёрнутого текста
                    var textFrame = cell.AddTextFrame();
                    textFrame.Orientation = TextOrientation.Upward; // Вертикальная ориентация текста
                    var paragraph = textFrame.AddParagraph(rowParameters.Texts[i]);

                    // Устанавливаем отступы для центрирования текста в ячейке
                    textFrame.MarginTop = 0;
                    textFrame.MarginBottom = 0;

                    // Выравнивание текста внутри TextFrame
                    paragraph.Format.Alignment = rowParameters.ParagraphAlignment switch
                    {
                        PdfParagraphAlignmentType.Left => ParagraphAlignment.Left,
                        PdfParagraphAlignmentType.Center => ParagraphAlignment.Center,
                        PdfParagraphAlignmentType.Right => ParagraphAlignment.Right,
                        _ => ParagraphAlignment.Center,
                    };

                    // Центрирование TextFrame внутри ячейки
                    textFrame.RelativeVertical = RelativeVertical.Line; // Выравнивание относительно строки
                    textFrame.WrapFormat.Style = WrapStyle.None; // Отключение обтекания текста
                    textFrame.Top = ShapePosition.Center; // Центрирование вертикально
                    textFrame.Left = ShapePosition.Center; // Центрирование горизонтально
                }
                else
                {
                    // Горизонтальный текст
                    cell.AddParagraph(rowParameters.Texts[i]);
                }

                if (!string.IsNullOrEmpty(rowParameters.Style))
                {
                    cell.Style = rowParameters.Style;
                }

                // Устанавливаем стиль границ ячеек
                var borderWidth = Unit.FromPoint(0.5);
                cell.Borders.Left.Width = borderWidth;
                cell.Borders.Right.Width = borderWidth;
                cell.Borders.Top.Width = borderWidth;
                cell.Borders.Bottom.Width = borderWidth;

                // Устанавливаем выравнивание текста в ячейке
                cell.Format.Alignment = GetParagraphAlignment(rowParameters.ParagraphAlignment);
                cell.VerticalAlignment = VerticalAlignment.Center;

                // Если текущий индекс находится в списке MergeColumns
                if (rowParameters.MergeColumns1.Contains(i))
                {
                    // Если это первая ячейка для объединения, запоминаем её индекс
                    if (mergeStartIndex == -1)
                    {
                        mergeStartIndex = i;
                    }

                    // Если следующая ячейка также в списке MergeColumns, продолжаем объединение
                    if (i < rowParameters.Texts.Count - 1 && rowParameters.MergeColumns1.Contains(i + 1))
                    {
                        // Объединяем с правой ячейкой
                        cell.MergeRight = 1;
                    }
                    else
                    {
                        // Если следующая ячейка не в списке MergeColumns, завершили объединение
                        if (mergeStartIndex != -1 && i > mergeStartIndex)
                        {
                            // Объединяем все ячейки от mergeStartIndex до текущей ячейки
                            row.Cells[mergeStartIndex].MergeRight = i - mergeStartIndex;
                            mergeStartIndex = -1; // Сбрасываем индекс начала объединения
                        }
                    }
                }

                // Если текущий индекс находится в списке MergeColumns
                if (rowParameters.MergeColumns2.Contains(i))
                {
                    // Если это первая ячейка для объединения, запоминаем её индекс
                    if (mergeStartIndex == -1)
                    {
                        mergeStartIndex = i;
                    }

                    // Если следующая ячейка также в списке MergeColumns, продолжаем объединение
                    if (i < rowParameters.Texts.Count - 1 && rowParameters.MergeColumns2.Contains(i + 1))
                    {
                        // Объединяем с правой ячейкой
                        cell.MergeRight = 1;
                    }
                    else
                    {
                        // Если следующая ячейка не в списке MergeColumns, завершили объединение
                        if (mergeStartIndex != -1 && i > mergeStartIndex)
                        {
                            // Объединяем все ячейки от mergeStartIndex до текущей ячейки
                            row.Cells[mergeStartIndex].MergeRight = i - mergeStartIndex;
                            mergeStartIndex = -1; // Сбрасываем индекс начала объединения
                        }
                    }
                }

                if (rowParameters.MergeRows.Count > i)
                {
                    cell.MergeDown = rowParameters.MergeRows[i];
                }
            }
        }

        protected override void CreateBulletList(List<string> items)
        {
            if (_section == null || items == null || items.Count == 0)
            {
                return;
            }

            // Создаём маркированный список
            foreach (var item in items)
            {
                var paragraph = _section.AddParagraph();
                paragraph.AddFormattedText("• ", TextFormat.Bold); // Символ маркера
                paragraph.AddText(item); // Текст элемента списка
                paragraph.Format.SpaceAfter = "0.2cm"; // Отступ между строками
                paragraph.Format.LeftIndent = "1cm"; // Отступ списка
                paragraph.Format.Alignment = ParagraphAlignment.Justify; // Выравнивание текста
            }
        }

        
        protected override void SavePdf(PdfInfo info)
        {
            var renderer = new PdfDocumentRenderer(true)
            {
                Document = _document!
            };

            _section = _document!.AddSection();

            // Рендерим документ в PDF
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
    }
}
