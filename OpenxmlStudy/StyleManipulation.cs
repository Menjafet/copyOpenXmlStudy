﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stylexml
{
    public static class StyleManipulation
    {
        public static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            //Adding a part of type Style as a child of the main document
            StyleDefinitionsPart part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            //Styles root contains all the styles and saves the part
            Styles root = new Styles();
            //I think this is to saves the Model with the new style definition, not sure.
            root.Save(part);
            return part;
        }

        // Return true if the style id is in the document
        public static bool IsStyleIdInDocument(StyleDefinitionsPart styleDefinitionsPart, string styleid)
        {
            // Get access to the Styles element for this document (directly the styles).
            Styles s = styleDefinitionsPart.Styles;

            // Check that there are styles and how many (in the main document)
            int n = s.Elements<Style>().Count();
            if (n == 0)
            {
                return false;
            }


            // Look for a match on styleid.
            //Where the style element in our main document matchs the id and the type Paragraph
            Style style = s.Elements<Style>()
                .Where(st => (st.StyleId == styleid) && (st.Type == StyleValues.Paragraph))
                .FirstOrDefault();
            if (style == null)
                return false;

            return true;
        }

        public static string GetStyleIdFromStyleName(WordprocessingDocument doc, string styleName)
        {
            //Remember the style definitions part contains every style.
            StyleDefinitionsPart stylePart = doc.MainDocumentPart.StyleDefinitionsPart;
            string styleId = stylePart.Styles.Descendants<StyleName>()
                .Where(s => s.Val.Value.Equals(styleName) &&
                    (((Style)s.Parent).Type == StyleValues.Paragraph))
                .Select(n => ((Style)n.Parent).StyleId).FirstOrDefault();
            return styleId;
        }

        public static void AddNewTableStyle(StyleDefinitionsPart styleDefinitionsPart,
string styleid, string stylename)
        {
            // Get access to the root element of the styles part.
            Styles styles = styleDefinitionsPart.Styles;

            // Create a new paragraph style and specify some of the properties.
            Style style = new Style()
            {
                Type = StyleValues.Table,
                StyleId = styleid,
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = stylename };
            style.Append(styleName1);

            var tcPr = new StyleTableCellProperties();

            var shd = tcPr.AppendChild(new Shading()
            {
                Color = "auto",
                Fill = "EDEDED",
            });


            ParagraphProperties pPr = new ParagraphProperties(new SpacingBetweenLines()
            {
                After = "0",
                Line = "240",
                LineRule = LineSpacingRuleValues.Auto
            });

            style.Append(pPr);
            style.Append(tcPr);

            styles.Append(style);
        }
    }
}
