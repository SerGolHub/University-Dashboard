using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Reports.Models;

namespace University_Dasboard.Reports
{
	public abstract class WordReportBase
	{
		protected WordConfig Config { get; private set; }

		protected WordReportBase(WordConfig config)
		{
			Config = config ?? throw new ArgumentNullException(nameof(config));
		}

		public abstract void GenerateReport(string filePath);

		protected void AddTextElement(Body body, string text, string styleId = null, JustificationValues justification = JustificationValues.Left)
		{
			var paragraph = new Paragraph(new Run(new Text(text)))
			{
				ParagraphProperties = new ParagraphProperties
				{
					Justification = new Justification { Val = justification },
					ParagraphStyleId = styleId != null ? new ParagraphStyleId { Val = styleId } : null
				}
			};

			body.AppendChild(paragraph);
		}

		protected void SetPageOrientation(MainDocumentPart mainPart)
		{
			SectionProperties sectionProps = new SectionProperties();

			// Альбомная ориентация
			PageSize pageSize = new PageSize() { Width = 16838, Height = 11906, Orient = PageOrientationValues.Landscape };
			sectionProps.Append(pageSize);

			// Отступы по 1 см
			PageMargin pageMargin = new PageMargin
			{
				Top = 720, // 1 см
				Bottom = 720, // 1 см
				Left = 720, // 1 см
				Right = 720 // 1 см
			};
			sectionProps.Append(pageMargin);

			// Добавляем свойства раздела к телу документа
			mainPart.Document.Body!.Append(sectionProps);
		}
	}
}
