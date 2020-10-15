using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace ZamjenaDomova.WinUI.Reports
{
    public partial class ucListingsCount : UserControl
    {
        private readonly APIService _listingService = new APIService("Listing");
        private readonly APIService _territoryService = new APIService("Territory");
        public ucListingsCount()
        {
            InitializeComponent();
            dgvCount.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private async void ucListingsCount_Load(object sender, EventArgs e)
        {
            var result = await _listingService.GetListingsCount<ListingCountModel>(null);
            dgvCount.AutoGenerateColumns = false;
            dgvCount.DataSource = result;

            LoadTerritories();
            
    }
        private async void LoadTerritories()
        {
            var result = await _territoryService.Get<List<Model.Territory>>(null);
            result.Insert(0, new Model.Territory { TerritoryId = null, Name = null });

            cmbTerritory.DataSource = result;
            cmbTerritory.DisplayMember = "Name";
            cmbTerritory.ValueMember = "TerritoryId";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ListingsCountSearchRequest request = null;

            var idObj = cmbTerritory.SelectedValue;
            if (idObj!= null && int.TryParse(idObj.ToString(), out int id))
            {
                request = new ListingsCountSearchRequest();
                request.TerritoryId = id;
            }
            var result = await _listingService.GetListingsCount<ListingCountModel>(request);
            dgvCount.AutoGenerateColumns = false;
            dgvCount.DataSource = result;
        }

        private async void btnPDF_Click(object sender, EventArgs e)
        {
            var tableData = await _listingService.GetListingsCount<Model.ListingCountModel>(null);
            var month = DateTime.Now.ToString("MM");
            var year = DateTime.Now.ToString("yyyy");
            var fileName = "brojOglasaGradovi_"+month+"_"+year+".pdf";
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
           

            float[] columnWidths = { 1,2,2,1};
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths));
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            Cell[] headerFooter = new Cell[]{

                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("RB.")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Grad")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Kanton")),
                new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Broj oglasa"))
            };

            foreach (Cell hfCell in headerFooter)
            {
                table.AddHeaderCell(hfCell);
            }

            int counter = 1;

            tableData = tableData.OrderBy(x => x.Territory).ToList();

            if (tableData != null)
            {
                foreach (var row in tableData)
                {
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(counter++.ToString())));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.City)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.Territory)));
                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(row.Count.ToString())));
                }
            }
            document.Add(table);

            document.Close();
            MessageBox.Show("Izvjestaj uspjesno kreiran!");
        }
    }
}
