using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.Model;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucListingDetails : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        bool IsStartDateNull = true;
        bool IsEndDateNull = true;
        public ucListingDetails()
        {
            InitializeComponent();
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";
            dtpStart.CustomFormat = " ";
            dgvListings.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private async void ucListingDetails_Load(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest { Approved = true };

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;

        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest
            {
                Approved = true,
                City = txtCity.Text,
            };

            if (IsStartDateNull)
                request.StartDate = null;
            else request.StartDate = dtpStart.Value;

            if (IsEndDateNull)
                request.EndDate = null;
            else request.EndDate = dtpEnd.Value;

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;
        }

        private void lblClear_MouseClick(object sender, MouseEventArgs e)
        {
            dtpEnd.CustomFormat = " ";
            dtpStart.CustomFormat = " ";
            IsStartDateNull = true;
            IsEndDateNull = true;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpStart.CustomFormat = "dd/MM/yyyy";
            IsStartDateNull = false;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            IsEndDateNull = false;
        }

        private async void btnPDF_Click(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest
            {
                Approved = true,
                City = txtCity.Text,
            };

            if (IsStartDateNull)
                request.StartDate = null;
            else request.StartDate = dtpStart.Value;

            if (IsEndDateNull)
                request.EndDate = null;
            else request.EndDate = dtpEnd.Value;

            var tableData = await _listingService.Get<List<Listing>>(request);

            var month = DateTime.Now.ToString("MM");
            var year = DateTime.Now.ToString("yyyy");
            var fileName = "detaljiOglasa_" + month + "_" + year + ".pdf";
            var path = "..\\..\\Data\\Reports\\izvjestaj_" + fileName;

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Izvještaj za mjesec: " + month + ". " + year + ". godine")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);
            document.Add(new Paragraph(new Text("\n")));
            document.Add(new Paragraph("Broj aktivnih oglasa po gradovima"))
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);


            float[] columnWidths = { 1, 2, 2, 2, 2, 2 };
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths));
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            Cell[] headerFooter = new Cell[]{

                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("RB.")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Naziv")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Lokacija")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Kanton")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Korisnik")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Datum objave"))
            };

            foreach (Cell hfCell in headerFooter)
            {
                table.AddHeaderCell(hfCell);
            }

            int counter = 1;

            tableData = tableData.ToList();

            if (tableData != null)
            {
                foreach (var row in tableData)
                {
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(counter++.ToString())));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.Name)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.City)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.TerritoryName)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.UserName)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.DateApproved.ToString("dd/MM/yyyy"))));
                }
            }
            document.Add(table);

            document.Close();
            MessageBox.Show("Izvjestaj uspjesno kreiran!");
        }
    }
}
