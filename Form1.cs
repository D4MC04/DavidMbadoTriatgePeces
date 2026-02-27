// Emgu CV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using PdfSharp; // Aquí és on resideix GlobalFontSettings
using PdfSharp.Drawing;
using PdfSharp.Fonts; // Necessari per a IFontResolver
// PDF
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing; // <--- IMPRESCINDIBLE per a fer servir Bitmaps
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TriatgePeces
{
    public partial class frmTriatge1 : Form
    {
        // Variables globals

        private Mat? _imatgeActual;
        private List<Peca> _llistaPeces = new List<Peca>();

        public frmTriatge1()
        {
            if (GlobalFontSettings.FontResolver == null)
            {
                GlobalFontSettings.FontResolver = new WindowsFontResolver();
            }

            InitializeComponent();
        }

        // --- BLOC 1: VISIÓ ---

        private void btnGris1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null) return;
            Mat gris = new Mat();

            // EXAMEN INICI: Implementeu la invocació per a  convertir la _imatgeActual a Mat gris = new Mat();

            // Si la imatge ja es troba en escala de grisos, donarà error, pel que, si es el cas, sortim de la funció

            if (_imatgeActual.NumberOfChannels == 1) return;

            CvInvoke.CvtColor(_imatgeActual, gris, ColorConversion.Bgr2Gray);

            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge grisa (gris) al visor

            ActualitzarVisor(gris);
        }

        private void btnSuavitzat1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null) return;
            Mat suavitzat = new Mat();

            // EXAMEN INICI: Implementeu la invocació per a  convertir la _imatgeActual a Mat suavitzat = new Mat();

            CvInvoke.GaussianBlur(_imatgeActual, suavitzat, new Size(5, 5), 0);

            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge suavitzada (suavitzat) al visor

            ActualitzarVisor(suavitzat);
        }

        private void btnSegmentacio1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null) return;
            Mat binaria = new Mat();

            // EXAMEN INICI: Implementeu la invocació Threshold per a segmentar la _imatgeActual a Mat binaria = new Mat();

            CvInvoke.Threshold(_imatgeActual, binaria, 150, 255, ThresholdType.BinaryInv);

            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge segmentada (binaria) al visor

            ActualitzarVisor(binaria);
        }

        private void btnContorn1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null)
            {
                MessageBox.Show("Heu de carregar una imatge primer.");
                return;
            }

            // Treballem sobre una còpia per no perdre la imatge original neta si cal

            Mat imatgeColor = _imatgeActual.Clone();

            // Suposem que la imatge actual ja ha estat processada (Gris -> Suavitzat -> Threshold)
            // Si no, caldria fer el processament aquí abans de FindContours

            using (VectorOfVectorOfPoint contorns = new VectorOfVectorOfPoint())
            {
                Mat jerarquia = new Mat();

                // EXAMEN INICI: Invoca la llibreria per a trobar els contorns de la figura

                // Si la imatge no es troba en escala de grisos donarà error, pel que no executem la funció en aquest cas

                if (imatgeColor.NumberOfChannels != 1) return;


                CvInvoke.FindContours(imatgeColor, contorns, jerarquia, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                // EXAMEN FI

                for (int i = 0; i < contorns.Size; i++)
                {
                    // Filtre d'àrea per evitar soroll (ajustable segons la foto)

                    double area = CvInvoke.ContourArea(contorns[i]);
                    if (area < 500) continue;

                    // 1. Aproximació de polígons per comptar vèrtexs

                    VectorOfPoint aprox = new VectorOfPoint();

                    // EXAMEN INICI: Invoca la llibreria per a trobar els contorns de la figura i comptar els vèrtex aprox.Size

                    CvInvoke.ApproxPolyDP(contorns[i], aprox, CvInvoke.ArcLength(contorns[i], true) * 0.04, true);

                    // EXAMEN FI

                    // 2. Classificació segons el nombre de vèrtexs

                    string tipus = "";

                    // EXAMEN INICI

                    // Determina el tipus de forma amb un switch. A partir de 8 vèrtex el més probable és que sigui un cercle, pel que aquest és el default
                    // Tot i així, es podria ampliar per a reconèixer més formes

                    switch (aprox.Size)
                    {
                        case 3:

                            tipus = "Triangle";
                            break;

                        case 4:

                            tipus = "Rectangle";
                            break;

                        case 5:

                            tipus = "Pentagon";
                            break;

                        case 6:

                            tipus = "Hexagon";
                            break;

                        case 7:

                            tipus = "Heptagon";
                            break;

                        default:

                            tipus = "Cercle";
                            break;
                    }

                    // EXAMEN FI

                    // Actualitzem el label amb l'última detecció

                    lblPoligon1.Text = $"Detectat: {tipus} ({aprox.Size} vèrt.)";

                }

                // Mostrem el resultat final amb els rectangles dibuixats

                pbImatge1.Image = imatgeColor.ToBitmap();
            }
        }

        // --- BLOC 2: GESTIÓ I PDF ---

        private void btnAfegir1_Click(object sender, EventArgs e)
        {
            // Lògica simplificada per a l'examen: afegeix la darrera peça detectada
            if (!string.IsNullOrEmpty(lblPoligon1.Text) && lblPoligon1.Text.Contains(":"))
            {
                string nom = lblPoligon1.Text.Split(':')[1].Split('(')[0].Trim();

                // EXAMEN INICI: Afegeix una péça (Objecte Peca.cs) passant el tipus de la peça (nom). L'ària i la data poden quedar buits.

                // Si no s'ha detectat cap forma encara, no s'executa la funció

                if (string.IsNullOrEmpty(nom)) return;

                // Creem la peça, assignem el tipus i l'afegim a l'array

                Peca novaPeca = new Peca();
                novaPeca.Tipus = nom;
                _llistaPeces.Add(novaPeca);

                // EXAMEN FI

                // Crida a funció per a refrescar el contingut de la graella

                RefrescarGraella(_llistaPeces);
            }
        }

        private void tbCerca1_TextChanged(object sender, EventArgs e)
        {
            // Filtre LINQ dinàmic

            // EXAMEN INICI: Apliqueu el filtre dinàmic per a refrescar el que es mostra a la graella DataGridView

            string cerca = tbCerca1.Text.ToLower();
            List<Peca> filtrada = _llistaPeces.Where(p => p.Tipus.ToLower().Contains(cerca)).ToList();

            // EXAMEN FI

            // Crida a funció per a refrescar el contingut de la graella

            RefrescarGraella(filtrada);
        }

        private void btnInforme1_Click(object sender, EventArgs e)
        {
            // 1. Verifiquem si hi ha dades a la graella (que representa la cerca actual)

            // EXAMEN INICI

            if (dataGridView1.Rows.Count == 0) return;

            // EXAMEN FI

            // 2. Recorrem les files del DataGridView en lloc de la llista global
            // EXAMEN INICI

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Informe de peces de la base de dades";

            PdfPage pagina = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pagina);

            XFont fontTitol = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont fontNormal = new XFont("Arial", 11, XFontStyleEx.Regular);

            gfx.DrawString("Informe de peces de la base de dades", fontTitol, XBrushes.Black, new XPoint(50, 75));

            int y = 125;
            int comptador = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;

                string tipus = fila.Cells["Tipus"].Value?.ToString();
                string data = fila.Cells["Data"].Value?.ToString();

                gfx.DrawString($"{comptador + 1}. {tipus} - {data}", fontNormal, XBrushes.Black, new XPoint(50, y));

                y += 25;
                comptador += 1;
            }

            // EXAMEN FI

            // 3. Afegim el recompte total al final de l'informe

            // EXAMEN INICI

            gfx.DrawString($"Peces trobades: {comptador}", fontNormal, XBrushes.DarkBlue, new XPoint(50, y + 25));

            // Guardem l'arxiu PDF

            string ruta = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Peces.pdf");
            pdf.Save(ruta);
            MessageBox.Show($"PDF creat: {ruta}", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // EXAMEN FI
        }

        // Funcions auxiliars
        private void ActualitzarVisor(Mat m)
        {
            _imatgeActual = m.Clone();
            pbImatge1.Image = _imatgeActual.ToBitmap();
        }

        private void RefrescarGraella(List<Peca> dades)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dades;
        }

        private void btnCarregar1_Click(object sender, EventArgs e)
        {
            if (ofdObrir1.ShowDialog() == DialogResult.OK)
            {
                _imatgeActual = CvInvoke.Imread(ofdObrir1.FileName);
                pbImatge1.Image = _imatgeActual.ToBitmap();
            }
        }
    }
}