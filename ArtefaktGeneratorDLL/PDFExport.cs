using System;
using System.Collections.Generic;
using System.Text;
using sharpPDF;
using sharpPDF.Enumerators;

namespace ArtefaktGenerator
{
    public class PDFExport
    {
        public static void saveArtefaktAsPDF(DasArtefakt artefakt, string path)
        {
            pdfDocument myDoc = new pdfDocument("Artefakt",artefakt.artefakt.heldName,false);
            pdfPage myFirstPage = myDoc.addPage();

            int start = 600;
            int fontsize = 14;
            int zeile = 0;
            int spalte = 50;

            //Artefakttyp
            myFirstPage.addText("Artefakttyp: ", spalte, start - fontsize * zeile, predefinedFont.csHelvetica, fontsize);
            string artefakttyp ="";
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
            myFirstPage.addText(artefakttyp, spalte+100, start - fontsize * zeile++, predefinedFont.csHelvetivaBoldOblique, fontsize);

            //Material
            myFirstPage.addText("Material: ", spalte, start - fontsize * zeile, predefinedFont.csHelvetica, fontsize);
            string matString = artefakt.artefakt.material.name;
            if (artefakt.artefakt.regelbasis == Artefakt.Regelbasis.SRD && artefakt.artefakt.kristalle)
                matString += " (tragender Kristall)";
            myFirstPage.addText(matString, spalte + 100, start - fontsize * zeile++, predefinedFont.csHelvetivaBoldOblique, fontsize);

            //Proben-Modifkatoren
            zeile++;
            myFirstPage.addText("Probenmodifikationen:", spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);
            string temp = "Ausloeser: " + artefakt.artefakt.probe.ausloeser;
            myFirstPage.addText(temp, spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);
            temp = "Artefaktgröße: " + artefakt.artefakt.probe.groesse;
            myFirstPage.addText(temp, spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);
            temp = "Objektaffinität: " + artefakt.artefakt.probe.affine;
            myFirstPage.addText(temp, spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);
            temp = "Sternenkonstellation: " + artefakt.artefakt.probe.stars;
            myFirstPage.addText(temp, spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);
            temp = "Arcanovi erzwingen: " + artefakt.artefakt.probe.erzwingen;
            myFirstPage.addText(temp, spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, fontsize);



            pdfTable myTable = new pdfTable();
            pdfTableRow myRow;
            int zstart;

            // Spezielle Eigenschaften
            zeile++;
            myFirstPage.addText("Spezielle Artefakteigenschaften:", spalte, start - fontsize * zeile, predefinedFont.csHelvetica, 14);
            if (artefakt.artefakt.spezial_apport || artefakt.artefakt.spezial_ferngespuer || artefakt.artefakt.spezial_gespuer || 
                artefakt.artefakt.spezial_reperatur || artefakt.artefakt.spezial_resistent || artefakt.artefakt.spezial_reversalis || 
                artefakt.artefakt.spezial_siegel || artefakt.artefakt.spezial_unzerbrechlich || artefakt.artefakt.spezial_variablerausloeser || 
                artefakt.artefakt.spezial_verschleierung || artefakt.artefakt.spezial_verzehrend)
            {
                zeile++;
                zstart = zeile;
                myTable.borderSize = 1;
                myTable.tableHeader.addColumn(new pdfTableColumn("Eigenschaft", predefinedAlignment.csLeft, 230));

                if (artefakt.artefakt.spezial_siegel)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Siegel und Zertifikat";
                    myTable.addRow(myRow);
                    zeile+=2;
                }
                if (artefakt.artefakt.spezial_unzerbrechlich)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Unzerbrechlichkeit";
                    myTable.addRow(myRow);
                    zeile+=2;
                }
                if (artefakt.artefakt.spezial_gespuer)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Gespür des Schöpfers";
                    myTable.addRow(myRow);
                    zeile+=2;
                }
                if (artefakt.artefakt.spezial_apport)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Magischer Apport";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_resistent)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Resistenz geg. profanen Schaden";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_reperatur)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Selbstreparatur";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_ferngespuer)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Ferngespür";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_reversalis)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Umkehrtalisman";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_variablerausloeser)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Variabler Auslöser";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_verschleierung)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Verschleierung";
                    myTable.addRow(myRow);
                    zeile += 2;
                }
                if (artefakt.artefakt.spezial_verzehrend)
                {
                    myRow = myTable.createRow();
                    myRow[0].columnValue = "Verzehrender Zauber";
                    myTable.addRow(myRow);
                    zeile += 2;
                }

                myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique, 12, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csGray));
                myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 10, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite));
                myTable.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 10, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csLightGray));
                myTable.cellpadding = 5;
                myFirstPage.addTable(myTable, spalte, start - fontsize * zstart);
                zeile+=2;
                myTable = null;
            }
            else
            {
                myFirstPage.addText("keine", spalte + 200, start - fontsize * zeile++, predefinedFont.csHelvetivaBoldOblique, fontsize);
            }



            // Wirkende Zauber 
            myFirstPage.addText("Wirkende Zauber", spalte, start - fontsize * zeile++, predefinedFont.csHelvetica, 14);
            zstart = zeile;
            myTable = new pdfTable();
            myTable.borderSize = 1;
            myTable.tableHeader.addColumn(new pdfTableColumn("Zauber",predefinedAlignment.csLeft,170));
            myTable.tableHeader.addColumn(new pdfTableColumn("Komp.",predefinedAlignment.csCenter,80));
            myTable.tableHeader.addColumn(new pdfTableColumn("Stapel", predefinedAlignment.csCenter, 80));
            myTable.tableHeader.addColumn(new pdfTableColumn("AsP", predefinedAlignment.csCenter, 80));
            myTable.tableHeader.addColumn(new pdfTableColumn("Rep.", predefinedAlignment.csCenter, 90));

            foreach (Zauber zaub in artefakt.zauber)
            {
                myRow = myTable.createRow();
                myRow[0].columnValue = zaub.name;
                myRow[1].columnValue = zaub.komp;
                myRow[2].columnValue = zaub.staple.ToString();
                myRow[3].columnValue = zaub.asp.ToString();
                myRow[4].columnValue = (zaub.eigene_rep)?"eigene":"fremde";
                myTable.addRow(myRow);
                zeile+=2;
            }
            myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique,12,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csGray));
            myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier,10,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csWhite));
            myTable.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier,10,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csLightGray));
            myTable.cellpadding = 5;
            myFirstPage.addTable(myTable, spalte, start - fontsize * zstart);
            zeile+=2;


            myTable = null;
            myDoc.createPDF(path);
        }
    }
}
