using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;

namespace ArtefaktGenerator
{
    public class PDFExport
    {        
        public static void saveArtefaktAsPDF(DasArtefakt artefakt, string path)
        {
            Document document = new Document();
            Section section = document.AddSection();

            // title
            Paragraph partitle = section.AddParagraph();
            partitle.AddFormattedText("Artefaktbrief", TextFormat.Bold);
            partitle.Format.Alignment = ParagraphAlignment.Center;
            partitle.Format.Font.Size = 30;
            partitle.Format.SpaceAfter = 20;

            // artefakttyp
            Paragraph parartefakttyp = section.AddParagraph();
            parartefakttyp.Format.Font.Size = 14;
            parartefakttyp.Format.SpaceAfter = 14;
            parartefakttyp.AddText("Artefakttyp: ");

            string artefakttyp = "";
            switch (artefakt.artefakt.typ)
            {
                case Artefakt.ArtefaktType.TEMP:
                    artefakttyp += "temporär";
                    switch (artefakt.artefakt.temp_typ)
                    {
                        case Artefakt.TempType.TAG: artefakttyp += " (Tag)"; break;
                        case Artefakt.TempType.WOCHE: artefakttyp += " (Woche)"; break;
                        case Artefakt.TempType.MONAT: artefakttyp += " (Monat)"; break;
                    }
                    break;
                case Artefakt.ArtefaktType.MATRIX:
                    artefakttyp += "Matrixgeber";
                    switch (artefakt.artefakt.matrix_typ)
                    {
                        case Artefakt.MatrixType.LABIL: artefakttyp += " (labil)"; break;
                        case Artefakt.MatrixType.STABIL: artefakttyp += " (stabil)"; break;
                        case Artefakt.MatrixType.SEHRSTABIL: artefakttyp += " (sehr stabil)"; break;
                        case Artefakt.MatrixType.UNEMPFINDLICH: artefakttyp += " (unempfindlich)"; break;
                    }
                    break;
                case Artefakt.ArtefaktType.AUX:
                    artefakttyp += "Auxiliator";
                    switch (artefakt.artefakt.aux_typ)
                    {
                        case Artefakt.MatrixType.LABIL: artefakttyp += " (labil)"; break;
                        case Artefakt.MatrixType.STABIL: artefakttyp += " (stabil)"; break;
                        case Artefakt.MatrixType.SEHRSTABIL: artefakttyp += " (sehr stabil)"; break;
                        case Artefakt.MatrixType.UNEMPFINDLICH: artefakttyp += " (unempfindlich)"; break;
                    }
                    break;
                case Artefakt.ArtefaktType.SEMI:
                    artefakttyp += "semipermanent";
                    switch (artefakt.artefakt.semi_typ)
                    {
                        case Artefakt.SemiType.TAG: artefakttyp += " (Tag)"; break;
                        case Artefakt.SemiType.WOCHE: artefakttyp += " (Woche)"; break;
                        case Artefakt.SemiType.MONAT: artefakttyp += " (Monat)"; break;
                        case Artefakt.SemiType.JAHR: artefakttyp += " (Jahr)"; break;
                    }
                    break;
                case Artefakt.ArtefaktType.NORMAL:
                    artefakttyp += "normal";
                    break;
                case Artefakt.ArtefaktType.RECHARGE:
                    artefakttyp += "aufladbar";
                    break;
            }

            parartefakttyp.AddFormattedText(artefakttyp, TextFormat.Bold | TextFormat.Italic);

            // material
            Paragraph parartefaktmaterial = section.AddParagraph();
            parartefaktmaterial.Format.Font.Size = 14;
            parartefaktmaterial.Format.SpaceAfter = 14;
            parartefaktmaterial.AddText("Material: ");

            string matString = artefakt.artefakt.material.name;
            if (artefakt.artefakt.regelbasis == Artefakt.Regelbasis.SRD && artefakt.artefakt.kristalle)
                matString += " (tragender Kristall)";

            parartefaktmaterial.AddFormattedText(matString, TextFormat.Bold | TextFormat.Italic);

            // modifikatoren
            Paragraph parmodifikatoren = section.AddParagraph();
            parmodifikatoren.Format.Font.Size = 14;
            parmodifikatoren.Format.SpaceAfter = 14;
            parmodifikatoren.AddText("Probenmodifikatoren:");            
            Paragraph parmodifikatorenDetail = section.AddParagraph();
            parmodifikatorenDetail.Format.Font.Size = 14;
            parmodifikatorenDetail.Format.LeftIndent = "1cm";
            parmodifikatorenDetail.Format.SpaceAfter = 14;
            parmodifikatorenDetail.AddText("Auslöser: " + artefakt.artefakt.probe.ausloeser);
            parmodifikatorenDetail.AddLineBreak();
            parmodifikatorenDetail.AddText("Artefaktgröße: " + artefakt.artefakt.probe.groesse);
            parmodifikatorenDetail.AddLineBreak();
            parmodifikatorenDetail.AddText("Objektaffinität: " + artefakt.artefakt.probe.affine);
            parmodifikatorenDetail.AddLineBreak();
            parmodifikatorenDetail.AddText("Sternenkonstellation: " + artefakt.artefakt.probe.stars);
            parmodifikatorenDetail.AddLineBreak();
            parmodifikatorenDetail.AddText("Arcanovi erzwingen: " + artefakt.artefakt.probe.erzwingen);
            parmodifikatorenDetail.AddLineBreak();
            

            // spez. Eigenschaften
            Paragraph parspezEigenschaften = section.AddParagraph();
            parspezEigenschaften.Format.Font.Size = 14;
            parspezEigenschaften.AddText("Spezielle Artefakteigenschaften: ");
            parspezEigenschaften.Format.SpaceAfter = 14;

            if (artefakt.artefakt.spezial_apport || artefakt.artefakt.spezial_ferngespuer || artefakt.artefakt.spezial_gespuer ||
                artefakt.artefakt.spezial_reperatur || artefakt.artefakt.spezial_resistent || artefakt.artefakt.spezial_reversalis ||
                artefakt.artefakt.spezial_siegel || artefakt.artefakt.spezial_unzerbrechlich || artefakt.artefakt.spezial_variablerausloeser ||
                artefakt.artefakt.spezial_verschleierung || artefakt.artefakt.spezial_verzehrend)
            {
                Paragraph parspezEigenschaftenDetail = section.AddParagraph();
                parspezEigenschaftenDetail.Format.Font.Size = 14;
                parspezEigenschaftenDetail.Format.LeftIndent = "1cm";
                parspezEigenschaftenDetail.Format.SpaceAfter = 14;

                if (artefakt.artefakt.spezial_siegel)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Siegel und Zertifikat", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                
                }
                if (artefakt.artefakt.spezial_unzerbrechlich)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Unzerbrechlichkeit", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                            
                }
                if (artefakt.artefakt.spezial_gespuer)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Gespür des Schöpfers", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();
                }
                if (artefakt.artefakt.spezial_apport)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Magischer Apport", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();
                }
                if (artefakt.artefakt.spezial_resistent)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Resistenz geg. profanen Schaden", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_reperatur)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Selbstreparatur", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_ferngespuer)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Ferngespür", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_reversalis)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Umkehrtalisman", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_variablerausloeser)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Variabler Auslöser", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_verschleierung)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Verschleierung", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
                if (artefakt.artefakt.spezial_verzehrend)
                {
                    parspezEigenschaftenDetail.AddFormattedText("Verzehrender Zauber", TextFormat.Italic);
                    parspezEigenschaftenDetail.AddLineBreak();                    
                }
            }
            else
            {
                parspezEigenschaften.AddFormattedText("keine", TextFormat.Bold | TextFormat.Italic);
            }

            // ladungen
            Paragraph ladungen = section.AddParagraph();
            ladungen.Format.Font.Size = 14;
            ladungen.Format.SpaceAfter = 14;
            ladungen.AddText("Ladungen: ");
            ladungen.AddFormattedText(artefakt.artefakt.loads.ToString(), TextFormat.Bold | TextFormat.Italic);

            // wirkende Zauber
            Paragraph parwirkZauber = section.AddParagraph();
            parwirkZauber.Format.Font.Size = 14;
            parwirkZauber.Format.SpaceAfter = 14;
            parwirkZauber.AddText("Wirkende Zauber:");

            Table wirkZauber = section.AddTable();
            wirkZauber.Borders.Visible = true;

            Column cZauber = wirkZauber.AddColumn("6cm");
            cZauber.Format.Alignment = ParagraphAlignment.Left;
            Column cKomp = wirkZauber.AddColumn("2.5cm");
            cKomp.Format.Alignment = ParagraphAlignment.Center;
            Column cStapel = wirkZauber.AddColumn("2.5cm");
            cStapel.Format.Alignment = ParagraphAlignment.Center;
            Column cAsp = wirkZauber.AddColumn("2.5cm");
            cAsp.Format.Alignment = ParagraphAlignment.Center;
            Column cRep = wirkZauber.AddColumn("3cm");
            cRep.Format.Alignment = ParagraphAlignment.Center;

            Row row = wirkZauber.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 12;
            row.Cells[0].AddParagraph("Zauber");
            row.Cells[1].AddParagraph("Komp.");
            row.Cells[2].AddParagraph("Stapel");
            row.Cells[3].AddParagraph("AsP");
            row.Cells[4].AddParagraph("Rep.");

            foreach (Zauber zaub in artefakt.zauber)
            {
                row = wirkZauber.AddRow();
                row.Format.Font.Size = 12;
                row.Cells[0].AddParagraph(zaub.name);
                row.Cells[1].AddParagraph(zaub.KomplexitaetToString(zaub.komp));
                row.Cells[2].AddParagraph(zaub.staple.ToString());
                row.Cells[3].AddParagraph(zaub.asp.ToString());
                row.Cells[4].AddParagraph((zaub.eigene_rep) ? "eigene" : "fremde");
            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(path);
        }
    }
}
