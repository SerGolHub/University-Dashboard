using ClassroomSchedulerBusinessLogic.OfficePackage.HelperEnums;
using ClassroomSchedulerBusinessLogic.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MigraDoc.DocumentObjectModel.Shapes;
using PdfSharp.Drawing.BarCodes;
using System;
using System.Collections.Generic;

namespace ClassroomSchedulerBusinessLogic.OfficePackage.Implements
{
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument? _wordDocument;
        private Body? _docBody;
        private Table? _currentTable;

        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            return type switch
            {
                WordJustificationType.Left => JustificationValues.Left,
                WordJustificationType.Center => JustificationValues.Center,
                WordJustificationType.Right => JustificationValues.Right,
                WordJustificationType.Both => JustificationValues.Both,
                _ => JustificationValues.Left
            };
        }

        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize { Orient = PageOrientationValues.Portrait };
            properties.AppendChild(pageSize);
            return properties;
        }

        protected override void CreateWord(WordInfo info)
        {
            _wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document);
            var mainPart = _wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            _docBody = mainPart.Document.AppendChild(new Body());
        }

        protected override void CreateParagraph(WordParagraph paragraph)
        {
            if (_docBody == null || paragraph == null) return;

            var docParagraph = new Paragraph
            {
                ParagraphProperties = new ParagraphProperties
                {
                    Justification = new Justification { Val = GetJustificationValues(paragraph.Texts.FirstOrDefault().Item2.JustificationType) }
                }
            };

            foreach (var (text, properties) in paragraph.Texts)
            {
                var docRun = new Run();
                var runProperties = new RunProperties();

                if (!string.IsNullOrEmpty(properties.Size))
                {
                    runProperties.AppendChild(new FontSize { Val = properties.Size });
                }

                if (properties.Bold)
                {
                    runProperties.AppendChild(new Bold());
                }

                // Подчеркивание текста
                if (properties.Underline)
                {
                    runProperties.AppendChild(new Underline { Val = UnderlineValues.Single });
                }

                if (properties.Indentation)
                {
                    runProperties.AppendChild(new Indentation { Left = "100" }); // Отступ слева для первой строки
                }

                if (properties.SpaceBeetween)
                {
                    runProperties.AppendChild(new SpacingBetweenLines { Before = "480" });
                }

                // Установка шрифта "Times New Roman"
                runProperties.AppendChild(new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" });

                docRun.AppendChild(runProperties);
                docRun.AppendChild(new Text { Text = text, Space = SpaceProcessingModeValues.Preserve });
                docParagraph.AppendChild(docRun);
            }

            _docBody.AppendChild(docParagraph);
        }

        protected override void CreateTableHeader(List<string> columnNames)
        {
            _currentTable = new Table();

            // Установка общих свойств таблицы
            var tableProperties = new TableProperties(
                new TableWidth { Width = "150", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                )
            );
            _currentTable.AppendChild(tableProperties);

            // Создание строки заголовков
            var headerRow = new TableRow();

            foreach (var column in columnNames)
            {
                // Создание ячейки с текстом заголовка
                var cell = new TableCell();

                // Настройка отступов для ячейки
                var cellProperties = new TableCellProperties(
                    new TableCellMargin(
                        new LeftMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                        new RightMargin { Width = "100", Type = TableWidthUnitValues.Dxa }
                    )
                );
                cell.AppendChild(cellProperties);

                // Создание текста с центровкой
                var paragraph = new Paragraph(
                    new ParagraphProperties(
                        new Justification { Val = JustificationValues.Center } // Центровка текста
                    ),
                    new Run(
                        new RunProperties(
                            new Bold(), // Жирный текст
                            new FontSize { Val = "24" }, // Размер шрифта (12 pt)
                            new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }
                        ),
                        new Text(column)
                    )
                );

                cell.AppendChild(paragraph);
                headerRow.AppendChild(cell);
            }

            _currentTable.AppendChild(headerRow);
            _docBody!.AppendChild(_currentTable);
        }


        protected override void CreateTableHeaderRotation(List<string> columnNames)
        {
            _currentTable = new Table();

            // Установка общих свойств таблицы
            var tableProperties = new TableProperties(
                new TableWidth { Width = "150", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                    new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                )
            );
            _currentTable.AppendChild(tableProperties);

            // Создание строки заголовков
            var headerRow = new TableRow();

            for (int i = 0; i < columnNames.Count; i++)
            {
                var column = columnNames[i];
                var cell = new TableCell();

                // Настройка отступов для ячейки
                var cellProperties = new TableCellProperties(
                    new TableCellMargin(
                        new LeftMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                        new RightMargin { Width = "100", Type = TableWidthUnitValues.Dxa }
                    )
                );
                cell.AppendChild(cellProperties);

                // Создание текста с центровкой и дополнительными свойствами
                var paragraph = new Paragraph(
                    new ParagraphProperties(
                        new Justification { Val = JustificationValues.Center } // Центровка текста
                    ),
                    new Run(
                        new RunProperties(
                            new Bold(), // Жирный текст
                            new FontSize { Val = "24" }, // Размер шрифта (12 pt)
                            new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }
                        ),
                        new Text(column)
                    )
                );

                // Для 3 и последующих столбцов добавляем вертикальную ориентацию текста
                if (i >= 2)
                {
                    // Добавление ориентации текста для OpenXml
                    var textDirection = new TextDirection { Val = TextDirectionValues.BottomToTopLeftToRight }; // Вертикальная ориентация
                    cellProperties.AppendChild(textDirection);
                }

                cell.AppendChild(paragraph);
                headerRow.AppendChild(cell);
            }

            _currentTable.AppendChild(headerRow);
            _docBody!.AppendChild(_currentTable);
        }

        protected override void CreateRow(WordRowParameters rowParameters)
        {
            if (_currentTable == null) return;

            var tableRow = new TableRow();
            foreach (var text in rowParameters.Texts)
            {
                var paragraph = new Paragraph
                {
                    ParagraphProperties = new ParagraphProperties
                    {
                        Indentation = new Indentation { Left = "100" },
                    }
                };

                paragraph.AppendChild(new Run(new Text(text)));

                var tableCell = new TableCell(new Paragraph(new Run(new Text(text))));

                tableRow.AppendChild(tableCell);
            }

            _currentTable.AppendChild(tableRow);
        }

        protected override void CreatePageBreak()
        {
            if (_docBody == null) return;

            // Создаем параграф для разрыва страницы
            var docParagraph = new Paragraph();

            // Добавляем разрыв страницы
            var breakElement = new Run(new Break { Type = BreakValues.Page });
            docParagraph.AppendChild(breakElement);

            // Добавляем параграф с разрывом в тело документа
            _docBody.AppendChild(docParagraph);
        }

        // Реализация списка для Word
        protected override void CreateBulletList(List<string> items)
        {
            if (_docBody == null || items == null || items.Count == 0)
            {
                return;
            }

            // Создаём маркированный список
            foreach (var item in items)
            {
                var paragraph = new Paragraph
                {
                    ParagraphProperties = new ParagraphProperties
                    {
                        Justification = new Justification { Val = JustificationValues.Left }, // Выравнивание по левому краю
                        Indentation = new Indentation { Left = "360" }, // Отступ слева (пропорционально размеру шрифта)
                    }
                };

                // Добавляем символ маркера (•)
                var docRun = new Run();
                docRun.AppendChild(new Text("• "));
                docRun.AppendChild(new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" });
                docRun.AppendChild(new FontSize { Val = "28" });


                // Добавляем текст элемента списка
                docRun.AppendChild(new Text(item));
                paragraph.AppendChild(docRun);

                // Настройка отступов и выравнивания
                paragraph.ParagraphProperties.Indentation = new Indentation { Left = "360" };  // Отступ слева
                paragraph.ParagraphProperties.SpacingBetweenLines = new SpacingBetweenLines { After = "0" }; // Отступ после абзаца

                // Добавляем абзац в тело документа
                _docBody.AppendChild(paragraph);
            }
        }

        protected override void SaveWord(WordInfo info)
        {
            if (_docBody == null || _wordDocument == null) return;

            _docBody.AppendChild(CreateSectionProperties());
            _wordDocument.MainDocumentPart!.Document.Save();
            _wordDocument.Dispose();
        }
    }
}