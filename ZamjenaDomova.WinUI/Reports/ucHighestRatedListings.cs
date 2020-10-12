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
using iText.Layout.Properties;
using iText.Layout.Element;
using iText.Kernel.Colors;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucHighestRatedListings : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        public ucHighestRatedListings()
        {
            InitializeComponent();
        }
        private async void ucHighestRatedListings_Load(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest { Approved = true };

            var result = await _listingService.Get<List<Listing>>(request);
            result = result.OrderByDescending(x => x.AverageRating).ToList();
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

            var result = await _listingService.Get<List<Listing>>(request);
            dgvListings.AutoGenerateColumns = false;
            dgvListings.DataSource = result;
        }
        private async void btnPDF_Click(object sender, EventArgs e)
        {
            var request = new ListingSearchRequest
            {
                Approved = true,
                City = txtCity.Text,
            };

            var tableData = await _listingService.Get<List<Listing>>(request);

            var month = DateTime.Now.ToString("MM");
            var year = DateTime.Now.ToString("yyyy");
            var fileName = "najboljiOglasi_" + month + "_" + year + ".pdf";
            var path = "..\\..\\Data\\Reports\\izvjestaj_" + fileName;

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Izvještaj za mjesec: " + month + ". " + year + ". godine")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);
            document.Add(new Paragraph(new Text("\n")));
            document.Add(new Paragraph("Najbolje ocijenjeni oglasi"))
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);


            float[] columnWidths = { 1, 2, 2, 2, 2, 1, 2};
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths));
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            Cell[] headerFooter = new Cell[]{

                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("RB.")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Naziv")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Lokacija")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Kanton")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Korisnik")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Kapacitet")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Prosječna ocjena"))
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
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.Persons.ToString())));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.AverageRating.ToString("0.##"))));
                }
            }
            document.Add(table);

            document.Close();
            MessageBox.Show("Izvjestaj uspjesno kreiran!");
        }
    }
}
