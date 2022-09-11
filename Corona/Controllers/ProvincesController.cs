using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Corona.Data;
using Corona.Infrastructure;
using Corona.Models;
using Corona.Models.Content;
using System;
using System.Threading.Tasks;
using static Corona.Infrastructure.Helper;

namespace Corona.Controllers
{
    public class ProvincesController : BaseController
    {
        private readonly CoronaContext context;

        public ProvincesController(CoronaContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.tblProvince.ToListAsync());
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
                return View(new Province());
            else
            {
                var province = await context.tblProvince.FindAsync(id);
                if (province == null)
                {
                    return NotFound();
                }
                return View(province);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string ProvinceName, [Bind("ProvinceId,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                
                if (id == null)
                {
                    try
                    {
                        var item = context.tblProvince.Where(p => p.ProvinceName.Equals(ProvinceName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(province);
                            await context.SaveChangesAsync();
                            Notify(province.ProvinceName + " province was added successfully");
                        }
                        else
                        {
                            Notify(item.ProvinceName + " already existing in the database", notificationType: NotificationType.error);
                            return View(item);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else
                {
                    try
                    {
                        context.Update(province);
                        await context.SaveChangesAsync();
                        Notify(province.ProvinceName + " province was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProvincesModelExists(province.ProvinceId))
                        { 
                            return NotFound(); 
                        }
                        else
                        { 
                            throw; 
                        }
                    }
                }
                return RedirectToAction(nameof(Index), province);
            }
            return View(province);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
                var province = await context.tblProvince.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.tblProvince.Remove(province);
                    await context.SaveChangesAsync();
                    Notify(province.ProvinceName + " province was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(province.ProvinceName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ProvincesModelExists(string id)
        {
            return context.tblProvince.Any(e => e.ProvinceId == id);
        }


        //------------------Create PDF--------------------

        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created 
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns
            PdfPTable tableLayout = new PdfPTable(1);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table

            //file will created in this path
            //string strAttachment = Report.Load(HttpContext.Current.Server.MapPath("GraduationCertificate.rpt"));


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF 
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            TimeSpan duration = new TimeSpan(30, 0, 0, 0);
            DateTime printedDate = DateTime.Now.Add(duration);


            float[] headers = { 50 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 100;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top

            List<Province> appointments = context.tblProvince.ToList<Province>();



            tableLayout.AddCell(new PdfPCell(new Phrase("The Collective\nGomery 767 Rd\nSummerStrand\nPort Elizabeth\nEastern Cape\n\nTell: 0839133030\nEmail: OCM03@Collective.com", new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Date: " + printedDate, new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Province Report", new Font(Font.HELVETICA, 16, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });




            ////Add header

            AddCellToHeader(tableLayout, "Province Name");



            ////Add body

            foreach (var emp in appointments)
            {
                AddCellToBody(tableLayout, emp.ProvinceName + "\n\n");
            }

            return tableLayout;
        }

        // Method to add single cell to the Header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 12, 1, iTextSharp.text.BaseColor.Black))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, BackgroundColor = new iTextSharp.text.BaseColor(204, 204, 255) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 12, 1, iTextSharp.text.BaseColor.Black))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255) });
        }

        ///------------------------Creating PDF ENDS HERE--------------------

    }
}

